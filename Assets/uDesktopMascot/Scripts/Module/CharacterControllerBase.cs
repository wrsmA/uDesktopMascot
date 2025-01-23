using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    /// 画面上のキャラクターを制御するための基底クラス
    /// </summary>
    public abstract class CharacterControllerBase : MonoBehaviour
    {
        /// <summary>
        /// キャラクターを登場させる
        /// </summary>
        public virtual void Appear()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// キャラクターを退場させる
        /// </summary>
        public virtual void Disappear()
        {
            gameObject.SetActive(false);
        }
    }
}