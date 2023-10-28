using System.Collections.Generic;
using System.Threading;
using Threads.Contracts;

namespace Threads
{
    public class ThreadPool : IThreadPool
    {
        private readonly CancellationTokenSource _tokenSource;
        private readonly List<Thread> _threads;

        public ThreadPool(CancellationTokenSource tokenSource)
        {
            _tokenSource = tokenSource;
            _threads = new List<Thread>();
        }

        public void AddThread(IThreadWorker threadWorker)
        {
            var thread = new Thread(() =>
            {
                threadWorker.DoWork(_tokenSource.Token);
            });

            _threads.Add(thread);
        }

        public void StartAllThreads()
        {
            _threads.ForEach(f => f.Start());
        }

        public void TerminateAllThreads()
        {
            _threads.ForEach(f => f.Join());
        }
    }
}
