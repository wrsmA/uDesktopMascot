using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UniGLTF;

namespace uDesktopMascot
{
    /// <summary>
    /// CancellationToken を使用して即時実行する AwaitCaller クラス
    /// </summary>
    public class ImmediateCallerWithCancellation : IAwaitCaller
    {
        private readonly CancellationToken _cancellationToken;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="cancellationToken">キャンセル用のトークン</param>
        public ImmediateCallerWithCancellation(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
        }

        /// <summary>
        /// 次のフレームまで待機します（即時完了）※IAwaitCallerの明示的実装
        /// </summary>
        /// <returns>待機タスク</returns>
        Task IAwaitCaller.NextFrame()
        {
            _cancellationToken.ThrowIfCancellationRequested();
            return Task.CompletedTask;
        }

        /// <summary>
        /// タイムアウト時に次のフレームまで待機します（今回の実装では即時完了）
        /// </summary>
        /// <returns>待機タスク</returns>
        public Task NextFrameIfTimedOut()
        {
            _cancellationToken.ThrowIfCancellationRequested();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Action を実行します ※IAwaitCallerの明示的実装
        /// </summary>
        /// <param name="action">実行する Action</param>
        /// <returns>タスク</returns>
        Task IAwaitCaller.Run(Action action)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            action();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Func&lt;T&gt; を実行します ※IAwaitCallerの明示的実装
        /// </summary>
        /// <typeparam name="T">戻り値の型</typeparam>
        /// <param name="action">実行する Func</param>
        /// <returns>戻り値を持つタスク</returns>
        Task<T> IAwaitCaller.Run<T>(Func<T> action)
        {
            _cancellationToken.ThrowIfCancellationRequested();
            T result = action();
            return Task.FromResult(result);
        }
    }
}