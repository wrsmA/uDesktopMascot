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
using Live2D.Cubism.Framework.Motion;
using Live2D.Cubism.Framework.MotionFade;
using Live2D.Cubism.Framework.Pose;
#endif // ENABLE_LIVE2D

using UnityEngine;

namespace uDesktopMascot.Live2D
{
    #if ENABLE_LIVE2D
    public class Live2DMotionConverter
    {
        public static async UniTask<Animator> AttachIdleMotion(string jsonPath,GameObject model, CubismModel3Json model3Json)
        {
            if (!File.Exists(jsonPath))
            {
                Log.Error($"File not found: {jsonPath}");
                return null;
            }

            var model3JsonMotions = model3Json.FileReferences.Motions;
            Log.Info($"model3JsonMotions: {model3JsonMotions}");
            var motionNames = model3JsonMotions.GroupNames;
            Log.Info($"motionNames: {motionNames}");

            var idleMotion = "";
            var pose3json = model3Json.Pose3Json;
            var jsonFolderPath = Path.GetDirectoryName(jsonPath);

            if (motionNames.Length > 0)
            {
                var idleMotionIndex = Array.IndexOf(motionNames, "Idle");
                var idleMotionName = motionNames[idleMotionIndex];
                var idleMotions = model3JsonMotions.Motions[idleMotionIndex];
                idleMotion = idleMotions[0].File;
            }
            else
            {
                Log.Info($"idleMotion: {idleMotion}");
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
                idleMotion = vtubeJson.FileReferences.IdleAnimation;
            }


            var idleMotionPath = Path.Combine(jsonFolderPath, idleMotion);
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

            var cubismFadeMotionData = CubismFadeMotionData.CreateInstance(idleMotionJson,"Idle",animationClip.length, false, true);
            AssetDatabase.CreateAsset(cubismFadeMotionData, "Assets/Idle.fade.asset");

            var cubismFadeMotionDataInstanceId = cubismFadeMotionData.GetInstanceID();

            var fadeMotions = ScriptableObject.CreateInstance<CubismFadeMotionList>();
            fadeMotions.MotionInstanceIds = new int[0];
            fadeMotions.CubismFadeMotionObjects = new CubismFadeMotionData[0];
            AssetDatabase.CreateAsset(fadeMotions, "Assets/Idle.fadeMotionList.asset");

            var motionIndex = fadeMotions.CubismFadeMotionObjects.Length;
            Array.Resize(ref fadeMotions.MotionInstanceIds, motionIndex+1);
            fadeMotions.MotionInstanceIds[motionIndex] = cubismFadeMotionDataInstanceId;
            Array.Resize(ref fadeMotions.CubismFadeMotionObjects, motionIndex+1);
            fadeMotions.CubismFadeMotionObjects[motionIndex] = cubismFadeMotionData;

            var animator = model.GetComponent<Animator>();
            if (animator == null)
            {
                animator = model.AddComponent<Animator>();
            }

            var cubisumFadeController = model.GetComponent<CubismFadeController>();
            if (cubisumFadeController == null)
            {
                cubisumFadeController = model.AddComponent<CubismFadeController>();
            }

            cubisumFadeController.CubismFadeMotionList = fadeMotions;

            var cubismMotionController = model.GetComponent<CubismMotionController>();
            if (cubismMotionController == null)
            {
                cubismMotionController = model.AddComponent<CubismMotionController>();
            }

            cubismMotionController.PlayAnimation(animationClip, isLoop: true);     
            return animator;
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