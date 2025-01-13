using System;
using System.IO;
using System.IO.Compression;
using Unity.Logging;
using UnityEditor;
using UnityEditor.Callbacks;

namespace uDesktopMascot.Editor
{
    public class PostBuildProcessor
    {
        /// <summary>
        ///     ビルド後の処理を行う
        /// </summary>
        /// <param name="target">ビルドターゲット</param>
        /// <param name="pathToBuiltProject">ビルドされたプロジェクトのパス</param>
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

            // プラットフォームに応じた StreamingAssets のパスを取得
            var streamingAssetsPath = GetStreamingAssetsPath(target, buildDirectory, pathToBuiltProject);
            if (string.IsNullOrEmpty(streamingAssetsPath))
            {
                Log.Warning("このプラットフォームはサポートされていません: " + target);
                return;
            }

            // 必要なフォルダを作成
            CreateNecessaryDirectories(streamingAssetsPath);

            // ビルドフォルダを ZIP 圧縮（最大圧縮）
            CreateMaxCompressedZipOfBuildFolder(buildDirectory, pathToBuiltProject);

            Log.Debug("ビルド後処理が完了しました。");
        }

        /// <summary>
        ///     プラットフォームに応じた StreamingAssets のパスを取得する
        /// </summary>
        /// <param name="target">ビルドターゲット</param>
        /// <param name="buildDirectory">ビルドディレクトリのパス</param>
        /// <param name="pathToBuiltProject">ビルドされたプロジェクトのパス</param>
        /// <returns>StreamingAssets のフルパス</returns>
        private static string GetStreamingAssetsPath(BuildTarget target, string buildDirectory,
            string pathToBuiltProject)
        {
            var appName = Path.GetFileNameWithoutExtension(pathToBuiltProject);

            return target switch
            {
                BuildTarget.StandaloneWindows or BuildTarget.StandaloneWindows64 or BuildTarget.StandaloneLinux64 =>
                    // Windows および Linux の場合
                    Path.Combine(buildDirectory, $"{appName}_Data", "StreamingAssets"),
                BuildTarget.StandaloneOSX =>
                    // macOS の場合
                    Path.Combine(buildDirectory, $"{appName}.app", "Contents", "Resources", "Data", "StreamingAssets"),
                _ => null
            };
        }

        /// <summary>
        ///     必要なフォルダを作成する
        /// </summary>
        /// <param name="streamingAssetsPath">StreamingAssets のフルパス</param>
        private static void CreateNecessaryDirectories(string streamingAssetsPath)
        {
            // StreamingAssets フォルダが存在しない場合は作成
            if (!Directory.Exists(streamingAssetsPath))
            {
                Directory.CreateDirectory(streamingAssetsPath);
                Log.Debug($"StreamingAssets フォルダを作成しました: {streamingAssetsPath}");
            }

            // Voice/Click フォルダを作成
            var clickVoicePath = Path.Combine(streamingAssetsPath, "Voice", "Click");
            if (!Directory.Exists(clickVoicePath))
            {
                Directory.CreateDirectory(clickVoicePath);
                Log.Debug($"Voice/Click フォルダを作成しました: {clickVoicePath}");
            }

            // Voice/Drag フォルダを作成（または Voice/Hold フォルダ）
            var dragVoicePath = Path.Combine(streamingAssetsPath, "Voice", "Drag");
            if (!Directory.Exists(dragVoicePath))
            {
                Directory.CreateDirectory(dragVoicePath);
                Log.Debug($"Voice/Drag フォルダを作成しました: {dragVoicePath}");
            }
        }

        /// <summary>
        ///     ビルドフォルダを最大圧縮で ZIP 圧縮する
        /// </summary>
        /// <param name="buildDirectory">ビルドディレクトリのパス</param>
        /// <param name="pathToBuiltProject">ビルドされたプロジェクトのパス</param>
        private static void CreateMaxCompressedZipOfBuildFolder(string buildDirectory, string pathToBuiltProject)
        {
            try
            {
                var appName = Path.GetFileNameWithoutExtension(pathToBuiltProject);

                // ビルドフォルダのパス
                var buildFolderPath = buildDirectory;

                // ビルドフォルダの親ディレクトリのパス（ZIP ファイルの保存先）
                var parentInfo = Directory.GetParent(buildFolderPath);
                if (parentInfo == null)
                {
                    Log.Error("ビルドフォルダの親ディレクトリが取得できませんでした。");
                    return;
                }

                var parentDirectory = parentInfo.FullName;

                // ZIP ファイルの保存先（親ディレクトリに {appName}.zip として保存）
                var zipFilePath = Path.Combine(parentDirectory, $"{appName}.zip");

                // 既存の ZIP ファイルを削除
                if (File.Exists(zipFilePath))
                {
                    File.Delete(zipFilePath);
                    Log.Debug($"既存の ZIP ファイルを削除しました: {zipFilePath}");
                }

                // フォルダを最大圧縮で ZIP 圧縮
                CompressDirectory(buildFolderPath, zipFilePath, CompressionLevel.Optimal);

                Log.Debug($"ビルドフォルダを最大圧縮で ZIP 圧縮しました: {zipFilePath}");
            } catch (Exception ex)
            {
                Log.Error($"ビルドフォルダの ZIP 圧縮中にエラーが発生しました: {ex.Message}");
            }
        }

        /// <summary>
        ///     ディレクトリを最大圧縮で ZIP 圧縮する
        /// </summary>
        /// <param name="sourceDir">圧縮するフォルダのパス</param>
        /// <param name="zipFilePath">出力先の ZIP ファイルのパス</param>
        /// <param name="compressionLevel">圧縮レベル</param>
        private static void CompressDirectory(string sourceDir, string zipFilePath, CompressionLevel compressionLevel)
        {
            // ZIP 圧縮を開始
            using var zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create);
            var files = Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                // ファイルの相対パスを取得
                var relativePath = Path.GetRelativePath(sourceDir, file);

                // ZIP エントリとして追加
                zipArchive.CreateEntryFromFile(file, relativePath, compressionLevel);
            }
        }
    }
}