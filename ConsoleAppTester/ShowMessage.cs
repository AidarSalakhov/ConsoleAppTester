using System;

namespace ConsoleAppTester
{
    internal class ShowMessage
    {
        public static void Error(int code)
        {
            Console.WriteLine(Messages.errors[code]);
        }

        public static void Info(int code)
        {
            Console.WriteLine(Messages.info[code]);
        }
    }
}

