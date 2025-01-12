using System;
using System.Runtime.InteropServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace uDesktopMascot
{
    /// <summary>
    /// モデルの座りモーションを制御するクラス
    /// </summary>
    public class SittingMotionController : MonoBehaviour
    {
        private static readonly int IsSitting = Animator.StringToHash("IsSitting");
        
        /// <summary>
        /// モデルのアニメーター
        /// </summary>
        private Animator _modelAnimator;
        
        /// <summary>
        /// モデルのゲームオブジェクト
        /// </summary>
        private GameObject _model;
        
        /// <summary>
        /// メインカメラ
        /// </summary>
        private Camera _mainCamera;
        
        /// <summary>
        /// キャンセルトークンソース
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;
        
        /// <summary>
        /// 初期化済みかどうか
        /// </summary>
        private bool _isInitialized = false;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private void Start()
        {
            InitModel().Forget();
        }

        /// <summary>
        /// モデルの初期化
        /// </summary>
        private async UniTaskVoid InitModel()
        {
            _model = await LoadVRM.LoadModel(_cancellationTokenSource.Token);
            _modelAnimator = _model.GetComponent<Animator>();
            LoadVRM.UpdateAnimationController(_modelAnimator);
            _isInitialized = true;
        }

        private void Update()
        {
            if (!_isInitialized)
            {
                return;
            }
            
            // モデルのスクリーン座標を取得
            Vector2 modelScreenPos = Utility.GetModelScreenPosition(_mainCamera, _model.transform);

            // エクスプローラーウィンドウの位置を取得
            var explorerWindows = ExplorerWindowDetector.GetExplorerWindows();

            bool isNearExplorerTop = false;

            foreach (var window in explorerWindows)
            {
                // ウィンドウの矩形情報を取得
                var rect = window.rect;

                // DPIスケールを取得
                float dpiScale = ExplorerWindowDetector.GetDPIScale();

                // ウィンドウの座標をDPIスケールで割る
                rect.left = (int)(rect.left / dpiScale);
                rect.top = (int)(rect.top / dpiScale);
                rect.right = (int)(rect.right / dpiScale);
                rect.bottom = (int)(rect.bottom / dpiScale);

                // モデルがウィンドウの上部付近にいるか判定（例：ウィンドウの上端から50ピクセル以内）
                if (modelScreenPos.x >= rect.left && modelScreenPos.x <= rect.right)
                {
                    if (modelScreenPos.y >= rect.top - 50 && modelScreenPos.y <= rect.top + 50)
                    {
                        isNearExplorerTop = true;
                        break;
                    }
                }
            }

            // モーションを切り替える
            // 座りモーションに切り替え/立ちモーションに切り替え
            _modelAnimator.SetBool(IsSitting, isNearExplorerTop);
        }

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}