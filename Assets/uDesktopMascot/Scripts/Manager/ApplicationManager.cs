using System;
using System.Threading;

using Cysharp.Threading.Tasks;

using Kirurobo;

using Unity.Logging;
using Unity.Logging.Sinks;

using UnityEngine;

using Logger = Unity.Logging.Logger;

namespace uDesktopMascot
{
    public class ApplicationManager : SingletonMonoBehaviour<ApplicationManager>
    {
        /// <summary>
        /// ウィンドウコントローラー
        /// </summary>
        [SerializeField]
        private UniWindowController _windowController;

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        public CancellationToken CancellationToken => _cancellationTokenSource.Token;

        private Logger _logger;
        public Logger Logger => _logger;

        private bool _isQuitting;

        private protected override void Awake()
        {
            base.Awake();

            Application.targetFrameRate = 30;
            Application.wantsToQuit += OnWantsToQuit;

            var logFilePath = $"{GetExeFolderPath()}\\log\\{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.log";
#if UNITY_EDITOR
            _logger = new Logger(new LoggerConfig()
                .WriteTo.UnityEditorConsole());
#else
            _logger = new Logger(new LoggerConfig()
                .WriteTo.File(logFilePath));
#endif
            Log.Logger = _logger;
            Log.Info("アプリケーションを起動しました。");

            ApplyWindowSettings();
            ApplyQualityLevel();
        }

        /// <summary>
        /// 終了コールバック
        /// </summary>
        /// <returns></returns>
        private bool OnWantsToQuit()
        {
            if (_isQuitting)
            {
                return true;
            }

            _isQuitting = true;
            HandleApplicationQuit(_cancellationTokenSource.Token).Forget();
            return false;
        }

        /// <summary>
        /// アプリケーションが終了するときの処理
        /// </summary>
        /// <param name="cancellationToken"></param>
        private async UniTaskVoid HandleApplicationQuit(CancellationToken cancellationToken)
        {
#if UNITY_EDITOR
            // エディタの場合、再生モードを停止
            // ref: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/EditorApplication.html
            // いろいろできそうだが、とりあえず再生モードを停止するだけにしておく
            Log.Debug("アプリケーション終了ボイスを流します。Editorの場合はボイスの再生はしません");
            await UniTask.CompletedTask;
#else
            Log.FlushAll();
            await VoiceController.Instance.PlayEndVoiceAsync(cancellationToken);
            // ビルド後のアプリケーションでは通常の終了処理
            Application.Quit();
#endif
        }

        /// <summary>
        /// 画面設定を適用
        /// </summary>
        private void ApplyWindowSettings()
        {
            var systemSettings = ApplicationSettings.Instance.Display;
            _windowController.isTopmost = systemSettings.AlwaysOnTop;
            _windowController.opacityThreshold = systemSettings.Opacity;

            Log.Info("System設定 : 常に最前面 = " + systemSettings.AlwaysOnTop + ", 不透明度 = " + systemSettings.Opacity);
        }

        /// <summary>
        /// 品質レベルを適用
        /// </summary>
        private void ApplyQualityLevel()
        {
            var performanceSettings = ApplicationSettings.Instance.Performance;

            int qualityLevel = performanceSettings.QualityLevel;
            bool isQualityLevelValid = qualityLevel >= 0 && qualityLevel < QualitySettings.names.Length;

            if (!isQualityLevelValid)
            {
                // 無効な場合、品質レベルを動的に調整
                qualityLevel = QualityLevelAdjuster.AdjustQualityLevel();
                QualitySettings.SetQualityLevel(qualityLevel, true);
                Log.Info("品質レベルをシステムスペックに基づき " + QualitySettings.names[qualityLevel] + " に設定しました。");

                // 動的に調整した値を設定に反映
                performanceSettings.QualityLevel = qualityLevel;

                // 設定ファイルを更新
                ApplicationSettings.Instance.SaveSettings();
                Log.Info("動的に調整した品質レベルを設定ファイルに保存しました。");
            } else
            {
                // 有効な場合、設定ファイルの値を使用
                QualitySettings.SetQualityLevel(qualityLevel, true);
                Log.Info("品質レベルを設定ファイルの値 " + QualitySettings.names[qualityLevel] + " に設定しました。");
            }

            // TargetFrameRateの設定（同様に処理）
            if (performanceSettings.TargetFrameRate > 0)
            {
                Application.targetFrameRate = performanceSettings.TargetFrameRate;
                Log.Info("ターゲットフレームレートを " + Application.targetFrameRate + " に設定しました。");
            } else
            {
                // 無効な場合、デフォルト値を設定し、設定ファイルを更新
                Application.targetFrameRate = 60; // デフォルト値
                performanceSettings.TargetFrameRate = 60;
                Log.Warning("無効なターゲットフレームレートが設定されていたため、デフォルト値 " + Application.targetFrameRate + " に設定しました。");
                ApplicationSettings.Instance.SaveSettings();
                Log.Info("デフォルトのターゲットフレームレートを設定ファイルに保存しました。");
            }
        }

        /// <summary>
        /// 実行中のUnity.exeのパスを取得する
        /// </summary>
        public static string GetExePath()
        {
#if UNITY_EDITOR
            return Application.dataPath;
#endif
            return System.Windows.Forms.Application.ExecutablePath;
        }

        /// <summary>
        /// 実行中のUnity.exeのフォルダパスを取得する
        /// </summary>
        /// <returns></returns>
        public static string GetExeFolderPath()
        {
            return System.IO.Path.GetDirectoryName(GetExePath());
        }
    }
}