using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace uDesktopMascot
{
    /// <summary>
    /// モデルのモーションを制御するクラス
    /// </summary>
    public class CharacterController : MonoBehaviour
    {
        private static readonly int IsSitting = Animator.StringToHash("IsSitting");
        private static readonly int IsDragging = Animator.StringToHash("IsHanding");

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

        /// <summary>
        /// Input Systemのアクション
        /// </summary>
        private UDMInputActions _inputActions;

        /// <summary>
        /// マウスがドラッグ中かどうか
        /// </summary>
        private bool _isDragging = false;

        /// <summary>
        /// ドラッグ対象のオブジェクトがモデルかどうか
        /// </summary>
        private bool _isDraggingModel = false;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _cancellationTokenSource = new CancellationTokenSource();

            // InputActionsのインスタンスを作成
            _inputActions = new UDMInputActions();
        }

        private void OnEnable()
        {
            // 入力アクションを有効化
            _inputActions.Enable();

            // イベントの購読
            _inputActions.UI.Click.performed += OnClickPerformed;
            _inputActions.UI.Click.canceled += OnClickCanceled;
        }

        private void OnDisable()
        {
            // 入力アクションを無効化
            _inputActions.Disable();

            // イベントの購読解除
            _inputActions.UI.Click.performed -= OnClickPerformed;
            _inputActions.UI.Click.canceled -= OnClickCanceled;
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
            try
            {
                _model = await LoadVRM.LoadModel(_cancellationTokenSource.Token);
                _modelAnimator = _model.GetComponent<Animator>();
                LoadVRM.UpdateAnimationController(_modelAnimator);

                // モデルにColliderを追加（既にある場合は不要）
                AddCollidersToModel();

                _isInitialized = true;
            } catch (System.Exception e)
            {
                Debug.LogError($"モデルの初期化中にエラーが発生しました: {e.Message}");
            }
        }

        private void Update()
        {
            if (!_isInitialized)
            {
                return;
            }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
            
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
#endif

            // モーションを切り替える
            if (_isDragging && _isDraggingModel)
            {
                // ドラッグ中はハンギングモーション（ぶら下がりモーション）
                _modelAnimator.SetBool(IsSitting, false);
                _modelAnimator.SetBool(IsDragging, true);
            } else
            {
                _modelAnimator.SetBool(IsDragging, false);
                // 座りモーションまたは立ちモーションに切り替え
                _modelAnimator.SetBool(IsSitting, isNearExplorerTop);
            }
        }

        /// <summary>
        /// クリックが押されたときの処理
        /// </summary>
        /// <param name="context"></param>
        private void OnClickPerformed(InputAction.CallbackContext context)
        {
            // 入力の状態を切り替え
            _isDragging = !_isDragging;
            // マウス位置を取得
            Vector2 mousePosition = _inputActions.UI.Point.ReadValue<Vector2>();

            // マウス位置からレイを飛ばす
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == _model.transform || hit.transform.IsChildOf(_model.transform))
                {
                    // モデルがクリックされた
                    _isDraggingModel = true;
                } else
                {
                    _isDraggingModel = false;
                }
            } else
            {
                _isDraggingModel = false;
            }
        }

        /// <summary>
        /// クリックが離されたときの処理
        /// </summary>
        /// <param name="context"></param>
        private void OnClickCanceled(InputAction.CallbackContext context)
        {
            _isDragging = false;
            _isDraggingModel = false;
        }

        /// <summary>
        /// モデルにColliderを追加する
        /// </summary>
        private void AddCollidersToModel()
        {
            // モデルの全てのSkinnedMeshRendererにMeshColliderを追加
            var skinnedMeshes = _model.GetComponentsInChildren<SkinnedMeshRenderer>();
            foreach (var skinnedMesh in skinnedMeshes)
            {
                MeshCollider collider = skinnedMesh.gameObject.AddComponent<MeshCollider>();
                collider.sharedMesh = skinnedMesh.sharedMesh;
                collider.convex = true; // 必要に応じて設定
            }
        }

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}