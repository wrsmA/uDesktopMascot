using UnityEngine;
using UnityEngine.UI;

namespace uDesktopMascot
{
    /// <summary>
    ///     メニューのビュー
    /// </summary>
    public class MenuView : MonoBehaviour
    {
        /// <summary>
        ///     モデル設定ボタン
        /// </summary>
        [SerializeField] private Button modelSettingButton;

        /// <summary>
        ///     便利機能ボタン
        /// </summary>
        [SerializeField] private Button usefulButton;

        /// <summary>
        ///     AI機能ボタン
        /// </summary>
        [SerializeField] private Button aiFeatureButton;

        /// <summary>
        ///     ゲームボタン
        /// </summary>
        [SerializeField] private Button gameButton;

        /// <summary>
        ///     アプリケーション設定
        /// </summary>
        [SerializeField] private Button appSettingButton;

        /// <summary>
        ///     アプリ終了ボタン
        /// </summary>
        [SerializeField] private Button closeButton;
    }
}