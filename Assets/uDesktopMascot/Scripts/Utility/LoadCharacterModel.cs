using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    /// キャラクターモデルを読み込むクラス
    /// </summary>
    public static class LoadCharacterModel
    {
        /// <summary>
        /// キャラクターモデルを読み込む
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async UniTask<GameObject> LoadModel(CancellationToken cancellationToken)
        {
            // 設定ファイルからモデルパスを取得
            var modelPath = ApplicationSettings.Instance.Character.ModelPath;
            
            GameObject model = null;

            model = await LoadFBX.LoadModelAsync(modelPath, cancellationToken);
            // model = await LoadVRM.LoadModelAsync(modelPath, cancellationToken);
            
            return model;
        }
    }
}