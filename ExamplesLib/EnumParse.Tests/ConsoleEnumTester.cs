using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesLib.EnumParseTests
{
    public enum ECommand
    {
        Check,
        Status
    }

    public class ConsoleEnumTester
    {
        public static void TestECommandShouldCMD_String1()
        {
            string cmd = "1";

            var command = cmd.Parse<ECommand>();

            Console.WriteLine(command);
        }

        public static void TestECommandShouldCMD_status()
        {
            string cmd = "status";

            var command = cmd.Parse<ECommand>();

            Console.WriteLine(command);
        }
    }
}
