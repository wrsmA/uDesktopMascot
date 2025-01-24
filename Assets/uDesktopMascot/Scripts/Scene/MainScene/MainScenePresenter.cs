using System;

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
            _input.UI.Click.performed += HandleClick;
            _input.UI.Drag.performed += HandleDrag;

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

        /// <summary>
        /// キャラクターがロードされたときの処理
        /// </summary>
        /// <param name="character"></param>
        private void HandleCharacterLoaded(CharacterControllerBase character)
        {
            _view.AddCharacter(character);
        }

        /// <summary>
        /// 既存のモデルが選択されたときの処理
        /// </summary>
        /// <param name="index"></param>
        private void HandleExistModelSelected(int index)
        {
            var data = _model.GetExistCharacters()[index];
            _model.LoadCharacterAsync(data.ModelPath, data.ModelType).Forget();
        }

        /// <summary>
        /// モデルファイルが選択されたときの処理
        /// </summary>
        /// <param name="path"></param>
        /// <param name="type"></param>
        private void HandleModelFileSelected(string path, EModelType type)
        {
            _model.LoadCharacterAsync(path, type).Forget();
        }

        /// <summary>
        /// 既存のモデルメニューを開く
        /// </summary>
        private void HandleExistModelsOpen()
        {
            var characters = _model.GetExistCharacters();
            _view.OpenExistModelsMenuAtPosition(Mouse.current.position.ReadValue(), characters);
        }

        /// <summary>
        /// 右クリックイベントを処理する
        /// </summary>
        /// <param name="context"></param>
        private void HandleRightClick(InputAction.CallbackContext context)
        {
            _view.OpenContextMenuAtPosition(Mouse.current.position.ReadValue());
        }

        /// <summary>
        /// クリックイベントを処理する
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void HandleClick(InputAction.CallbackContext context)
        {
            
        }

        /// <summary>
        /// ドラッグイベントを処理する
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void HandleDrag(InputAction.CallbackContext context)
        {
            _view.ProcessDrag(context);
        }
    }
}
