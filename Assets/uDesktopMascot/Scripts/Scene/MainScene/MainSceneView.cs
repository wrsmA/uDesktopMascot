using System;
using System.Collections.Generic;

using Unity.Logging;

using UnityEngine;
using UnityEngine.InputSystem;

namespace uDesktopMascot
{
    public class MainSceneView : MonoBehaviour
    {
        /// <summary>
        /// コンテキストメニュー
        /// </summary>
        [SerializeField]
        private ContextMenu _contextMenu;

        /// <summary>
        /// 既存のモデルメニュー
        /// </summary>
        [SerializeField]
        private ExistModelsMenu _existModelsMenu;

        /// <summary>
        /// 表示中のキャラクター
        /// </summary>
        private List<CharacterControllerBase> _characters = new(Const.MaxCharacterCount);

        /// <summary>
        /// インタラクション処理用クラス
        /// </summary>
        private InteractionEngine _interaction = new InteractionEngine();

        public event Action<string, EModelType> ModelFileSelected;
        public event Action LoadExistsButtonClicked;
        public event Action<int> ExistModelSelected;

        private void Awake()
        {
            _interaction.SetLayerMask(LayerMask.GetMask("Default"));

            _contextMenu.FileSelected += (path, type) => ModelFileSelected?.Invoke(path, type);
            _contextMenu.LoadExistsButtonClicked += () => LoadExistsButtonClicked?.Invoke();
            _contextMenu.gameObject.SetActive(false);

            _existModelsMenu.ModelSelected += i => ExistModelSelected?.Invoke(i);
            _existModelsMenu.gameObject.SetActive(false);
        }

        public void OpenContextMenuAtPosition(Vector2 position)
        {
            _contextMenu.SetPosition(position);
            _contextMenu.gameObject.SetActive(true);
        }

        public void OpenExistModelsMenuAtPosition(Vector2 position, List<CharacterData> datas)
        {
            _existModelsMenu.SetPosition(position);
            _existModelsMenu.gameObject.SetActive(true);

            _existModelsMenu.ClearModelButtons();
            for (var i = 0; i < datas.Count; i++)
            {
                _existModelsMenu.AddModelButton(datas[i].ModelPath, i);
            }
        }

        /// <summary>
        /// 表示するキャラクターを追加する
        /// </summary>
        /// <param name="character"></param>
        public void AddCharacter(CharacterControllerBase character)
        {
            // コンテキストメニューを閉じる
            _contextMenu.gameObject.SetActive(false);
            _existModelsMenu.gameObject.SetActive(false);

            // NOTE: 現状は1体だけ表示するので全部消す
            RemoveAllCharacters();

            _characters.Add(character);
            character.Appear();
        }

        /// <summary>
        /// キャラクターを削除する
        /// </summary>
        /// <param name="character"></param>
        public void RemoveCharacter(CharacterControllerBase character)
        {
            character.Disappear();
            _characters.Remove(character);
        }

        public void RemoveAllCharacters()
        {
            foreach (var character in _characters)
            {
                character.Disappear();
            }
            _characters.Clear();
        }

        public void ProcessDrag(in InputAction.CallbackContext context) => _interaction.ProcessDrag(context);

        internal void ProcessClick(InputAction.CallbackContext context) => _interaction.ProcessClick(context);
    }
}
