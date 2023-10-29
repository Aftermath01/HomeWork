using System.Collections.Generic;
using System.Threading;
using Threads.Contracts;
using Threads.Enums;
using Threads.Writters;

namespace Threads.Factories
{
    public class WritterFactory : IWritterFactory
    {
        private static Mutex mutex = new Mutex();
        private readonly Dictionary<AllowedColors, IWritter> _writters;

        public WritterFactory()
        {
            _writters = new Dictionary<AllowedColors, IWritter>
            {
                { AllowedColors.Cyan, new CyanWritter() },
                { AllowedColors.Gray, new GrayWritter() }
            };
        }

        public void Write(AllowedColors color, string message)
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
