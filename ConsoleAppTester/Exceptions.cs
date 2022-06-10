using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTester
{
    internal class Exceptions
    {
        public static void Exception(string message)
        {
            Console.Clear();

            Console.WriteLine(message);

            CreateNewTest();
        }

        public static void WrongButton()
        {
            Console.WriteLine("[Ошибка!] Вы нажали неверную клавишу.\n");
        }
        
    }
}
