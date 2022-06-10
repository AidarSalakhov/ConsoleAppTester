using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace ConsoleAppTester
{
    internal class File
    {
        public static void SaveTest(string testName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Test.newTest);

                File.WriteAllText($"{testName}.txt", json);

                Console.Clear();

                Console.WriteLine($"Тест сохранён в файл. Название теста для его прохождения: {testName}\n");
            }
            catch (Exception)
            {
                Console.Clear();

                Console.WriteLine("[Ошибка!] Не удалось сохранить тест!\n");

                Menu.ShowMenu();
            }
        }

        public static void LoadTest()
        {
            try
            {
                List<string> TxtFiles = new List<string>();

                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

                FileInfo[] files = dir.GetFiles("*.txt*");

                foreach (FileInfo fi in files)
                    TxtFiles.Add(fi.ToString());

                if (TxtFiles.Count < 1)
                {
                    Console.WriteLine("Нет доступных тестов для прохождения. Создайте новый.\n");
                    Menu.ShowMenu();
                }

                Console.WriteLine("Доступные тесты:");

                for (int i = 0; i < TxtFiles.Count; i++)
                    Console.WriteLine(Path.GetFileNameWithoutExtension(TxtFiles[i]));

                Console.WriteLine("\nВведите название теста для его прохождения:");
                string testName = Console.ReadLine();
                string json = File.ReadAllText($"{testName}.txt").ToString();
                Test.newTest = JsonConvert.DeserializeObject<List<Test.Question>>(json);
                Console.Clear();
                Console.WriteLine($"---Тест \"{testName}\" успешно загружен и начался в {DateTime.Now}---\n\nВопросы: ");
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("[Ошибка!] Такого теста не существует!\n");
                Menu.ShowMenu();
            }
        }
    }
}
