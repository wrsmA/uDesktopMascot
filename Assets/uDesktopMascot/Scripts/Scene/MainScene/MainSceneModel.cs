using System;
using System.Collections.Generic;
using System.Linq;

using Cysharp.Threading.Tasks;

using uDesktopMascot.Live2D;
using uDesktopMascot.VRM;

namespace uDesktopMascot
{
    public class MainSceneModel : IDisposable
    {
        public event Action<CharacterControllerBase> CharacterLoaded;

        /// <summary>
        /// キャラクターをロードする
        /// </summary>
        /// <param name="path">ロードするファイルパス</param>
        /// <param name="type">モデルタイプ</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">対応していないタイプ</exception>
        public async UniTask LoadCharacterAsync(string path, EModelType type)
        {
            // ローダーを選択
            CharacterLoaderBase loader = type switch
            {
                EModelType.Live2D => new Live2DCharacterLoader(),
                EModelType.VRM    => new VrmCharacterLoader(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            var character = await loader.LoadCharacterAsync(path);
            if (character != null)
            {
                if (!DataCenter.Instance.CharacterDataStorage.Characters.Any(r => r.ModelPath == path))
                {
                    var data = new CharacterData(
                    Guid.NewGuid().ToString(),
                        "",
                        type,
                        path,
                        1.0f
                    );
                    DataCenter.Instance.CharacterDataStorage.Characters.Add(data);
                    DataCenter.Instance.CharacterDataStorage.LastUseCharacterId = data.Id;
                    DataCenter.Instance.Save();
                }

                CharacterLoaded?.Invoke(character);
            }
        }

        /// <summary>
        /// 最後に使用したキャラクターデータをロードする
        /// </summary>
        /// <returns></returns>
        public (string path, EModelType type) LoadLastUseCharacterData()
        {
            var id = DataCenter.Instance.CharacterDataStorage.LastUseCharacterId;
            var data = DataCenter.Instance.CharacterDataStorage.Characters.FirstOrDefault(r => r.Id == id);
            if (data == null)
            {
                // 初期設定のCharacterDataを作成
                data = new CharacterData(
                    Guid.NewGuid().ToString(),
                    "",
                    EModelType.VRM,
                    "DefaultModel/Vrm/DefaultModel",
                    1.0f
                );
            }
            return (data.ModelPath, data.ModelType);
        }

        public void Dispose()
        {
            CharacterLoaded = null;
            DataCenter.Instance.Save();
        }

        public void SaveLastUseCharacterData(string id)
        {
            DataCenter.Instance.CharacterDataStorage.LastUseCharacterId = id;
            DataCenter.Instance.Save();
        }

        public List<CharacterData> GetExistCharacters()
        {
            return DataCenter.Instance.CharacterDataStorage.Characters;
        }
    }
}
