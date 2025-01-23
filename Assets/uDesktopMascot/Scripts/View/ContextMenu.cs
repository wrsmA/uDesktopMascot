using System;

using UnityEngine;
using UnityEngine.UI;

using SFB;

using Button = UnityEngine.UI.Button;
using UnityEngine.Scripting;

namespace uDesktopMascot
{
    /// <summary>
    /// コンテキストメニューのView
    /// </summary>
    public class ContextMenu : MonoBehaviour
    {
        [SerializeField]
        private Transform _pivot;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private Button _loadVrmButton;

        [SerializeField]
        private Button _loadLive2DButton;

        [SerializeField]
        private Button _quitAppButton;

        public event Action<string, CharacterType> FileSelected;

        public void SetPosition(Vector2 position)
        {
            _pivot.position = position;
        }

        private void Awake()
        {
            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
            _loadVrmButton.onClick.AddListener(OnClickLoadVrmButton);
            _loadLive2DButton.onClick.AddListener(OnClickLoadLive2DButton);
            _quitAppButton.onClick.AddListener(OnClickQuitApplication);

#if !ENABLE_LIVE2D
            _loadLive2DButton.gameObject.SetActive(false);
#endif
        }

        private void OnClickLoadVrmButton()
        {
            var dialog = StandaloneFileBrowser.OpenFilePanel("VRMファイルを開く", "", "vrm", false);
            if (dialog.Length == 0)
            {
                return;
            }

            FileSelected?.Invoke(dialog[0], CharacterType.VRM);
        }

        private void OnClickLoadLive2DButton()
        {
            var dialog = StandaloneFileBrowser.OpenFilePanel("Live2Dモデルを開く", "", "json", false);
            if (dialog.Length == 0)
            {
                return;
            }

            // "\" to "/"
            dialog[0] = dialog[0].Replace("\\", "/");

            // Assets/以下のパスに変換
            dialog[0] = dialog[0].Replace(Application.dataPath, "Assets");
            FileSelected?.Invoke(dialog[0], CharacterType.Live2D);
        }

        private void OnClickQuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}