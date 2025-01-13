using System.IO;
using Unity.Logging;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class PostBuildProcessor
{
    /// <summary>
    ///     ビルド後SteamAssetsフォルダを生成する
    /// </summary>
    /// <param name="target"></param>
    /// <param name="pathToBuiltProject"></param>
    [PostProcessBuild(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        // ビルドされたプロジェクトのディレクトリを取得
        var buildDirectory = Path.GetDirectoryName(pathToBuiltProject);
        if (string.IsNullOrEmpty(buildDirectory))
        {
            Log.Error("ビルドされたプロジェクトのディレクトリが取得できませんでした。");
            return;
        }

        var appName = Path.GetFileNameWithoutExtension(pathToBuiltProject);

        var streamingAssetsPath = "";

        if (target == BuildTarget.StandaloneWindows || target == BuildTarget.StandaloneWindows64 ||
            target == BuildTarget.StandaloneLinux64)
        {
            // Windows および Linux の場合
            streamingAssetsPath = Path.Combine(buildDirectory, $"{appName}_Data", "StreamingAssets");
        } else if (target == BuildTarget.StandaloneOSX)
        {
            // macOS の場合
            streamingAssetsPath = Path.Combine(buildDirectory, $"{appName}.app", "Contents", "Resources", "Data",
                "StreamingAssets");
        } else
        {
            Debug.LogWarning("このプラットフォームはサポートされていません: " + target);
            return;
        }

        // StreamingAssets フォルダが存在しない場合は作成
        if (!Directory.Exists(streamingAssetsPath))
        {
            Directory.CreateDirectory(streamingAssetsPath);
        }

        // Voice/Click フォルダを作成
        var clickVoicePath = Path.Combine(streamingAssetsPath, "Voice", "Click");
        if (!Directory.Exists(clickVoicePath))
        {
            Directory.CreateDirectory(clickVoicePath);
        }

        // Voice/Drag フォルダを作成（または Voice/Hold フォルダ）
        var dragVoicePath = Path.Combine(streamingAssetsPath, "Voice", "Drag");
        if (!Directory.Exists(dragVoicePath))
        {
            Directory.CreateDirectory(dragVoicePath);
        }

        // ログ出力（必要に応じて）
        Log.Debug("ビルド後処理が完了しました。必要なフォルダを生成しました。");
    }
}