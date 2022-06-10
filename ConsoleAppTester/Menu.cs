using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleAppTester
{
    internal class Menu
    {
        public static void ShowMenu()
        {
            Messages.MenuText();

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.S:
                    Console.Clear();
                    Actions.StartTest();
                    break;

                case ConsoleKey.N:
                    Console.Clear();
                    Actions.CreateNewTest();
                    break;

                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    Console.Clear();
                    Exceptions.Error(0);
                    ShowMenu();
                    break;
            }
        }
    }
}
