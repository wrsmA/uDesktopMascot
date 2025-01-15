using Unity.Logging;
using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    ///     システムマネージャー
    /// </summary>
    public class SystemManager : SingletonMonoBehaviour<SystemManager>
    {
        private protected override void Awake()
        {
            base.Awake();

            // PCのスペック応じてQualitySettingsを変更
            SetQualityLevel();
        }

        /// <summary>
        ///     品質レベルを設定
        /// </summary>
        private void SetQualityLevel()
        {
            // PCのスペック応じて品質レベルを調整
            var qualityLevel = QualityLevelAdjuster.AdjustQualityLevel();
            qualityLevel = Mathf.Clamp(qualityLevel, 0, QualitySettings.names.Length - 1);

            // 品質レベルを設定
            QualitySettings.SetQualityLevel(qualityLevel, true);

            // ログ出力
            Log.Debug("品質レベルを " + QualitySettings.names[qualityLevel] + " に設定しました。");
        }
    }
}