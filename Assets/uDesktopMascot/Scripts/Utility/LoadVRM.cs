using System;
using System.IO;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Unity.Logging;
using UniGLTF;
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
            if (animator == null)
            {
                Log.Error("Animator が null です。アニメーションコントローラーを設定できません。");
                return;
            }

            var controller = Resources.Load<RuntimeAnimatorController>("CharacterAnimationController");
            if (controller != null)
            {
                animator.runtimeAnimatorController = controller;
                Log.Info("アニメーションコントローラーを設定しました。");

                if (animator.avatar == null)
                {
                    Log.Warning("Animator の avatar が設定されていません。アニメーションが正しく再生されない可能性があります。");
                }
            }
            else
            {
                Log.Error("CharacterAnimationController が Resources に見つかりませんでした。アニメーションコントローラーが正しく設定されているか確認してください。");
            }
        }

        /// <summary>
        /// モデルをロードする
        /// </summary>
        public static async UniTask<GameObject> LoadModel(CancellationToken cancellationToken)
        {
            try
            {
                GameObject model = null;

                // 設定ファイルからモデルパスを取得
                var modelPath = ApplicationSettings.Instance.Character.ModelPath;

                if (!string.IsNullOrEmpty(modelPath))
                {
                    Log.Info($"指定されたモデルパス: {modelPath}");

                    // StreamingAssets フォルダ内のフルパスを作成
                    var fullModelPath = Path.Combine(Application.streamingAssetsPath, modelPath);

                    // モデルファイルが存在するか確認
                    if (File.Exists(fullModelPath))
                    {
                        Log.Info($"指定されたモデルファイルをロードします: {modelPath}");
                        // 指定されたモデルをロード
                        model = await LoadAndDisplayModel(fullModelPath, cancellationToken);
                    }
                    else
                    {
                        Log.Warning($"指定されたモデルファイルが見つかりませんでした: {modelPath}");
                        // この後、他のモデルファイルを探します
                    }
                }
                else
                {
                    Log.Info("モデルパスが指定されていません。");
                    // この後、他のモデルファイルを探します
                }

                // モデルがまだロードされていない場合、他の VRM/GLB ファイルを検索
                if (model == null)
                {
                    // StreamingAssets フォルダが存在するか確認
                    if (Directory.Exists(Application.streamingAssetsPath))
                    {
                        // 他の VRM/GLB ファイルを検索
                        var modelFiles = Directory.GetFiles(Application.streamingAssetsPath, "*.*", SearchOption.AllDirectories)
                            .Where(s => s.EndsWith(".vrm", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".glb", StringComparison.OrdinalIgnoreCase))
                            .ToArray();

                        if (modelFiles.Length > 0)
                        {
                            // 最初のモデルファイルを使用
                            var otherModelPath = modelFiles[0];
                            Log.Info($"他のモデルファイルを見つけましたのでロードします: {Path.GetFileName(otherModelPath)}");
                            model = await LoadAndDisplayModel(otherModelPath, cancellationToken);
                        }
                        else
                        {
                            Log.Warning("他の VRM/GLB ファイルが見つかりません。デフォルトのモデルを読み込みます。");
                            // デフォルトのモデルをロード
                            model = LoadDefaultModel();
                        }
                    }
                    else
                    {
                        Log.Warning("StreamingAssets フォルダが見つかりません。デフォルトのモデルを読み込みます。");
                        // デフォルトのモデルをロード
                        model = LoadDefaultModel();
                    }
                }

                if (model != null)
                {
                    Log.Info("モデルのロードと表示が完了しました。");
                }
                else
                {
                    Log.Error("モデルのロードに失敗しました。");
                }

                return model;
            }
            catch (Exception e)
            {
                Log.Error($"モデルの読み込みまたは表示中にエラーが発生しました: {e.Message}");
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
        /// VRMファイルを読み込み、モデルを表示する
        /// </summary>
        /// <param name="path">VRMファイルのパス</param>
        /// <param name="cancellationToken"></param>
        private static async UniTask<GameObject> LoadAndDisplayModel(string path, CancellationToken cancellationToken)
        {
            return await LoadAndDisplayModelFromPath(path, cancellationToken);
        }

        /// <summary>
        /// ファイルパスからモデルをロードして表示する
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async UniTask<GameObject> LoadAndDisplayModelFromPath(string path, CancellationToken cancellationToken)
        {
            // ファイルの拡張子を取得
            var extension = Path.GetExtension(path).ToLowerInvariant();

            GameObject model = null;

            if (extension == ".vrm")
            {
                // VRMファイルをロード（VRM 0.x および 1.x に対応）
                Vrm10Instance instance = await Vrm10.LoadPathAsync(path, canLoadVrm0X: true, ct: cancellationToken);

                // モデルのGameObjectを取得
                model = instance.gameObject;
            }
            else if (extension == ".glb")
            {
                // GLBファイルをロード
                model = await LoadGlbModelAsync(path, cancellationToken);
            }
            else
            {
                Log.Error($"サポートされていないファイル形式です: {extension}");
                return null;
            }

            if (model == null)
            {
                Log.Error("モデルのロードに失敗しました。");
                return null;
            }

            // シェーダーをlilToonに置き換える
            bool shaderReplaceSuccess = ReplaceShadersWithLilToon(model);

            if (!shaderReplaceSuccess)
            {
                Log.Warning("シェーダーの置き換えに失敗したため、デフォルトのシェーダーを使用します。");
            }

            Log.Info("モデルのロードと表示が完了しました: " + path);

            return model;
        }

        /// <summary>
        /// GLBファイルをロードしてモデルを取得
        /// </summary>
        /// <param name="path"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private static async UniTask<GameObject> LoadGlbModelAsync(string path, CancellationToken cancellationToken)
        {
            try
            {
                // GLBファイルをパースする
                var parser = new GlbFileParser(path);
                using var gltfData = parser.Parse();

                // ImporterContextを作成
                var importer = new ImporterContext(gltfData);

                // IAwaitCallerを作成（ImmediateCallerWithCancellationを使用して、CancellationTokenを渡す）
                var awaitCaller = new ImmediateCallerWithCancellation(cancellationToken);

                // モデルを非同期でロード
                var gltfInstance = await importer.LoadAsync(awaitCaller);

                // 必要に応じてメッシュを表示
                gltfInstance.ShowMeshes();

                // ルートのGameObjectを取得
                var model = gltfInstance.gameObject;

                return model;
            }
            catch (OperationCanceledException)
            {
                Log.Warning("GLBモデルのロードがキャンセルされました。");
                return null;
            }
            catch (Exception e)
            {
                Log.Error($"GLBモデルのロード中にエラーが発生しました: {e.Message}");
                return null;
            }
        }

        /// <summary>
        /// モデルのシェーダーをlilToonに置き換える
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private static bool ReplaceShadersWithLilToon(GameObject model)
        {
            try
            {
                // lilToonの半透明シェーダーを取得
                var lilToonTransparentShader = Shader.Find("Hidden/lilToonTransparent");

                if (lilToonTransparentShader == null)
                {
                    Log.Warning("lilToonのTransparentシェーダーが見つかりません。シェーダー名を確認してください。");
                    return false;
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
                return true;
            }
            catch (Exception e)
            {
                Log.Error($"シェーダーの置き換え中にエラーが発生しました: {e.Message}");
                return false;
            }
        }
    }
}