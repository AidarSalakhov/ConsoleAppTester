using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

