using System;

using Newtonsoft.Json;

namespace uDesktopMascot
{
    /// <summary>
    /// キャラクターごとの設定値
    /// </summary>
    [Serializable]
    public class CharacterData
    {
        public string Id;
        public string DisplayName;
        public EModelType ModelType;
        public string ModelPath;
        public float Scale = 1.0f;

        public CharacterData(string id, string displayName, EModelType modelType, string modelPath, float scale)
        {
            Id = id;
            DisplayName = displayName;
            ModelType = modelType;
            ModelPath = modelPath;
            Scale = scale;
        }
    }
}