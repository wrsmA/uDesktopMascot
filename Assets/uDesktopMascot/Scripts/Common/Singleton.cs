using Unity.Logging;
using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    ///     シングルトンパターンの基底クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object _lock = new();
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void DomainReset()
        {
            Log.Debug("[Singleton<" + typeof(T).Name + ">] DomainReset called.");
            _instance = null;
        }

        public static T Instance
        {
            get
            {
                Log.Debug("[Singleton<" + typeof(T).Name + ">] Instance getter called.");
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            Log.Debug("[Singleton<" + typeof(T).Name + ">] Creating new instance.");
                            _instance = new T();
                        }
                    }
                }
                else
                {
                    Log.Debug("[Singleton<" + typeof(T).Name + ">] Returning existing instance.");
                }
                return _instance;
            }
        }
    }
}