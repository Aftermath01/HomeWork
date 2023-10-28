namespace Threads.Contracts
{
    public interface IThreadPool
    {
        void AddThread(IThreadWorker threadWorker);

        void StartAllThreads();

        void TerminateAllThreads();
    }
}
