using System.Threading;
using System;

using Cysharp.Threading.Tasks;
using UnityEngine;
using Unity.Logging;

namespace uDesktopMascot.VRM
{
    public class VrmCharacterLoader : CharacterLoaderBase
    {
        public override async UniTask<CharacterControllerBase> LoadCharacterAsync(string path)
        {
            var model = await LoadVRM.LoadModel(ApplicationManager.Instance.CancellationToken, path);
            await UniTask.SwitchToMainThread();
            return OnModelLoaded(model);
        }

        /// <summary>
        /// 初期ロードのモデルの表示後の調節
        /// </summary>
        /// <param name="model"></param>
        private VrmCharacterController OnModelLoaded(GameObject model)
        {
            // モデルを包む空のゲームオブジェクトを作成
            GameObject modelContainer = new GameObject("ModelContainer");
            var mainCamera = Camera.main;

            // モデルを子オブジェクトに設定
            model.transform.SetParent(modelContainer.transform, false);

            // モデルコンテナをカメラの前方に配置
            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 cameraForward = mainCamera.transform.forward;
            float distanceFromCamera = 2.0f; // 距離を調整
            modelContainer.transform.position = cameraPosition + cameraForward * distanceFromCamera;

            // モデルコンテナをカメラの方向に向ける
            modelContainer.transform.LookAt(cameraPosition, Vector3.up);

            var characterApplicationSettings = ApplicationSettings.Instance.Character;

            // モデルのスケールを調整（必要に応じて変更）
            modelContainer.transform.localScale = Vector3.one * characterApplicationSettings.Scale;

            // モデルコンテナの相対位置を設定
            modelContainer.transform.position += new Vector3(characterApplicationSettings.PositionX, characterApplicationSettings.PositionY, characterApplicationSettings.PositionZ);

            // モデルコンテナの相対回転を設定
            var currentRotation = modelContainer.transform.rotation.eulerAngles;
            modelContainer.transform.rotation = Quaternion.Euler(currentRotation.x + characterApplicationSettings.RotationX, currentRotation.y + characterApplicationSettings.RotationY, currentRotation.z + characterApplicationSettings.RotationZ);

            Log.Info("キャラクター設定: スケール {0}, 位置 {1}, 回転 {2}", characterApplicationSettings.Scale, modelContainer.transform.position, modelContainer.transform.rotation.eulerAngles);

            // アニメータの取得と設定
            var animator = model.GetComponentInChildren<Animator>();

            if (animator == null)
            {
                Log.Warning("モデル内にAnimatorコンポーネントが見つかりませんでした。Animatorを追加します。");

                // Animatorコンポーネントを追加
                animator = model.AddComponent<Animator>();

                // モデルからAvatarを取得して設定
                var avatar = CreateAvatarFromModel(model);
                if (avatar != null)
                {
                    animator.avatar = avatar;
                    Log.Info("モデルからAvatarを生成し、Animatorに設定しました。");
                } 
                else
                {
                    Log.Warning("モデルからAvatarを生成できませんでした。アニメーションが正しく再生されない可能性があります。");
                }

            } 
                
            // アニメーションコントローラーを設定
            LoadVRM.UpdateAnimationController(animator);

            var controller = modelContainer.GetComponent<VrmCharacterController>();
            if (controller == null)
            {
                controller = modelContainer.AddComponent<VrmCharacterController>();
            }
            controller.Attach(model, animator);

            return controller;
        }

        /// <summary>
        /// モデルからAvatarを生成します。
        /// </summary>
        /// <param name="model">モデルのGameObject</param>
        /// <returns>生成されたAvatar</returns>
        private Avatar CreateAvatarFromModel(GameObject model)
        {
            // モデル内のHumanDescriptionを取得する
            var animator = model.GetComponent<Animator>();
            if (animator != null && animator.avatar != null)
            {
                // 既存のAvatarがある場合はそれを返す
                return animator.avatar;
            }

            // SkinnedMeshRenderer から HumanDescription を取得
            var smr = model.GetComponentInChildren<SkinnedMeshRenderer>();
            if (smr != null && smr.sharedMesh != null)
            {
                // Humanoid アバターを自動生成
                var humanDescription = new HumanDescription();
                // お使いのモデルに合わせて設定が必要な場合があります

                var avatar = AvatarBuilder.BuildGenericAvatar(model, "");
                if (avatar != null)
                {
                    avatar.name = model.name + "_Avatar";
                    return avatar;
                }
            }

            return null;
        }
    }
}