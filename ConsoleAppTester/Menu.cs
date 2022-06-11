using System;
using System.Diagnostics;

namespace ConsoleAppTester
{
    internal class Menu
    {
        public static void ShowMenu()
        {
            ShowMessage.Info(0);

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.S:
                    Console.Clear();
                    TestOperations.StartTest();
                    break;

                case ConsoleKey.N:
                    Console.Clear();
                    TestOperations.CreateNewTest();
                    break;

                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    Console.Clear();
                    ShowMessage.Error(0);
                    ShowMenu();
                    break;
            }
        }
    }
}
