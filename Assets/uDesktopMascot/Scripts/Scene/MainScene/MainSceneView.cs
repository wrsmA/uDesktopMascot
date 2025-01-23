using System;
using System.Collections.Generic;

using UnityEngine;

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

        public event Action<string, EModelType> ModelFileSelected;
        public event Action LoadExistsButtonClicked;
        public event Action<int> ExistModelSelected;

        private void Awake()
        {
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

        public void AddCharacter(CharacterControllerBase character)
        {
            // コンテキストメニューを閉じる
            _contextMenu.gameObject.SetActive(false);

            // NOTE: 現状は1体だけ表示するので全部消す
            RemoveAllCharacters();

            _characters.Add(character);
            character.Appear();
        }

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
    }
}
