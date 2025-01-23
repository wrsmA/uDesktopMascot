using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    /// アプリケーションが保有するキャラクターデータ
    /// </summary>
    [Serializable]
    public class CharacterDataStorage
    {
        public List<CharacterData> Characters = new();
        public string LastUseCharacterId = string.Empty;
    }
}