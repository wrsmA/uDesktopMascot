using Unity.Logging;
using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    ///     品質レベルを調整するクラス
    /// </summary>
    public static class QualityLevelAdjuster
    {
        /// <summary>
        ///     品質レベルを調整
        /// </summary>
        /// <returns></returns>
        public static int AdjustQualityLevel()
        {
            var qualityLevel = 0; // デフォルトの品質レベルを最低に設定

            // CPUの評価
            if (SystemInfo.processorFrequency >= 3000 && SystemInfo.processorCount >= 4)
            {
                qualityLevel += 1;
            }

            // メモリの評価
            if (SystemInfo.systemMemorySize >= 8000)
            {
                qualityLevel += 1;
            }

            // GPUの評価
            if (SystemInfo.graphicsMemorySize >= 2048 && SystemInfo.graphicsShaderLevel >= 35)
            {
                qualityLevel += 1;
            }

            // 品質レベルの上限を設定
            qualityLevel = Mathf.Clamp(qualityLevel, 0, QualitySettings.names.Length - 1);

            // 品質レベルを設定
            QualitySettings.SetQualityLevel(qualityLevel, true);

            Log.Debug("品質レベルを " + QualitySettings.names[qualityLevel] + " に設定しました。");

            // 必要に応じて品質レベルを返す
            return qualityLevel;
        }
    }
}