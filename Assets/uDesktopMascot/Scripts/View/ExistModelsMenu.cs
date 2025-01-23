using System;

using UnityEngine;

using Button = UnityEngine.UI.Button;

namespace uDesktopMascot
{
    public class ExistModelsMenu : MonoBehaviour
    {
        [SerializeField]
        private Transform _pivot;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private Transform _buttonContainer;

        [SerializeField]
        private ModelButton _buttonPrefab;

        public event Action<int> ModelSelected;

        private void Awake()
        {
            _closeButton.onClick.AddListener(() => gameObject.SetActive(false));
        }

        public void AddModelButton(string modelName, int index)
        {
            var button = Instantiate(_buttonPrefab, _buttonContainer);
            button.SetText(modelName);
            button.Clicked += () => ModelSelected?.Invoke(index);
        }

        public void ClearModelButtons()
        {
            foreach (Transform child in _buttonContainer)
            {
                Destroy(child.gameObject);
            }
        }

        public void SetPosition(Vector2 position)
        {
            _pivot.position = position;
        }
    }
}