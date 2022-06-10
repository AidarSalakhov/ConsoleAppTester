using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTester
{
    internal class Messages
    {
        public static void MenuText()
        {
            Console.WriteLine("\t----Выберите действие----");
            Console.WriteLine("\t[S] - Пройти тест");
            Console.WriteLine("\t[N] - Создать тест");
            Console.WriteLine("\t[Esc] - Выйти из программы");
        }
    }
}
