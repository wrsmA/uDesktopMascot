using System;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniGLTF;
using UnityEngine;
using VRM;

namespace uDesktopMascot
{
    /// <summary>
    /// VRMファイルを読み込む
    /// </summary>
    public static class LoadVRM
    {
        /// <summary>
        /// デフォルトのVRMファイル名
        /// </summary>
        private const string DefaultVrmFileName = "DefaultModel/test";

        /// <summary>
        /// アニメーションコントローラーを設定
        /// </summary>
        /// <param name="animator"></param>
        public static void UpdateAnimationController(Animator animator)
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("CharacterAnimationController");
        }

        /// <summary>
        /// モデルをロードする
        /// </summary>
        public static async UniTask<GameObject> LoadModel(CancellationToken cancellationToken)
        {
            try
            {
                // StreamingAssetsフォルダ内のVRMファイルを検索
                string[] vrmFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.vrm");
                var userVrmFiles = vrmFiles;

                if (userVrmFiles.Length > 0)
                {
                    // ユーザー指定のVRMファイルを使用（最初のもの）
                    var path = userVrmFiles[0];
                    Debug.Log($"ユーザー指定のVRMファイルを使用します: {path}");

                    try
                    {
                        // VRMファイルをロードしてモデルを表示
                        return await LoadAndDisplayModel(path, cancellationToken);
                    } catch (Exception e)
                    {
                        Debug.LogError($"VRMの読み込みまたは表示中にエラーが発生しました: {e.Message}");
                        // エラーが発生した場合、デフォルトのモデルを表示
                        Debug.LogWarning("デフォルトのモデルを読み込みます。");
                        return LoadDefaultModel();
                    }
                } else
                {
                    // ユーザー指定のVRMファイルが見つからない場合、デフォルトのVRMファイルを使用
                    Debug.LogWarning("ユーザー指定のVRMファイルが見つかりません。デフォルトのモデルを読み込みます。");
                    return LoadDefaultModel();
                }
            } catch (Exception e)
            {
                Debug.LogError($"VRMの読み込みまたは表示中にエラーが発生しました: {e.Message}");
                return null;
            }
        }

        /// <summary>
        ///     デフォルトのVRMモデルをロードして表示する
        /// </summary>
        private static GameObject LoadDefaultModel()
        {
            // ResourcesフォルダからPrefabをロード
            var prefab = Resources.Load<GameObject>(DefaultVrmFileName);
            if (prefab == null)
            {
                Debug.LogError($"デフォルトのPrefabがResourcesフォルダに見つかりません: {DefaultVrmFileName}.prefab");
                return null;
            }

            // Prefabをインスタンス化
            var model = GameObject.Instantiate(prefab);

            // モデルの位置を設定（原点に配置）
            model.transform.position = Vector3.zero;

            // Y軸に180度回転（必要に応じて）
            model.transform.Rotate(0, 180, 0);

            // モデルをアクティブ化
            model.SetActive(true);

            // すべてのRendererを有効化
            EnableAllRenderers(model);

            Debug.Log($"デフォルトモデルのロードと表示が完了しました: {DefaultVrmFileName}.prefab");

            return model;
        }

        /// <summary>
        /// VRMファイルを読み込み、モデルを表示する
        /// </summary>
        /// <param name="path">VRMファイルのパス</param>
        /// <param name="cancellationToken"></param>
        private static async UniTask<GameObject> LoadAndDisplayModel(string path, CancellationToken cancellationToken)
        {
            // VRMファイルをバイト配列として非同期で読み込み
            var bytes = await File.ReadAllBytesAsync(path, cancellationToken);

            return await LoadAndDisplayModelFromBytes(bytes, path, cancellationToken);
        }

        /// <summary>
        ///     バイト配列からVRMモデルをロードして表示する
        /// </summary>
        /// <param name="bytes">VRMファイルのバイト配列</param>
        /// <param name="fileName">ファイル名（ログ用）</param>
        /// <param name="cancellationToken"></param>
        private static async UniTask<GameObject> LoadAndDisplayModelFromBytes(byte[] bytes, string fileName,
            CancellationToken cancellationToken)
        {
            // VRMファイルをパースしてGltfDataを取得
            var parsed = new GlbLowLevelParser(fileName, bytes).Parse();

            // VRMDataを作成
            var vrmData = new VRMData(parsed);

            // VRMImporterContextを作成
            using var vrmImporter = new VRMImporterContext(vrmData);

            // モデルを非同期で読み込み
            var instance = await vrmImporter.LoadAsync(new RuntimeOnlyAwaitCaller());

            // モデルのGameObjectを取得
            GameObject model = instance.Root;

            // モデルの位置を設定（原点に配置）
            model.transform.position = Vector3.zero;

            // Y軸に180度回転
            model.transform.Rotate(0, 180, 0);

            // モデルをアクティブ化
            model.SetActive(true);

            // すべてのRendererを有効化
            EnableAllRenderers(model);

            Debug.Log($"モデルのロードと表示が完了しました: {fileName}");

            return model;
        }

        /// <summary>
        /// モデル内のすべてのRendererコンポーネントを有効化する
        /// </summary>
        /// <param name="model">モデルのGameObject</param>
        private static void EnableAllRenderers(GameObject model)
        {
            // SkinnedMeshRendererを有効化
            var skinnedMeshRenderers = model.GetComponentsInChildren<SkinnedMeshRenderer>(true);
            foreach (var renderer in skinnedMeshRenderers)
            {
                renderer.enabled = true;
            }

            // MeshRendererを有効化
            var meshRenderers = model.GetComponentsInChildren<MeshRenderer>(true);
            foreach (var renderer in meshRenderers)
            {
                renderer.enabled = true;
            }
        }
    }
}