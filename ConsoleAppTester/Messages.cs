using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public static void SaveSuccessful(string testName)
        {
            Console.WriteLine($"Тест сохранён в файл. Название теста для его прохождения: {testName}\n");
        }
        
        public static void NoTests()
        {
            Console.WriteLine("Нет доступных тестов для прохождения. Создайте новый.\n");
        }
        public static void GotTests(List<string> TxtFiles)
        {
            Console.WriteLine("Доступные тесты:");
            for (int i = 0; i < TxtFiles.Count; i++)
                Console.WriteLine(Path.GetFileNameWithoutExtension(TxtFiles[i]));
        }
        public static void WriteTestName()
        {
            Console.WriteLine("\nВведите название теста для его прохождения:");
        }
        public static void TestStarted(string testName)
        {
            Console.WriteLine($"---Тест \"{testName}\" успешно загружен и начался в {DateTime.Now}---\n\nВопросы: ");
        }
        
        public static void Exception(string message)
        {
            Console.Clear();

            Console.WriteLine(message);

            Actions.CreateNewTest();
        }

    }
}
