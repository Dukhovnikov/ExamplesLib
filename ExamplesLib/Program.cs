using ExamplesLib.EnumParseTests;
using ExamplesLib.WebRequest.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesLib
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = HammingNetwork.Run();
            Console.WriteLine(array[0]);
            Console.ReadKey();
        }

        private static void ConsoleEnumTesterRunTests()
        {
            ConsoleEnumTester.TestECommandShouldCMD_String1();
            ConsoleEnumTester.TestECommandShouldCMD_status();
        }

        private static void ProcessTestClass(TestClass test)
        {
            if (string.IsNullOrEmpty(test?.Value))
            {
                Console.WriteLine("Значение test.Value равно null");
                return;
            }

            Console.WriteLine("Тест завершен удачно!");
        }

        public class TestClass
        {
            public string Value { get; set; }
        }

        static void RunToWriteStrinsExample()
        {
            var simpleDataList = SimpleDataService.GerDefaultSimpleDataList();
            var simpleDataFirst = simpleDataList.First();
            var strings = new[]
            {
                "123",
                "321",
                "312",
                "132"
            };

            var text = "test header:";

            foreach (var s in strings)
            {
                text += s;
                text += Environment.NewLine;
            }

            Console.WriteLine(text);
        }

        static void RunToNull()
        {
            string[] strings = new string[1];

            if (strings != null && strings.Count() > 0)
            {
                Console.WriteLine("Elements finded");
            }
            else
            {
                Console.WriteLine("Checked");
            }
        }

        static void RunToSmtpExample()
        {
            var simpleDataList = SimpleDataService.GerDefaultSimpleDataList();
            var simpleDataFirst = simpleDataList.First();
            var strings = new[]
            {
                "123",
                "321",
                "312",
                "132"
            };



            Console.WriteLine($"За {simpleDataFirst.Date.ToShortDateString()} были запрошены следующие номера заявок: {Environment.NewLine} {strings.ToString()}");
        }

        static void RunSortedExample()
        {
            var simpleDataList = SimpleDataService.GerDefaultSimpleDataList();

            Console.WriteLine("Not sorted list:");

            foreach (var simpleData in simpleDataList)
            {
                Console.WriteLine($"{simpleData.Id}  {simpleData.Date.ToLongTimeString()}");
            }

            Console.WriteLine($"Count: {simpleDataList.Count}");


            Console.WriteLine("Sorted list:");

            var simpleDataSortedList = simpleDataList.OrderBy(entity => entity.Date);
            foreach (var simpleData in simpleDataSortedList)
            {
                Console.WriteLine($"{simpleData.Id}  {simpleData.Date.ToLongTimeString()}");
            }

            Console.WriteLine($"Count: {simpleDataList.Count}");
        }
    }
}
