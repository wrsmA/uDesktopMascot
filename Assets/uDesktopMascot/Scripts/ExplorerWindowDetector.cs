using System;
using System.Collections.Generic;
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
    public class ExplorerWindowDetector
    {
        public List<ExplorerWindowInfo> GetExplorerWindows()
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