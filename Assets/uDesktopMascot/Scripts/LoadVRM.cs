using System;
using System.IO;
using UnityEngine;
using UniGLTF;
using VRM;

namespace uDesktopMascot
{
    /// <summary>
    /// VRMファイルを読み込む
    /// </summary>
    public class LoadVRM : MonoBehaviour
    {
        /// <summary>
        /// デフォルトのVRMファイル名
        /// </summary>
        private const string DefaultVrmFileName = "test.vrm";

        /// <summary>
        /// Start
        /// </summary>
        private async void Start()
        {
            // StreamingAssetsフォルダ内のVRMファイルを検索
            string[] vrmFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.vrm");

            string path = null;

            if (vrmFiles.Length > 0)
            {
                // 見つかったVRMファイルのうち最初のものを使用
                path = vrmFiles[0];
                Debug.Log($"ユーザー指定のVRMファイルを使用します: {path}");
            }
            else
            {
                // ユーザー指定のVRMファイルが見つからない場合、デフォルトのVRMファイルを使用
                path = Path.Combine(Application.streamingAssetsPath, DefaultVrmFileName);
                Debug.LogWarning("ユーザー指定のVRMファイルが見つかりません。デフォルトのモデルを読み込みます。");
            }

            // ファイルの存在確認
            if (!File.Exists(path))
            {
                Debug.LogError($"VRMファイルが見つかりません: {path}");
                return;
            }

            try
            {
                // VRMファイルをバイト配列として非同期で読み込み
                var bytes = await File.ReadAllBytesAsync(path);

                // VRMファイルをパースしてGltfDataを取得
                var parsed = new GlbLowLevelParser(path, bytes).Parse();

                // VRMDataを作成
                var vrmData = new VRMData(parsed);

                // VRMImporterContextを作成し、usingステートメントで囲む
                using var vrmImporter = new VRMImporterContext(vrmData);

                // モデルを非同期で読み込み
                var instance = await vrmImporter.LoadAsync(new RuntimeOnlyAwaitCaller());

                // モデルのGameObjectを取得
                GameObject model = instance.Root;

                // モデルの位置を設定（例：原点に配置）
                model.transform.position = Vector3.zero;

                // モデルをアクティブ化
                model.SetActive(true);

                // 全てのRendererを有効化
                EnableAllRenderers(model);

                Debug.Log("モデルのロードと表示が完了しました。");
            }
            catch (Exception e)
            {
                Debug.LogError($"VRMの読み込みまたは表示中にエラーが発生しました: {e.Message}");

                // エラーが発生した場合、デフォルトのモデルを表示
                LoadDefaultModel();
            }
        }

        /// <summary>
        /// モデル内の全てのRendererコンポーネントを有効化する
        /// </summary>
        /// <param name="model">モデルのGameObject</param>
        private void EnableAllRenderers(GameObject model)
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

        /// <summary>
        /// デフォルトのモデルを読み込む
        /// </summary>
        private async void LoadDefaultModel()
        {
            string defaultPath = Path.Combine(Application.streamingAssetsPath, DefaultVrmFileName);

            // デフォルトのモデルの存在確認
            if (!File.Exists(defaultPath))
            {
                Debug.LogError($"デフォルトのVRMファイルが見つかりません: {defaultPath}");
                return;
            }

            try
            {
                // デフォルトのモデルを読み込み
                var bytes = await File.ReadAllBytesAsync(defaultPath);

                // VRMファイルをパースしてGltfDataを取得
                var parsed = new GlbLowLevelParser(defaultPath, bytes).Parse();

                // VRMDataを作成
                var vrmData = new VRMData(parsed);

                // VRMImporterContextを作成し、usingステートメントで囲む
                using var vrmImporter = new VRMImporterContext(vrmData);

                // モデルを非同期で読み込み
                var instance = await vrmImporter.LoadAsync(new RuntimeOnlyAwaitCaller());

                // モデルのGameObjectを取得
                GameObject model = instance.Root;

                // モデルの位置を設定（例：原点に配置）
                model.transform.position = Vector3.zero;
                
                // モデルのY軸を180度回転
                model.transform.Rotate(0, 180, 0);

                // モデルをアクティブ化
                model.SetActive(true);

                // 全てのRendererを有効化
                EnableAllRenderers(model);

                Debug.Log("デフォルトモデルのロードと表示が完了しました。");
            }
            catch (Exception e)
            {
                Debug.LogError($"デフォルトモデルの読み込みまたは表示中にエラーが発生しました: {e.Message}");
            }
        }
    }
}