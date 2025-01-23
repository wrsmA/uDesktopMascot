using System;
using System.Windows.Forms;

using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.InputSystem;

namespace uDesktopMascot
{

    public class MainScenePresenter : MonoBehaviour
    {
        [SerializeField]
        private MainSceneView _view;

        private MainSceneModel _model;
        private UDMInputActions _input;

        private void Awake()
        {
            _model = new MainSceneModel();
            _input = new UDMInputActions();

            // input
            _input.UI.RightClick.performed += HandleRightClick;
            _input.Enable();

            // model
            _model.CharacterLoaded += HandleCharacterLoaded;

            // view
            _view.ModelFileSelected += HandleModelFileSelected;
            _view.LoadExistsButtonClicked += HandleExistModelsOpen;
            _view.ExistModelSelected += HandleExistModelSelected;

            var lastUseCharacterData = _model.LoadLastUseCharacterData();
            _model.LoadCharacterAsync(lastUseCharacterData.path, lastUseCharacterData.type).Forget();
        }

        private void OnDestroy()
        {
            _input.Dispose();
            _model.Dispose();
        }

        private void HandleCharacterLoaded(CharacterControllerBase character)
        {
            _view.AddCharacter(character);
        }

        private void HandleExistModelSelected(int index)
        {
            var data = _model.GetExistCharacters()[index];
            _model.LoadCharacterAsync(data.ModelPath, data.ModelType).Forget();
        }

        private void HandleRightClick(InputAction.CallbackContext context)
        {
            _view.OpenContextMenuAtPosition(Mouse.current.position.ReadValue());
        }

        private void HandleModelFileSelected(string path, EModelType type)
        {
            _model.LoadCharacterAsync(path, type).Forget();
        }

        private void HandleExistModelsOpen()
        {
            var characters = _model.GetExistCharacters();
            _view.OpenExistModelsMenuAtPosition(Mouse.current.position.ReadValue(), characters);
        }
    }
}
