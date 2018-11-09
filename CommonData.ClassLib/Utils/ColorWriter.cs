using System;

namespace CommonData.ClassLib.Utils
{
    public class ColorWriter
    {
        public static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}