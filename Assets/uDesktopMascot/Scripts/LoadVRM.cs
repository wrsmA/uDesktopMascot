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
            // VRMファイルのパスを設定
            string path = Path.Combine(Application.streamingAssetsPath, DefaultVrmFileName);

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
                
                // y軸に180度回転させる
                model.transform.Rotate(Vector3.up, 180f);

                // モデルをアクティブ化
                model.SetActive(true);

                // 全てのRendererを有効化
                EnableAllRenderers(model);

                // 必要に応じて追加の設定
                Debug.Log("モデルのロードと表示が完了しました。");
            }
            catch (Exception e)
            {
                Debug.LogError($"VRMの読み込み中にエラーが発生しました: {e.Message}");
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
    }
}