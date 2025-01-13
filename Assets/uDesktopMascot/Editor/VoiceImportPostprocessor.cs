using UnityEditor;
using UnityEngine;

namespace uDesktopMascot.Editor
{
    /// <summary>
    ///     ボイスファイルのインポート時に設定を変更するためのクラス
    /// </summary>
    public class VoiceImportPostprocessor : AssetPostprocessor
    {
        private void OnPreprocessAudio()
        {
            // ターゲットフォルダのパス
            var targetFolder = "Assets/uDesktopMascot/Resources/DefaultVoice/";

            // アセットが指定フォルダ内にある場合
            if (assetPath.Contains(targetFolder))
            {
                var audioImporter = (AudioImporter)assetImporter;

                // デフォルトのサンプル設定を取得
                var sampleSettings = audioImporter.defaultSampleSettings;

                // Load TypeをCompressed In Memoryに設定
                sampleSettings.loadType = AudioClipLoadType.CompressedInMemory;
                // Compression FormatをADPCMに設定
                sampleSettings.compressionFormat = AudioCompressionFormat.ADPCM;
                // Preload Audio Dataを有効に設定
                sampleSettings.preloadAudioData = true;

                // 変更した設定を適用
                audioImporter.defaultSampleSettings = sampleSettings;

                // 必要に応じてプラットフォームごとの設定も変更可能
                // 以下の例では、すべてのプラットフォームで同じ設定を適用しています
                var platforms = new[] { "Standalone", "Android", "iOS" };
                foreach (var platform in platforms)
                {
                    audioImporter.SetOverrideSampleSettings(platform, sampleSettings);
                }
            }
        }
    }
}