using System.IO;
using System.Collections.Generic;
using Assimp;
using UnityEngine;
using Unity.Logging; // Unity.Logging を使用

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
        /// 指定されたパスのFBXモデルを読み込み、GameObjectを返します。
        /// </summary>
        /// <param name="modelPath">モデルファイルのパス（StreamingAssetsからの相対パス）</param>
        /// <returns>読み込まれたモデルのGameObject</returns>
        public static GameObject LoadModel(string modelPath)
        {
            // モデルファイルのフルパスを作成
            string fullPath = Path.Combine(Application.streamingAssetsPath, modelPath);

            // モデルファイルが存在するか確認
            if (!File.Exists(fullPath))
            {
                Log.Error("[LoadFBX] モデルファイルが見つかりません: {fullPath}", fullPath);
                return null;
            }

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

            // モデルのルートGameObjectを作成
            GameObject modelRoot = new GameObject(Path.GetFileNameWithoutExtension(modelPath));

            // シーン内のノードを再帰的に処理
            ProcessNode(scene.RootNode, scene, modelRoot, Path.GetDirectoryName(fullPath));

            Log.Info("[LoadFBX] モデルの読み込みとGameObjectの作成が完了しました。");

            return modelRoot;
        }

        /// <summary>
        /// シーンのノードを再帰的に処理してGameObjectを構築する
        /// </summary>
        /// <param name="node">現在のノード</param>
        /// <param name="scene">Assimpのシーンデータ</param>
        /// <param name="parentObject">親のGameObject</param>
        /// <param name="basePath">モデルファイルのディレクトリパス</param>
        private static void ProcessNode(Node node, Scene scene, GameObject parentObject, string basePath)
        {
            // 現在のノードのGameObjectを作成
            GameObject nodeObject = new GameObject(node.Name);
            nodeObject.transform.SetParent(parentObject.transform, false);

            // ノードのメッシュを処理
            foreach (int meshIndex in node.MeshIndices)
            {
                AssimpMesh mesh = scene.Meshes[meshIndex];

                // UnityのMeshを作成
                UnityEngineMesh unityMesh = ConvertAssimpMeshToUnityMesh(mesh);

                // メッシュ用のGameObjectを作成
                GameObject meshObject = new GameObject(mesh.Name);
                meshObject.transform.SetParent(nodeObject.transform, false);

                // MeshFilterとMeshRendererを追加
                MeshFilter meshFilter = meshObject.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = meshObject.AddComponent<MeshRenderer>();

                // Meshを設定
                meshFilter.mesh = unityMesh;

                // マテリアルを取得または作成
                UnityEngineMaterial material = CreateMaterialFromAssimp(scene.Materials[mesh.MaterialIndex], basePath);

                // マテリアルを設定
                meshRenderer.material = material;

                Log.Info("[LoadFBX] メッシュ '{meshName}' を処理しました。", mesh.Name);
            }

            // 子ノードを再帰的に処理
            foreach (Node childNode in node.Children)
            {
                ProcessNode(childNode, scene, nodeObject, basePath);
            }
        }

        /// <summary>
        /// AssimpのMeshをUnityのMeshに変換する
        /// </summary>
        /// <param name="mesh">AssimpのMesh</param>
        /// <returns>UnityのMesh</returns>
        private static UnityEngineMesh ConvertAssimpMeshToUnityMesh(AssimpMesh mesh)
        {
            UnityEngineMesh unityMesh = new UnityEngineMesh
            {
                name = mesh.Name
            };

            // 頂点座標を設定
            Vector3[] vertices = new Vector3[mesh.VertexCount];
            for (int i = 0; i < mesh.VertexCount; i++)
            {
                Vector3D vertex = mesh.Vertices[i];
                vertices[i] = new Vector3(vertex.X, vertex.Y, vertex.Z);
            }
            unityMesh.vertices = vertices;

            // 法線を設定
            if (mesh.HasNormals)
            {
                Vector3[] normals = new Vector3[mesh.VertexCount];
                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    Vector3D normal = mesh.Normals[i];
                    normals[i] = new Vector3(normal.X, normal.Y, normal.Z);
                }
                unityMesh.normals = normals;
            }
            else
            {
                unityMesh.RecalculateNormals();
                Log.Warning("[LoadFBX] メッシュ '{meshName}' に法線がないため、再計算しました。", mesh.Name);
            }

            // UV座標を設定
            if (mesh.HasTextureCoords(0))
            {
                Vector2[] uvs = new Vector2[mesh.VertexCount];
                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    Vector3D uv = mesh.TextureCoordinateChannels[0][i];
                    uvs[i] = new Vector2(uv.X, uv.Y);
                }
                unityMesh.uv = uvs;
            }

            // 頂点カラーを設定（必要に応じて）
            if (mesh.HasVertexColors(0))
            {
                Color[] colors = new Color[mesh.VertexCount];
                for (int i = 0; i < mesh.VertexCount; i++)
                {
                    Color4D color = mesh.VertexColorChannels[0][i];
                    colors[i] = new Color(color.R, color.G, color.B, color.A);
                }
                unityMesh.colors = colors;
            }

            // 三角形インデックスを設定
            List<int> indices = new List<int>();
            foreach (Face face in mesh.Faces)
            {
                if (face.IndexCount == 3)
                {
                    indices.Add(face.Indices[0]);
                    indices.Add(face.Indices[1]);
                    indices.Add(face.Indices[2]);
                }
                else
                {
                    Log.Warning("[LoadFBX] メッシュ '{meshName}' に非三角形面が含まれています。頂点数: {vertexCount}", mesh.Name, face.IndexCount);
                }
            }
            unityMesh.triangles = indices.ToArray();

            unityMesh.RecalculateBounds();

            return unityMesh;
        }

        /// <summary>
        /// AssimpのマテリアルをUnityのマテリアルに変換する
        /// </summary>
        /// <param name="assimpMaterial">Assimpのマテリアル</param>
        /// <param name="basePath">モデルファイルのディレクトリパス</param>
        /// <returns>Unityのマテリアル</returns>
        private static UnityEngineMaterial CreateMaterialFromAssimp(AssimpMaterial assimpMaterial, string basePath)
        {
            // シンプルなStandardシェーダーを使用
            UnityEngineMaterial material = new UnityEngineMaterial(Shader.Find("Standard"));

            // マテリアル名のログ
            Log.Info("[LoadFBX] マテリアル '{materialName}' を処理します。", assimpMaterial.Name);

            // Diffuseカラーを適用
            if (assimpMaterial.HasColorDiffuse)
            {
                Color color = new Color(assimpMaterial.ColorDiffuse.R,
                                        assimpMaterial.ColorDiffuse.G,
                                        assimpMaterial.ColorDiffuse.B,
                                        assimpMaterial.ColorDiffuse.A);
                material.color = color;
            }

            // テクスチャを適用
            if (assimpMaterial.HasTextureDiffuse)
            {
                string texturePath = assimpMaterial.TextureDiffuse.FilePath;

                // 相対パスをフルパスに変換
                string fullTexturePath = Path.Combine(basePath, texturePath);

                if (File.Exists(fullTexturePath))
                {
                    Texture2D texture = LoadTexture(fullTexturePath);
                    if (texture != null)
                    {
                        material.mainTexture = texture;
                        Log.Info("[LoadFBX] テクスチャ '{texturePath}' を読み込みました。", texturePath);
                    }
                    else
                    {
                        Log.Warning("[LoadFBX] テクスチャのロードに失敗しました: {path}", fullTexturePath);
                    }
                }
                else
                {
                    Log.Warning("[LoadFBX] テクスチャファイルが見つかりません: {path}", fullTexturePath);
                }
            }

            return material;
        }

        /// <summary>
        /// テクスチャをロードする
        /// </summary>
        /// <param name="path">テクスチャファイルのフルパス</param>
        /// <returns>ロードされたテクスチャ</returns>
        private static Texture2D LoadTexture(string path)
        {
            if (!File.Exists(path))
            {
                Log.Warning("[LoadFBX] テクスチャファイルが見つかりません: {path}", path);
                return null;
            }

            byte[] data = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(2, 2);
            if (texture.LoadImage(data))
            {
                return texture;
            }
            else
            {
                Log.Warning("[LoadFBX] テクスチャのロードに失敗しました: {path}", path);
                return null;
            }
        }
    }
}