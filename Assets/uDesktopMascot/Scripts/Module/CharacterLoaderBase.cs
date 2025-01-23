using Cysharp.Threading.Tasks;

namespace uDesktopMascot
{
    public abstract class CharacterLoaderBase
    {
        public abstract UniTask<CharacterControllerBase> LoadCharacterAsync(string path);
    }
}