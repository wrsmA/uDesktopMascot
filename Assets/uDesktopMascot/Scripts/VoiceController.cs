using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.Logging;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

namespace uDesktopMascot
{
    /// <summary>
    ///     ボイスを制御するクラス
    /// </summary>
    public class VoiceController : SingletonMonoBehaviour<VoiceController>
    {
        /// <summary>
        ///     クリックボイス
        /// </summary>
        [SerializeField] private List<AudioClip> clickVoice;

        /// <summary>
        ///     ドラッグボイス
        /// </summary>
        [SerializeField] private List<AudioClip> dragVoice;

        /// <summary>
        ///     オーディオソース
        /// </summary>
        private AudioSource _audioSource;

        /// <summary>
        ///     クリックボイスのロードが完了したかどうか
        /// </summary>
        private bool _clickVoicesLoaded;

        /// <summary>
        ///     ドラッグボイスのロードが完了したかどうか
        /// </summary>
        private bool _dragVoicesLoaded;

        /// <summary>
        ///     クリックボイスのフォルダパス
        /// </summary>
        private const string ClickVoiceFolderPath = "Voice/Click";

        /// <summary>
        ///     ドラッグボイスのフォルダパス
        /// </summary>
        private const string DragVoiceFolderPath = "Voice/Drag";

        /// <summary>
        ///     キャンセルトークンソース
        /// </summary>
        private CancellationTokenSource _cancellationTokenSource;

        private protected override void Awake()
        {
            base.Awake();
            _cancellationTokenSource = new CancellationTokenSource();
            _audioSource = GetComponent<AudioSource>();

            // キャンセルトークンを取得
            var cancellationToken = _cancellationTokenSource.Token;

            // クリックボイスをロード
            LoadVoices(
                ClickVoiceFolderPath,
                clickVoice,
                count =>
                {
                    _clickVoicesLoaded = true;
                    if (count == 0)
                    {
                        Log.Warning("クリックボイスがロードされませんでした。フォルダに有効なオーディオファイルがありません。");
                    } else
                    {
                        Log.Debug("クリックボイスを {0} 件ロードしました。", count);
                    }
                },
                () =>
                {
                    Log.Debug("クリックボイスフォルダが存在しません。デフォルトのクリックボイスを使用します。");
                    _clickVoicesLoaded = true;
                },
                cancellationToken).Forget();

            // ドラッグボイスをロード
            LoadVoices(
                DragVoiceFolderPath,
                dragVoice,
                count =>
                {
                    _dragVoicesLoaded = true;
                    if (count == 0)
                    {
                        Log.Warning("ドラッグボイスがロードされませんでした。フォルダに有効なオーディオファイルがありません。");
                    } else
                    {
                        Log.Debug("ドラッグボイスを {0} 件ロードしました。", count);
                    }
                },
                () =>
                {
                    Log.Debug("ドラッグボイスフォルダが存在しません。デフォルトのドラッグボイスを使用します。");
                    _dragVoicesLoaded = true;
                },
                cancellationToken).Forget();
        }

        /// <summary>
        ///     ボイスをロードする共通非同期メソッド
        /// </summary>
        /// <param name="relativeFolderPath">ボイスのフォルダパス (Application.streamingAssetsPathからの相対パス)</param>
        /// <param name="voiceList">ロードした AudioClip を格納するリスト</param>
        /// <param name="onLoaded">ロード完了時のコールバック（ロードしたファイル数を引数に取る）</param>
        /// <param name="onDirectoryNotFound">フォルダが見つからなかったときのコールバック</param>
        /// <param name="cancellationToken">キャンセルトークン</param>
        private async UniTaskVoid LoadVoices(
            string relativeFolderPath,
            List<AudioClip> voiceList,
            Action<int> onLoaded,
            Action onDirectoryNotFound,
            CancellationToken cancellationToken)
        {
            var voiceFolderPath = Path.Combine(Application.streamingAssetsPath, relativeFolderPath);

            // フォルダが存在する場合
            if (Directory.Exists(voiceFolderPath))
            {
                // 既存のボイスをクリア
                voiceList.Clear();

                // フォルダ内のすべてのファイルを取得
                var files = Directory.GetFiles(voiceFolderPath);

                foreach (var filePath in files)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var extension = Path.GetExtension(filePath).ToLower();

                    // 対象の拡張子のみを処理
                    if (extension == ".wav" || extension == ".mp3" || extension == ".ogg")
                    {
                        var url = "file://" + filePath;

                        using var www = UnityWebRequestMultimedia.GetAudioClip(url, GetAudioType(extension));
                        try
                        {
                            await www.SendWebRequest().WithCancellation(cancellationToken);

                            if (www.result == UnityWebRequest.Result.ConnectionError ||
                                www.result == UnityWebRequest.Result.ProtocolError)
                            {
                                Log.Warning("Failed to load audio clip: {0}\nError: {1}", filePath, www.error);
                            } else
                            {
                                var clip = DownloadHandlerAudioClip.GetContent(www);
                                if (clip != null)
                                {
                                    voiceList.Add(clip);
                                }
                            }
                        } catch (OperationCanceledException)
                        {
                            // キャンセル時の処理（必要に応じて）
                            Log.Debug("ロードがキャンセルされました: {0}", filePath);
                            return;
                        }
                    }
                }

                // ロード完了時のコールバックを呼び出す
                onLoaded?.Invoke(voiceList.Count);
            } else
            {
                // フォルダが存在しない場合
                onDirectoryNotFound?.Invoke();
            }
        }

        /// <summary>
        ///     拡張子に応じてAudioTypeを取得する
        /// </summary>
        /// <param name="extension">ファイル拡張子</param>
        /// <returns>AudioType</returns>
        private AudioType GetAudioType(string extension)
        {
            return extension switch
            {
                ".wav" => AudioType.WAV,
                ".mp3" => AudioType.MPEG,
                ".ogg" => AudioType.OGGVORBIS,
                _ => AudioType.UNKNOWN
            };
        }

        /// <summary>
        ///     クリックボイスを再生する
        /// </summary>
        public void PlayClickVoice()
        {
            if (!_clickVoicesLoaded)
            {
                // ロードが完了していない場合は再生しない
                return;
            }

            if (clickVoice == null || clickVoice.Count == 0)
            {
                return;
            }

            _audioSource.PlayOneShot(clickVoice[Random.Range(0, clickVoice.Count)]);
        }

        /// <summary>
        ///     ドラッグボイスを再生する
        /// </summary>
        public void PlayHoldVoice()
        {
            if (!_dragVoicesLoaded)
            {
                // ロードが完了していない場合は再生しない
                return;
            }

            if (dragVoice == null || dragVoice.Count == 0)
            {
                return;
            }

            _audioSource.PlayOneShot(dragVoice[Random.Range(0, dragVoice.Count)]);
        }

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}