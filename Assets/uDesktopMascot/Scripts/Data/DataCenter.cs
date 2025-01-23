using Unity.Logging;

using UnityEngine;

namespace uDesktopMascot
{
    public class DataCenter : Singleton<DataCenter>
    {
        private CharacterDataStorage _characterDataStorage;
        public CharacterDataStorage CharacterDataStorage => _characterDataStorage;

        public DataCenter()
        {
            try
            {
                Load();
            } 
            catch (System.Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public void Load()
        {
            LoadFromJson(out _characterDataStorage);
        }

        public void Save()
        {
            SaveToJson(in _characterDataStorage);
        }

        private bool LoadFromJson<T>(out T result)
            where T : new()
        {
            result = new T();
            var path = ApplicationManager.GetExeFolderPath() + $"\\savedata\\{typeof(T).Name}.json";
            try
            {
                if (System.IO.File.Exists(path))
                {
                    result = JsonUtility.FromJson<T>(System.IO.File.ReadAllText(path));
                    Log.Info($"Loaded {typeof(T).Name} from {path}");
                }
                return true;
            } 
            catch (System.Exception e)
            {
                Log.Error(e.ToString());
                return false;
            }
        }

        private bool SaveToJson<T>(in T data)
        {
            try
            {
                var path = ApplicationManager.GetExeFolderPath() + $"\\savedata\\{typeof(T).Name}.json";
                if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)))
                {
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
                }
                System.IO.File.WriteAllText(path, JsonUtility.ToJson(data));
                Log.Info($"Saved {typeof(T).Name} to {path}");
                return true;
            } 
            catch (System.Exception e)
            {
                Log.Error(e.ToString());
                return false;
            }
        }
    }
}