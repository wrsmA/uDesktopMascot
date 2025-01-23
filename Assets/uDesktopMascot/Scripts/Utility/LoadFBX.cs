using System.IO;
using System.Collections.Generic;
using System.Threading;
using Assimp;
using UnityEngine;
using Unity.Logging;
using Cysharp.Threading.Tasks;

// 名前空間エイリアスを追加
using AssimpMaterial = Assimp.Material;
using AssimpMesh = Assimp.Mesh;
using UnityEngineMaterial = UnityEngine.Material;
using UnityEngineMesh = UnityEngine.Mesh;

namespace uDesktopMascot
{
    /// <summary>
    /// FBXファイルを読み込むクラス
    /// </summary>
    public static class LoadFBX
    {
        /// <summary>
        /// 指定されたパスのFBXモデルを非同期的に読み込み、GameObjectを返します。
        /// </summary>
        /// <param name="modelPath">モデルファイルのパス（StreamingAssetsからの相対パス）</param>
        /// <param name="texturePaths">テクスチャファイルのパスのリスト</param>
        /// <param name="cancellationToken"></param>
        /// <returns>読み込まれたモデルのGameObjectを返すUniTask</returns>
        public static async UniTask<GameObject> LoadModelAsync(
            string modelPath,
            List<string> texturePaths,
            CancellationToken cancellationToken)
        {
            // モデルファイルのフルパスを作成
            string fullModelPath = ResolvePath(modelPath);

            // モデルファイルが存在するか確認
            if (!File.Exists(fullModelPath))
            {
                Log.Error("[LoadFBX] モデルファイルが見つかりません: {0}", fullModelPath);
                return null;
            }

            // 重い処理をバックグラウンドスレッドで実行
            ModelData modelData = await UniTask.RunOnThreadPool(async () =>
            {
                // Assimpのインポーターを作成
                AssimpContext importer = new AssimpContext();

                // シーンをインポート
                Scene scene;
                try
                {
                    scene = importer.ImportFile(
                        fullModelPath,
                        PostProcessPreset.TargetRealTimeMaximumQuality);
                }
                catch (System.Exception ex)
                {
                    Log.Error("[LoadFBX] モデルのインポート中にエラーが発生しました: {0}", ex.Message);
                    return null;
                }

                if (scene == null || !scene.HasMeshes)
                {
                    Log.Error("[LoadFBX] モデルのインポートに失敗しました。");
                    return null;
                }

                Log.Info("[LoadFBX] モデルのインポートに成功しました。");

                // モデルデータを保持するクラスを作成
                ModelData data = new ModelData
                {
                    Name = Path.GetFileNameWithoutExtension(modelPath),
                    Meshes = new List<MeshData>(),
                    Materials = new List<MaterialData>()
                };

                // テクスチャパスが一つのみの場合、その一つを全てのマテリアルに適用する
                bool isSingleTexture = texturePaths != null && texturePaths.Count == 1;

                // マテリアルを処理
                int textureIndex = 0;
                int textureCount = texturePaths != null ? texturePaths.Count : 0;

                foreach (var assimpMaterial in scene.Materials)
                {
                    string texturePath = null;

                    if (texturePaths != null && textureCount > 0)
                    {
                        if (isSingleTexture)
                        {
                            // テクスチャパスが一つだけの場合、全てのマテリアルにそのテクスチャを適用
                            texturePath = texturePaths[0];
                        }
                        else
                        {
                            if (textureIndex < textureCount)
                            {
                                texturePath = texturePaths[textureIndex];
                            }
                            else
                            {
                                // テクスチャの数がマテリアルの数より少ない場合、最後のテクスチャを使用
                                texturePath = texturePaths[textureCount - 1];
                            }
                        }
                    }
                    else
                    {
                        Log.Warning("[LoadFBX] テクスチャパスが指定されていません。"
                            + "マテリアル '{0}' にテクスチャが割り当てられません。", assimpMaterial.Name);
                    }

                    textureIndex++;

                    var materialData = await ProcessMaterialAsync(assimpMaterial, texturePath);
                    data.Materials.Add(materialData);
                }

                // ノードを処理
                ProcessNode(scene.RootNode, scene, data);

                return data;
            }, cancellationToken: cancellationToken);

            // バックグラウンド処理でエラーがあった場合
            if (modelData == null)
            {
                return null;
            }

            // メインスレッドでGameObjectを生成
            GameObject modelRoot = new GameObject(modelData.Name);

            // メッシュとマテリアルを設定
            foreach (var meshData in modelData.Meshes)
            {
                GameObject meshObject = new GameObject(meshData.Name);
                meshObject.transform.SetParent(modelRoot.transform, false);

                MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = meshObject.AddComponent<MeshRenderer>();

                // UnityEngine.Meshを作成
                UnityEngineMesh unityMesh = new UnityEngineMesh
                {
                    name = meshData.Name,
                    vertices = meshData.Vertices,
                    normals = meshData.Normals,
                    uv = meshData.UVs,
                    colors = meshData.Colors,
                    triangles = meshData.Indices
                };
                unityMesh.RecalculateBounds();

                meshFilter.mesh = unityMesh;

                // MToon10 シェーダーを使用してマテリアルを作成
                Shader mtoonShader = Shader.Find("VRM10/MToon10");
                if (mtoonShader == null)
                {
                    Log.Error("[LoadFBX] MToon10 シェーダーが見つかりません。"
                        + "UniVRM パッケージが正しくインポートされているか確認してください。");

                    // フォールバックとして Standard シェーダーを使用
                    mtoonShader = Shader.Find("Standard");
                }

                UnityEngineMaterial material = new UnityEngineMaterial(mtoonShader);

                // カラーを設定
                material.SetColor("_Color", meshData.Material.Color);

                if (meshData.Material.TextureData != null)
                {
                    Texture2D texture = new Texture2D(2, 2);
                    if (texture.LoadImage(meshData.Material.TextureData))
                    {
                        // テクスチャを設定
                        material.SetTexture("_MainTex", texture);
                    }
                    else
                    {
                        Log.Warning("[LoadFBX] テクスチャのロードに失敗しました。");
                    }
                }

                meshRenderer.material = material;
            }

            Log.Info("[LoadFBX] モデルの読み込みとGameObjectの作成が完了しました。");

            return modelRoot;
        }

