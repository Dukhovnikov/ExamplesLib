using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonData.ClassLib.Utils;


namespace JsonFormatter.ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            ColorWriter.WriteLine("Please, input unformatted json string:", ConsoleColor.White);

            var unformattedJson = Console.ReadLine();
            var formattedJson = unformattedJson.ToJson();

            ColorWriter.WriteLine("Indented JSON:", ConsoleColor.White);
            ColorWriter.WriteLine(formattedJson, ConsoleColor.Blue);

            Console.ReadKey();
        }
    }
}
