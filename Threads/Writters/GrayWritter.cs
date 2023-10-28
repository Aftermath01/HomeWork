using System;
using Threads.Contracts;

namespace Threads.Writters
{
    public class GrayWritter : IWritter
    {
        public void WriteMessageWithColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(message);
        }
    }
}
