using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    /// キャラクターごとに保存する設定値
    /// </summary>
    public class CharacterConfig : ScriptableObject
    {
        public CharacterType characterType;
        public string modelPath;
        public float scale = 1.0f;
    }
}