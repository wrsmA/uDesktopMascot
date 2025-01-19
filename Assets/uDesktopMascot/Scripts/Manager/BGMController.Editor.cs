using NaughtyAttributes;
using UnityEngine;

#if UNITY_EDITOR

namespace uDesktopMascot
{
    /// <summary>
    ///    BGMを制御するクラス Editor拡張
    /// </summary>
    public partial class BGMController
    {
        [Button("BGMファイル登録を最新化")]
        private void UpdateBGMFiles()
        {
            bgmClips.Clear();
            var bgmFiles = Resources.LoadAll<AudioClip>("DefaultBGM");
            foreach (var bgm in bgmFiles)
            {
                bgmClips.Add(bgm);
            }
        }
    }
}
#endif
