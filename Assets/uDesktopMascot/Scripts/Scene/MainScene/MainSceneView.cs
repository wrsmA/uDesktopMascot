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

        private RaycastHit2D[] _hits = new RaycastHit2D[Const.MaxCharacterCount];

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

        // TODO: インタラクション系の処理は独立モジュールにする
        private CollisionInteraction[] _lastInteraction = new CollisionInteraction[Const.MaxCharacterCount];

        /// <summary>
        /// ドラッグを処理する
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ProcessDrag(InputAction.CallbackContext context)
        {
            // マウスのスクリーン座標をワールド座標に変換
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            // Raycastを発射
            var hitCount = Physics2D.RaycastNonAlloc(mousePosition, Vector2.zero, _hits, 0f, LayerMask.GetMask("Default"));

            // デバッグ用のRayをシーンビューに表示（マウス位置）
            Debug.DrawRay(mousePosition, Vector2.up * 0.1f, Color.green);

            if (hitCount > 0)
            {
                for (var i = 0; i < hitCount; ++i)
                {
                    if (_hits[i].collider.gameObject.TryGetComponent<CollisionInteraction>(out var interaction))
                    {
                        interaction.OnDrag(context);
                        _lastInteraction[i] = interaction;
                    }
                }
            } 
            else
            {
                for (var i = 0; i < Const.MaxCharacterCount; ++i)
                {
                    if (_lastInteraction[i] != null)
                    {
                        _lastInteraction[i].ResetNadeTime();
                        _lastInteraction[i] = null;
                    }
                }
            }
        }
    }
}
