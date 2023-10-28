using System;
using System.Threading;

namespace Threads
{
    public static class ThreadInterrupter
    {
        public static void CancelOnKeyPress(CancellationTokenSource tokenSource)
        {
            while (!tokenSource.Token.IsCancellationRequested)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);

                    tokenSource.Cancel();
                }
            }
        }
    }
}