        /// <summary>
        /// ノードを処理してメッシュデータを収集
        /// </summary>
        private static void ProcessNode(Node node, Scene scene, ModelData modelData)
        {
            foreach (int meshIndex in node.MeshIndices)
            {
                AssimpMesh mesh = scene.Meshes[meshIndex];
                MeshData meshData = ConvertAssimpMesh(mesh, 
                    modelData.Materials[mesh.MaterialIndex]);
                modelData.Meshes.Add(meshData);
            }

            foreach (Node childNode in node.Children)
            {
                ProcessNode(childNode, scene, modelData);
            }
        }

        /// <summary>
        /// AssimpのMeshをMeshDataに変換する
        /// </summary>
        private static MeshData ConvertAssimpMesh(AssimpMesh mesh, MaterialData materialData)
        {
            MeshData meshData = new MeshData
            {
                Name = mesh.Name,
                Material = materialData
            };

            // 頂点座標
            meshData.Vertices = new Vector3[mesh.VertexCount];
            for (int i = 0; i < mesh.VertexCount; i++)
            {
                Vector3D vertex = mesh.Vertices[i];
                meshData.Vertices[i] = new Vector3(vertex.X, vertex.Y, vertex.Z);
            }

            // 法線
            if (mesh.HasNormals)
            {
                meshData.Normals = new Vector3[mesh.VertexCount];
                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    Vector3D normal = mesh.Normals[i];
                    meshData.Normals[i] = new Vector3(normal.X, normal.Y, normal.Z);
                }
            }

            // UV座標
            if (mesh.HasTextureCoords(0))
            {
                meshData.UVs = new Vector2[mesh.VertexCount];
                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    Vector3D uv = mesh.TextureCoordinateChannels[0][i];
                    meshData.UVs[i] = new Vector2(uv.X, uv.Y);
                }
            }

