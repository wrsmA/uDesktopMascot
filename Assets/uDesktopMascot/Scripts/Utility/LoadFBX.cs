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
        /// <param name="cancellationToken"></param>
        /// <returns>読み込まれたモデルのGameObjectを返すUniTask</returns>
        public static async UniTask<GameObject> LoadModelAsync(string modelPath,CancellationToken cancellationToken)
        {
            // モデルファイルのフルパスを作成
            string fullPath = Path.Combine(Application.streamingAssetsPath, modelPath);

            // モデルファイルが存在するか確認
            if (!File.Exists(fullPath))
            {
                Log.Error("[LoadFBX] モデルファイルが見つかりません: {fullPath}", fullPath);
                return null;
            }

            // 重い処理をバックグラウンドスレッドで実行
            ModelData modelData = await UniTask.RunOnThreadPool(async () =>
            {
                // Assimpのインポーターを作成
                AssimpContext importer = new AssimpContext();

                // シーンをインポート（必要に応じてPostProcessを調整）
                Scene scene;
                try
                {
                    scene = importer.ImportFile(fullPath, PostProcessPreset.TargetRealTimeMaximumQuality);
                }
                catch (System.Exception ex)
                {
                    Log.Error("[LoadFBX] モデルのインポート中にエラーが発生しました: {message}", ex.Message);
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

                // マテリアルを処理
                foreach (var assimpMaterial in scene.Materials)
                {
                    var materialData = await ProcessMaterialAsync(assimpMaterial, Path.GetDirectoryName(fullPath));
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

                // マテリアルを作成
                UnityEngineMaterial material = new UnityEngineMaterial(Shader.Find("Standard"));
                material.color = meshData.Material.Color;
                if (meshData.Material.Texture != null)
                {
                    material.mainTexture = meshData.Material.Texture;
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
                MeshData meshData = ConvertAssimpMesh(mesh, modelData.Materials[mesh.MaterialIndex]);
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
        private static async UniTask<MaterialData> ProcessMaterialAsync(AssimpMaterial assimpMaterial, string basePath)
        {
            MaterialData materialData = new MaterialData();

            // カラー
            if (assimpMaterial.HasColorDiffuse)
            {
                materialData.Color = new Color(assimpMaterial.ColorDiffuse.R,
                                               assimpMaterial.ColorDiffuse.G,
                                               assimpMaterial.ColorDiffuse.B,
                                               assimpMaterial.ColorDiffuse.A);
            }
            else
            {
                materialData.Color = Color.white;
            }

            // テクスチャ
            if (assimpMaterial.HasTextureDiffuse)
            {
                string texturePath = assimpMaterial.TextureDiffuse.FilePath;
                string fullTexturePath = Path.Combine(basePath, texturePath);

                if (File.Exists(fullTexturePath))
                {
                    byte[] data = await ReadAllBytesAsync(fullTexturePath);
                    materialData.TextureData = data;
                }
                else
                {
                    Log.Warning("[LoadFBX] テクスチャファイルが見つかりません: {path}", fullTexturePath);
                }
            }

            return materialData;
        }

        /// <summary>
        /// ファイルからすべてのバイトを非同期で読み込む
        /// </summary>
        private static async UniTask<byte[]> ReadAllBytesAsync(string path)
        {
            await using FileStream sourceStream = new FileStream(path,
                FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
            byte[] result = new byte[sourceStream.Length];
            await sourceStream.ReadAsync(result, 0, (int)sourceStream.Length);
            return result;
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