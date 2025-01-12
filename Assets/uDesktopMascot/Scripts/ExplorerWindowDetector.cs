#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace uDesktopMascot
{
    /// <summary>
    /// エクスプローラーウィンドウの情報
    /// </summary>
    public class ExplorerWindowInfo
    {
        public WindowsAPI.RECT rect;
        public IntPtr hWnd;
    }

    /// <summary>
    /// エクスプローラーウィンドウを検出するクラス
    /// </summary>
    public static class ExplorerWindowDetector
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        /// <summary>
        /// ロジックスピクセルのX方向の値
        /// </summary>
        private const int LOGPIXELSX = 88;
        
        /// <summary>
        /// ロジックスピクセルのY方向の値
        /// </summary>
        private const int LOGPIXELSY = 90;

        /// <summary>
        /// DPIスケールを取得
        /// </summary>
        /// <returns></returns>
        public static float GetDPIScale()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            int dpiX = GetDeviceCaps(hdc, LOGPIXELSX);
            int dpiY = GetDeviceCaps(hdc, LOGPIXELSY);

            float dpiScaleX = dpiX / 96.0f;
            float dpiScaleY = dpiY / 96.0f;

            return (dpiScaleX + dpiScaleY) / 2.0f;
        }
        public static List<ExplorerWindowInfo> GetExplorerWindows()
        {
            List<ExplorerWindowInfo> explorerWindows = new List<ExplorerWindowInfo>();
        
            WindowsAPI.EnumWindows(delegate(IntPtr hWnd, IntPtr lParam)
            {
                if (WindowsAPI.IsWindowVisible(hWnd))
                {
                    StringBuilder className = new StringBuilder(256);
                    WindowsAPI.GetClassName(hWnd, className, className.Capacity);
                
                    // エクスプローラーウィンドウのクラス名は "CabinetWClass" または "ExploreWClass"
                    if (className.ToString() == "CabinetWClass" || className.ToString() == "ExploreWClass")
                    {
                        WindowsAPI.RECT rect;
                        if (WindowsAPI.GetWindowRect(hWnd, out rect))
                        {
                            ExplorerWindowInfo info = new ExplorerWindowInfo
                            {
                                hWnd = hWnd,
                                rect = rect
                            };
                        
                            explorerWindows.Add(info);
                        }
                    }
                }
                return true;
            }, IntPtr.Zero);
        
            return explorerWindows;
        }
    }
}
#endif
