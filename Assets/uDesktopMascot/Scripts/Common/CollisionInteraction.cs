using Unity.Logging;

using UnityEngine;
using UnityEngine.InputSystem;

namespace uDesktopMascot
{
    [RequireComponent(typeof(Collision))]
    public class CollisionInteraction : MonoBehaviour
    {
        private float _nadeTime = 0.0f;
        public void OnDrag(InputAction.CallbackContext context)
        {
            // なでる動作かどうかを判定
            if (context.started)
            {
                _nadeTime = 0.0f;
            }
            if (context.performed)
            {
                _nadeTime += Time.deltaTime;
            }
            if (context.canceled)
            {
                _nadeTime = 0.0f;
            }
            if (_nadeTime > 1.0f)
            {
                Log.Info("なでなで");
                _nadeTime = 0.0f;
            }
        }

        public void ResetNadeTime()
        {
            _nadeTime = 0.0f;
        }
    }
}