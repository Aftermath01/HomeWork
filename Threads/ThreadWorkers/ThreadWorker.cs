using System.Threading;
using Threads.Contracts;
using Threads.Factories;

namespace Threads.ThreadWorkers
{
    public class ThreadWorker : IThreadWorker
    {
        private string _color;
        private string _name;
        private int _milliseconds;
        private readonly IWritterFactory _writterFactory;

        public ThreadWorker(string color, string name, int milliseconds)
        {
            _color = color;
            _name = name;
            _milliseconds = milliseconds;

            _writterFactory = new WritterFactory();
        }

        public void DoWork(CancellationToken token = default)
        {
            while (!token.IsCancellationRequested)
            {
                _writterFactory.Write(_color, _name);

                Thread.Sleep(_milliseconds);
            }
        }
    }
}
