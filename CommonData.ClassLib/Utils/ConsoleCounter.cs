using System;

namespace CommonData.ClassLib.Utils
{
    public class ConsoleCounter
    {
        private int Number { get; set; }

        public ConsoleCounter()
        {
            Number = 0;
        }

        public void Tick()
        {
            Number++;
        }

        public void Show()
        {
            ColorWriter.WriteLine($"Console counter: It was {Number} iteration.", ConsoleColor.Green);
        }
    }
}
