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
            if (context.performed)
            {
                _nadeTime += Time.deltaTime;
            }
            if (context.canceled)
            {
                _nadeTime = 0.0f;
            }
            Log.Info("なでる時間: " + _nadeTime);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            Log.Info("Enter2D");
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            Log.Info("Exit2D");
        }
    }
}