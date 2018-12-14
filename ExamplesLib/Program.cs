using ExamplesLib.EnumParseTests;
using ExamplesLib.WebRequest.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonData.ClassLib.NeuronNetworks.HammingNetwork;

namespace ExamplesLib
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuronNetworks_HammingNetwork_Test2();
            Console.ReadKey();
        }

        private static void NeuronNetworks_HammingNetwork_Test2()
        {
            double[] letter1 = new double[9] { -1, 1, -1, -1, 1, -1, -1, 1, -1 };
            double[] letter2 = new double[9] { 1, 1, 1, 1, -1, 1, 1, -1, 1 };
            double[] letter3 = new double[9] { 1, -1, 1, 1, 1, 1, 1, -1, 1 };
            double[] letter4 = new double[9] { 1, 1, 1, 1, -1, -1, 1, -1, -1 };
            double[] letter5 = new double[9] { -1, -1, -1, -1, 1, -1, -1, -1, -1 };

            double[] letterForTest = new double[9] { -1, -1, 1, 1, 1, 1, 1, -1, 1 };


            IList<double[]> standartData = new List<double[]>();
            standartData.Add(letter1);
            standartData.Add(letter2);
            standartData.Add(letter3);
            standartData.Add(letter4);
            standartData.Add(letter5);

            NeuralNetwork nn = new NeuralNetwork();
            nn.Initialize(5);
            nn.Train(standartData);
            var answer = nn.Run(letterForTest);

            foreach (var item in answer)
            {
                Console.WriteLine(item + " ");
            }
        }

        private static void NeuronNetworks_HammingNetwork_Test()
        {
            double[] letterA = new double[25]
            {
                -1, -1,  1, -1, -1,
                -1,  1, -1,  1, -1,
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                -1,  1, -1,  1, -1
            };

            double[] letterB = new double[25]
            {
                -1, 1,  1,  1, -1,
                -1 ,1, -1, -1, -1,
                -1, 1,  1,  1, -1,
                -1, 1, -1,  1, -1,
                -1, 1,  1,  1, -1
            };

            double[] letterD = new double[25]
            {
                -1,  1,  1,  1, -1,
                -1,  1, -1,  1, -1,
                 1,  1,  1,  1,  1,
                 1, -1, -1, -1,  1,
                 1, -1, -1, -1,  1
            };
            double[] letterN = new double[25]
            {
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1,  1, 1, -1,
                -1, 1, -1, 1, -1,
                -1, 1, -1, 1, -1,
            };

            double[] letterForTest = new double[25]
            {
                -1, 1,  1,  1, 1,
                -1 ,1, -1, -1, -1,
                -1, 1,  1,  1, -1,
                -1, 1, -1,  1, -1,
                -1, 1,  1,  1, -1
            };

            IList<double[]> standartData = new List<double[]>();
            standartData.Add(letterA);
            standartData.Add(letterB);
            standartData.Add(letterD);
            standartData.Add(letterN);

            NeuralNetwork nn = new NeuralNetwork();
            nn.Initialize(4);
            nn.Train(standartData);
            var answer = nn.Run(letterForTest);

            foreach (var item in answer)
            {
                Console.WriteLine(item + " ");
            }
        }

        //private static void NeuralNet_NeuralNetwork_Test()
        //{
        //    NeuralNetwork nn = new NeuralNetwork(0.9, new int[] { 25, 25, 4 });

        //    double[] testinput = new double[25]
        //    {
        //        0, 1,  0, 1, 0,
        //        0, 1,  0, 1, 0,
        //        0, 1,  1, 1, 0,
        //        0, 1,  0, 1, 0,
        //        0, 1,  0, 1, 1,
        //    };

        //    NeuralNetworkLearnA(nn);
        //    NeuralNetworkLearnB(nn);
        //    NeuralNetworkLearnD(nn);
        //    NeuralNetworkLearnN(nn);

        //    double[] rezult = nn.Run(testinput.ToList());

        //    foreach (var item in rezult)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //private static void NeuralNetworkLearnA(NeuralNetwork nn)
        //{
        //    double[] letterA = new double[25]
        //   {
        //        0,  0,  1,  0, 0,
        //        0,  1,  0,  1, 0,
        //        0,  1,  1,  1, 0,
        //        0,  1,  0,  1, 0,
        //        0,  1,  0,  1, 0
        //   };

        //    List<double> ins = letterA.ToList();

        //    List<double> ots = new List<double>
        //    {
        //        1
        //    };

        //    for (int i = 0; i < 100000; i++)
        //    {
        //        nn.Train(ins, ots);
        //    }
        //}

        //private static void NeuralNetworkLearnB(NeuralNetwork nn)
        //{
        //    double[] letterB = new double[25]
        //   {
        //        0, 1,  1,  1, 0,
        //        0 ,1,  0, 0, 0,
        //        0, 1,  1,  1, 0,
        //        0, 1,  0,  1, 0,
        //        0, 1,  1,  1, 0
        //   };

        //    List<double> ins = letterB.ToList();

        //    List<double> ots = new List<double>
        //    {
        //        1
        //    };

        //    for (int i = 0; i < 100000; i++)
        //    {
        //        nn.Train(ins, ots);
        //    }
        //}

        //private static void NeuralNetworkLearnD(NeuralNetwork nn)
        //{
        //    double[] letterD = new double[25]
        //   {
        //         0,  1,  1,  1,  0,
        //         0,  1,  0,  1,  0,
        //         1,  1,  1,  1,  1,
        //         1,  0,  0,  0,  1,
        //         1,  0,  0,  0,  1
        //   };

        //    List<double> ins = letterD.ToList();

        //    List<double> ots = new List<double>
        //    {
        //        1
        //    };

        //    for (int i = 0; i < 100000; i++)
        //    {
        //        nn.Train(ins, ots);
        //    }
        //}

        //private static void NeuralNetworkLearnN(NeuralNetwork nn)
        //{
        //    double[] letterN = new double[25]
        //   {
        //        0, 1,  0, 1, 0,
        //        0, 1,  0, 1, 0,
        //        0, 1,  1, 1, 0,
        //        0, 1,  0, 1, 0,
        //        0, 1,  0, 1, 0,
        //   };

        //    List<double> ins = letterN.ToList();

        //    List<double> ots = new List<double>
        //    {
        //        1
        //    };

        //    for (int i = 0; i < 100000; i++)
        //    {
        //        nn.Train(ins, ots);
        //    }
        //}

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
