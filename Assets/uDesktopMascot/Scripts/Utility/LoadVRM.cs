using System;
using System.IO;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Unity.Logging;
using UniVRM10;
using Object = UnityEngine.Object;

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
        private const string DefaultVrmFileName = "DefaultModel/DefaultModel";

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
                // StreamingAssetsフォルダが存在するか確認
                if (Directory.Exists(Application.streamingAssetsPath))
                {
                    // StreamingAssetsフォルダ内のVRMファイルを検索
                    var vrmFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.vrm");
                    var userVrmFiles = vrmFiles;

                    if (userVrmFiles.Length > 0)
                    {
                        // ユーザー指定のVRMファイルを使用（最初のもの）
                        var path = userVrmFiles[0];
                        Log.Info($"ユーザー指定のVRMファイルを使用します: {path}");

                        try
                        {
                            // VRMファイルをロードしてモデルを表示
                            return await LoadAndDisplayModel(path, cancellationToken);
                        }
                        catch (Exception e)
                        {
                            Log.Error($"VRMの読み込みまたは表示中にエラーが発生しました: {e.Message}");
                            // エラーが発生した場合、デフォルトのモデルを表示
                            Log.Info("デフォルトのモデルを読み込みます。");
                            return LoadDefaultModel();
                        }
                    }

                    // ユーザー指定のVRMファイルが見つからない場合、デフォルトのモデルを使用
                    Log.Info("ユーザー指定のVRMファイルが見つかりません。デフォルトのモデルを読み込みます。");
                    return LoadDefaultModel();
                }

                // StreamingAssetsフォルダが存在しない場合、デフォルトのモデルをロード
                Log.Info("StreamingAssetsフォルダが見つかりません。デフォルトのモデルを読み込みます。");
                return LoadDefaultModel();
            }
            catch (Exception e)
            {
                Log.Error($"VRMの読み込みまたは表示中にエラーが発生しました: {e.Message}");
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
                Log.Error($"デフォルトのPrefabがResourcesフォルダに見つかりません: {DefaultVrmFileName}.prefab");
                return null;
            }

            // Prefabをインスタンス化
            var model = Object.Instantiate(prefab);

            Log.Debug("デフォルトモデルのロードと表示が完了しました: " + DefaultVrmFileName);

            return model;
        }

        /// <summary>
        /// モデルのHipボーンを探す
        /// </summary>
        /// <param name="rootTransform"></param>
        /// <returns></returns>
        public static Transform FindHipBone(Transform rootTransform)
        {
            // VRMの場合、腰のボーンは "Joints/Hips" や "Root" などの名前であることが多い
            // まずは "Hips" という名前のボーンを探します
            Transform hipTransform = rootTransform.Find("Hips");
            if (hipTransform != null)
            {
                return hipTransform;
            }

            // 見つからない場合、全ての子孫を探索します
            hipTransform = rootTransform.GetComponentsInChildren<Transform>().FirstOrDefault(t => t.name == "Hips" || t.name == "Root" || t.name == "J_Bip_C_Hips");

            return hipTransform;
        }

        /// <summary>
        /// VRMファイルを読み込み、モデルを表示する
        /// </summary>
        /// <param name="path">VRMファイルのパス</param>
        /// <param name="cancellationToken"></param>
        private static async UniTask<GameObject> LoadAndDisplayModel(string path, CancellationToken cancellationToken)
        {
            return await LoadAndDisplayModelFromPath(path,cancellationToken);
        }

        /// <summary>
        ///     バイト配列からVRMモデルをロードして表示する
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        private static async UniTask<GameObject> LoadAndDisplayModelFromPath(string path,CancellationToken cancellationToken)
        {
            // VRMファイルをロード（VRM 0.x および 1.x に対応）
            Vrm10Instance instance = await Vrm10.LoadPathAsync(path, canLoadVrm0X: true, ct: cancellationToken);

            // モデルのGameObjectを取得
            GameObject model = instance.gameObject;
            
            // シェーダーをlilToonに置き換える
            ReplaceShadersWithLilToon(model);

            Log.Info("VRMのロードと表示が完了しました: " + path);

            return model;
        }

        /// <summary>
        ///     モデル内のマテリアルのシェーダーをlilToonに置き換える
        /// </summary>
        /// <param name="model">モデルのGameObject</param>
        private static void ReplaceShadersWithLilToon(GameObject model)
        {
            // lilToonの半透明シェーダーを取得
            var lilToonTransparentShader = Shader.Find("Hidden/lilToonTransparent");

            if (lilToonTransparentShader == null)
            {
                // シェーダーが見つからない場合はエラーログを出力し、処理を続行する
                Log.Warning("lilToonのシェーダーが見つかりません。lilToonが正しくインストールされていることを確認してください。デフォルトのシェーダーを使用します。");
                // 処理を中断せず、そのままデフォルトのシェーダーを使用する
                return;
            }

            // すべてのRendererを取得
            var renderers = model.GetComponentsInChildren<Renderer>(true);

            foreach (var renderer in renderers)
            {
                // 各Rendererのマテリアルを取得
                var materials = renderer.materials;

                foreach (var material in materials)
                {
                    // シェーダーをlilToonの半透明シェーダーに置き換える
                    material.shader = lilToonTransparentShader;

                    // 必要に応じてプロパティを設定
                    material.SetFloat("_TransparentMode", 2); // 0: Opaque, 1: Cutout, 2: Transparent, etc.
                    material.SetFloat("_OutlineEnable", 1); // アウトラインを有効化
                }
            }

            Log.Info("シェーダーの置き換えが完了しました。");
        }
    }
}