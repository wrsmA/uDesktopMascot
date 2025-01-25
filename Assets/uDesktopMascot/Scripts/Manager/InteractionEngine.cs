using System;

using UnityEngine;
using UnityEngine.InputSystem;

namespace uDesktopMascot
{
    public class InteractionEngine
    {
        private int _layerMask = 0;
        private RaycastHit2D[] _hits = new RaycastHit2D[Const.MaxCharacterCount];
        private CollisionInteraction[] _hitIntaractions = new CollisionInteraction[Const.MaxCharacterCount];
        private CollisionInteraction[] _lastInteractions = new CollisionInteraction[Const.MaxCharacterCount];

        /// <summary>
        /// レイヤーマスクを設定する
        /// </summary>
        /// <param name="layerMask"></param>
        public void SetLayerMask(int layerMask) => _layerMask = layerMask;

        /// <summary>
        /// ドラッグを処理する
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ProcessDrag(InputAction.CallbackContext context)
        {
            if (TryRaycastInteractions(_hitIntaractions))
            {
                for (var i = 0; i < Const.MaxCharacterCount; ++i)
                {
                    if (_hitIntaractions[i] != null)
                    {
                        _hitIntaractions[i].OnDrag(context);
                        _lastInteractions[i] = _hitIntaractions[i];
                    }
                }
            } 
            else
            {
                for (var i = 0; i < Const.MaxCharacterCount; ++i)
                {
                    if (_lastInteractions[i] != null)
                    {
                        _lastInteractions[i].ResetNadeTime();
                    }
                }
            }
        }

        public void ProcessClick(InputAction.CallbackContext context)
        {
            TryRaycastInteractions(_hitIntaractions);
            for (var i = 0; i < Const.MaxCharacterCount; ++i)
            {
                if (_hitIntaractions[i] != null)
                {
                    _hitIntaractions[i].OnClick(context);
                }
            }
        }

        private bool TryRaycastInteractions(CollisionInteraction[] hits)
        {
            if (hits == null) 
                throw new ArgumentNullException(nameof(hits));

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
                        hits[i] = interaction;
                    }
                }
                return true;
            } 
            else
            {
                hits = Array.Empty<CollisionInteraction>();
                return false;
            }
        }
    }
}
