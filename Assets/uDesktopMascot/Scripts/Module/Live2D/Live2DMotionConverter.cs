using System;
using System.IO;

using Cysharp.Threading.Tasks;

using Unity.Logging;

#if UNITY_EDITOR
using UnityEditor;
#endif // UNITY_EDITOR

#if ENABLE_LIVE2D
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework.Json;
using Live2D.Cubism.Framework.MotionFade;
using Live2D.Cubism.Framework.Pose;
#endif // ENABLE_LIVE2D

using UnityEngine;

namespace uDesktopMascot.Live2D
{
    #if ENABLE_LIVE2D
    public class Live2DMotionConverter
    {
        public static async UniTask<Animation> AttachIdleMotion(string jsonPath,GameObject model, CubismModel3Json model3Json)
        {
            if (!File.Exists(jsonPath))
            {
                Log.Error($"File not found: {jsonPath}");
                return null;

            }

            var jsonFolderPath = Path.GetDirectoryName(jsonPath);
            var vtubeJsonFilePath = FileUtility.SearchFileWithWildcard(jsonFolderPath, "*.vtube.json");

            if (string.IsNullOrEmpty(vtubeJsonFilePath))
            {
                Log.Error($"File not found: {jsonFolderPath}/*.vtube.json");
                return null;

            }

            var vtubeJsonFile = File.ReadAllText(vtubeJsonFilePath);
            var vtubeJsonStr = vtubeJsonFile.Replace("\n", "").Replace("\r", "");
            var vtubeJson = JsonUtility.FromJson<VtubeJson> (vtubeJsonStr);

            if (vtubeJson == null)
            {
                Log.Error($"Failed to parse json: {vtubeJsonFilePath}");
                return null;

            }

            var pose3json = model3Json.Pose3Json;

            var idleMotionPath = Path.Combine(jsonFolderPath, vtubeJson.FileReferences.IdleAnimation);
            Log.Info($"idleMotionPath: {idleMotionPath}");

            var idleMotionJsonStr = File.ReadAllText(idleMotionPath);
            var animationClipPath = idleMotionPath.Replace(".motion3.json", ".anim");
            animationClipPath = animationClipPath.Replace("\\", "/");
            var idleMotionJson = CubismMotion3Json.LoadFrom(idleMotionJsonStr);

            if (idleMotionJson == null)
            {
                Log.Error($"Failed to parse json: {idleMotionPath}");
                return null;
            }

            var animationClip = idleMotionJson.ToAnimationClip(false, true, true,pose3json);
            if (animationClip == null)
            {
                Log.Error($"Failed to create animation clip: {idleMotionPath}");
                return null;
            }

            animationClip.name = "Idle";

            var animation = model.GetComponent<Animation>();
            if (animation == null)
            {
                animation = model.AddComponent<Animation>();
            }

            animation.AddClip(animationClip, animationClip.name);
            animation.clip = animationClip;
            animation.playAutomatically = true;


            animation.Play("Idle");         


            return animation;
        }

        


        
    }

    [System.Serializable]
    public class VtubeJson
    {
        public FileReferenceDetails  FileReferences;

        [System.Serializable]
        public class FileReferenceDetails 
        {
            public string Icon;
            public string Model;
            public string IdleAnimation;
            public string IdleAnimationWhenTrackingLost;
        }
    }

    #endif // ENABLE_LIVE2D
}