using System;
using Threads.Contracts;

namespace Threads.Writters
{
    public class CyanWritter : IWritter
    {
        public void WriteMessageWithColor(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
