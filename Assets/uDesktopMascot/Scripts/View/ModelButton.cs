using System;

using UnityEngine;

using Button = UnityEngine.UI.Button;
using TMPro;

namespace uDesktopMascot
{
    public class ModelButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;

        [SerializeField]
        private TextMeshProUGUI _text;

        public event Action Clicked;

        private void Awake()
        {
            _button.onClick.AddListener(() => Clicked?.Invoke());
        }

        public void SetText(string text)
        {
            _text.SetText(text);
        }
    }
}