            // 頂点カラー
            if (mesh.HasVertexColors(0))
            {
                meshData.Colors = new Color[mesh.VertexCount];
                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    Color4D color = mesh.VertexColorChannels[0][i];
                    meshData.Colors[i] = new Color(color.R, color.G, color.B, color.A);
                }
            }

            // インデックス
            List<int> indices = new List<int>();
            foreach (Face face in mesh.Faces)
            {
                if (face.IndexCount == 3)
                {
                    indices.Add(face.Indices[0]);
                    indices.Add(face.Indices[1]);
                    indices.Add(face.Indices[2]);
                }
            }

            meshData.Indices = indices.ToArray();

            return meshData;
        }

        /// <summary>
        /// AssimpのマテリアルをMaterialDataに非同期で変換する
        /// </summary>
        private static async UniTask<MaterialData> ProcessMaterialAsync(
            AssimpMaterial assimpMaterial, string texturePath)
        {
            MaterialData materialData = new MaterialData();

            // カラーの設定
            if (assimpMaterial.HasColorDiffuse)
            {
                materialData.Color = new Color(
                    assimpMaterial.ColorDiffuse.R,
                    assimpMaterial.ColorDiffuse.G,
                    assimpMaterial.ColorDiffuse.B,
                    assimpMaterial.ColorDiffuse.A);
            }
            else
            {
                materialData.Color = Color.white;
            }

            // テクスチャ
            if (!string.IsNullOrEmpty(texturePath))
            {
                string fullTexturePath = ResolvePath(texturePath);

                if (File.Exists(fullTexturePath))
                {
                    byte[] data = await ReadAllBytesAsync(fullTexturePath);
                    materialData.TextureData = data;
                }
                else
                {
                    Log.Warning("[LoadFBX] テクスチャファイルが見つかりません: {0}", fullTexturePath);
                }
            }
            else
            {
                Log.Warning("[LoadFBX] テクスチャパスが指定されていません。"
                    + "マテリアル '{0}' にテクスチャが割り当てられません。", assimpMaterial.Name);
            }

            return materialData;
        }

        /// <summary>
        /// パスを解決してフルパスを返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ResolvePath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return null;
            }

            var fullPath = Path.IsPathRooted(path) ? path :
                Path.Combine(Application.streamingAssetsPath, path);

            return fullPath;
        }

        /// <summary>
        /// ファイルからすべてのバイトを非同期で読み込む
        /// </summary>
        private static async UniTask<byte[]> ReadAllBytesAsync(string path)
        {
            // Unity のバージョンが .NET Standard 2.0 以上の場合
            if (File.Exists(path))
            {
                return await File.ReadAllBytesAsync(path);
            }

            // Unity 2017 以前の場合
            using (FileStream sourceStream = new FileStream(
                path, FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                long fileLength = sourceStream.Length;
                byte[] result = new byte[fileLength];

                int totalBytesRead = 0;

                while (totalBytesRead < fileLength)
                {
                    var bytesRead = await sourceStream.ReadAsync(
                        result, totalBytesRead, 
                        (int)(fileLength - totalBytesRead));
                    if (bytesRead == 0)
                    {
                        break; // ストリームの終端に達した場合
                    }

                    totalBytesRead += bytesRead;
                }

                if (totalBytesRead != fileLength)
                {
                    Log.Warning("[LoadFBX] 予期しないEOFによりファイルの読み込みが完了しませんでした: {0}", path);
                    // 必要に応じて、部分的に読み込んだデータを処理するか、エラーを返す
                }

                return result;
            }
        }

        /// <summary>
        /// モデルデータを保持するクラス
        /// </summary>
        private class ModelData
        {
            public string Name;
            public List<MeshData> Meshes;
            public List<MaterialData> Materials;
        }

        /// <summary>
        /// メッシュデータを保持するクラス
        /// </summary>
        private class MeshData
        {
            public string Name;
            public Vector3[] Vertices;
            public Vector3[] Normals;
            public Vector2[] UVs;
            public Color[] Colors;
            public int[] Indices;
            public MaterialData Material;
        }

        /// <summary>
        /// マテリアルデータを保持するクラス
        /// </summary>
        private class MaterialData
        {
            public Color Color;
            public byte[] TextureData;
            public Texture2D Texture;
        }
    }
}