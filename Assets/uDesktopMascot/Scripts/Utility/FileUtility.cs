using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    ///     ファイル操作に関するユーティリティクラス
    /// </summary>
    public static class FileUtility
    {
        public static string SearchFileWithWildcard(string path, string fileNameWithWildcard)
        {
            var files = System.IO.Directory.GetFiles(path, fileNameWithWildcard);
            if (files.Length == 0)
            {
                return null;
            }

            return files[0];
        }

        public static string[] SearchAllFileWithWildcard(string path, string fileNameWithWildcard)
        {
            var files = System.IO.Directory.GetFiles(path, fileNameWithWildcard);
            if (files.Length == 0)
            {
                return null;
            }

            return files;
        }

    }
}