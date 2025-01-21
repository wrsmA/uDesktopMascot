using System;
using System.IO;

using Cysharp.Threading.Tasks;

using Unity.Logging;

#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR

#if ENABLE_LIVE2D
using Live2D.Cubism.Framework.Json;
#endif // ENABLE_LIVE2D

using UnityEngine;

namespace uDesktopMascot.Live2D
{
    public class Live2DCharacterLoader : CharacterLoaderBase
    {
        // FIXME: 外部に持つ
        private const string DefaultModelPath = "DefaultModel/Live2D/wara/wara.model3";

        public override async UniTask<CharacterControllerBase> LoadCharacterAsync(string path)
        {
#if ENABLE_LIVE2D
            Log.Info($"Live2Dモデルの読み込み開始: {path}");
            try
            {
                var model3Json = CubismModel3Json.LoadAtPath(path, BuiltinLoadAssetAtPath);
                if (model3Json == null)
                {
                    Log.Error("Live2Dモデルの読み込みに失敗しました: model3Jsonが見つかりません");
                    return null;
                }
                var model = model3Json.ToModel();
                if (model == null)
                {
                    Log.Error("Live2Dモデルの読み込みに失敗しました: ToModelに失敗しました");
                    return null;
                }

                var container = new GameObject("ModelContainer");
                model.transform.SetParent(container.transform, false);

                var controller = container.AddComponent<Live2DCharacterController>();
                if (controller == null)
                {
                    controller = container.AddComponent<Live2DCharacterController>();
                }

                container.transform.localScale = Vector3.one * 11.0f;
                return controller;

            } 
            catch (Exception e)
            {
                Log.Error($"Live2Dモデルの読み込みに失敗しました: {e.Message}");
                return null;
            }
#else
            throw new System.NotImplementedException();
#endif // ENABLE_LIVE2D


            static string handler(Type _, string json)
            {
                return json;
            }
        }

        /// <summary>
        /// Builtin method for loading assets.
        /// </summary>
        /// <param name="assetType">Asset type.</param>
        /// <param name="assetPath">Path to asset.</param>
        /// <returns>The asset on success; <see langword="null"/> otherwise.</returns>
        private static object BuiltinLoadAssetAtPath(Type assetType, string assetPath)
        {
            Log.Info($"Loading asset at path: {assetPath}.");
            // Explicitly deal with byte arrays.
            if (assetType == typeof(byte[]))
            {
                return File.ReadAllBytes(assetPath);
            } else if (assetType == typeof(string))
            {
                return File.ReadAllText(assetPath);
            } else if (assetType == typeof(Texture2D))
            {
                if (!File.Exists(assetPath))
                {
                    Debug.LogError($"File not found: {assetPath}");
                    return null;
                }

                byte[] fileData = File.ReadAllBytes(assetPath);
                Texture2D texture = new Texture2D(2, 2);
                if (texture.LoadImage(fileData))
                {
                    texture.Apply();
                    return texture;
                }

                Debug.LogError("Failed to load texture.");
                return null;
            }


#if UNITY_EDITOR
            return AssetDatabase.LoadAssetAtPath(assetPath, assetType);
#else
            return Resources.Load(assetPath, assetType);
#endif
        }
    }
}