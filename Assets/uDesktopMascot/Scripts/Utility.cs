using UnityEngine;

namespace uDesktopMascot
{
    public static class Utility
    {
        public static Vector2 GetModelScreenPosition(Camera mainCamera, Transform modelTransform)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(modelTransform.position);
            // Windowsのスクリーン座標系に合わせるため、Y座標を反転
            return new Vector2(screenPos.x, screenPos.y);
        }
    }
}