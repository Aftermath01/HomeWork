using System;
using System.Threading;
using System.Threading.Tasks;
using Threads.Contracts;
using Threads.Enums;
using Threads.ThreadWorkers;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting threads");

            using (var tokenSource = new CancellationTokenSource())
            {
                IThreadPool threadPool = new ThreadPool(tokenSource);

                threadPool.AddThread(new ThreadWorker(AllowedColors.Cyan, "Thread1", 100));
                threadPool.AddThread(new ThreadWorker(AllowedColors.Gray, "Thread2", 200));
                threadPool.StartAllThreads();

                Task consoleKeyTask = Task.Run(() => { ThreadInterrupter.CancelOnKeyPress(tokenSource); });
                consoleKeyTask.Wait();

                threadPool.TerminateAllThreads();

                Thread.Sleep(1000);
            }

            Console.WriteLine("All threads has been terminated");
        }
    }
}
