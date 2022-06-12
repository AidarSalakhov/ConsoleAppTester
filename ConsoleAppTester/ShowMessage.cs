using System;

namespace ConsoleAppTester
{
    internal class ShowMessage
    {
        public static void Error(int code, bool line = true)
        {
            if (line)
            {
                Console.WriteLine(Messages.errors[code]);
            }
            else
            {
                Console.Write(Messages.errors[code]);
            }
        }

        public static void Info(int code, bool line = true)
        {
            if (line)
            {
                Console.WriteLine(Messages.info[code]);
            }
            else
            {
                Console.Write(Messages.info[code]);
            }
        }
    }
}

