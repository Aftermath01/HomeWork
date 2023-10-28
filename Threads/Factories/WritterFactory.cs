using System.Collections.Generic;
using System.Threading;
using Threads.Contracts;
using Threads.Writters;

namespace Threads.Factories
{
    public class WritterFactory : IWritterFactory
    {
        private static Mutex mutex = new Mutex();
        private readonly Dictionary<string, IWritter> _writters;

        public WritterFactory()
        {
            _writters = new Dictionary<string, IWritter>
            {
                { "cyan", new CyanWritter() },
                { "gray", new GrayWritter() }
            };
        }

        public void Write(string color, string message)
        {
            try
            {
                mutex.WaitOne();
                _writters[color].WriteMessageWithColor(message);
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
