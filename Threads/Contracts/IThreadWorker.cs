using System.Threading;

namespace Threads.Contracts
{
    public interface IThreadWorker
    {
        void DoWork(CancellationToken token = default);
    }
}
