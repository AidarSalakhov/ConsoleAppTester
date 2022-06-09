using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Diagnostics;    

namespace ConsoleAppTester
{
    /*
    Программа “Тестер”
Программа позволяет создать тест и сохранить его в файл, а также позволяет потом загрузить этот тест и пройти его.
Тест представляет собой вопросы с 2 вариантами ответов.
Подсказка: используйте список, состоящий из структур.
Дополнительное условие: сделать так, чтобы юзер мог сам задавать кол-во ответов для вопросов теста, т.е.вместо 2-х ответов, например 3 или 4, но не менее 2-х.
Функционал:
•	Меню с выбором действия: создать тест, пройти тест.
•	Создание теста:
-Юзер указывает название теста (далее это название будет использоваться для создания файла этого теста)
-Юзер указывает кол-во вопросов теста.
-Далее юзер вводит названия вопросов, варианты ответов для этих вопросов и номер правильного ответа.
-Когда юзер ввел данные для всех вопросов, программа сохраняет тест в файл.
•	Прохождение теста:
-Программа просит ввести название теста.
--Если тест с таким названием существует, то программа загружает всю информацию о тесте из файла, который она находит по названию.
--Иначе программа сообщает, что такого теста не существует и юзер возвращается в меню.
-Далее программа выводит по одному вопросу и пронумерованные варианты ответов к нему.
-Юзер должен ввести свой ответ.
-После того как юзер ответил на все вопросы программа выводит результат (процент правильных ответов) и показывает меню.

•	Программа должна обрабатывать возможные проблемы, которые могут возникнуть из-за юзера, например если нужно ввести число, а юзер ввел текст,
    программа должна не вылетать, а сообщать о том, что юзер ошибся и ему необходимо ввести данные заново или например он ввел неверное название файла и т.д.
    */

    internal class Program
    {
        public static List<Question> Test = new List<Question>();

        public static Question question = new Question();

        public struct Question
        {
            public string question;
            public string[] questionAnswers;
            public int questionRightAnswer;
        }

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("\t----Выберите действие----");
            Console.WriteLine("\t[S] - Пройти тест");
            Console.WriteLine("\t[N] - Создать тест");
            Console.WriteLine("\t[Esc] - Выйти из программы");

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.S:
                    Console.Clear();
                    StartTest();
                    break;

                case ConsoleKey.N:
                    Console.Clear();
                    CreateNewTest();
                    break;

                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("[Ошибка!] Вы нажали неверную клавишу. Выберите действие из представленных:\n");
                    Menu();
                    break;
            }
        }

        static void SaveTest(string testName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Test);

                File.WriteAllText($"{testName}.txt", json);

                Console.Clear();

                Console.WriteLine($"\nТест сохранён в файл. Название теста для его прохождения: {testName}\n");
            }
            catch (Exception) 
            {
                Console.Clear();

                Console.WriteLine("[Ошибка!] Не удалось сохранить тест!\n");

                Menu();
            }
        }

        static void LoadTest()
        {
            try
            {
                List<string> TxtFiles = new List<string>(); 

                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

                FileInfo[] files = dir.GetFiles("*.txt*");

                foreach (FileInfo fi in files)
                    TxtFiles.Add(fi.ToString());

                Console.WriteLine("Доступные тесты:");

                for (int i = 0; i < TxtFiles.Count; i++)
                    Console.WriteLine(Path.GetFileNameWithoutExtension(TxtFiles[i]));

                Console.WriteLine("\nВведите название теста для его прохождения:");

                string testName = Console.ReadLine();

                string json = File.ReadAllText($"{testName}.txt").ToString();

                Test = JsonConvert.DeserializeObject<List<Question>>(json);

                Console.WriteLine($"\nТест успешно загружен и начался в {DateTime.Now}. Вопросы: ");
            }
            catch (Exception)
            {
                Console.Clear();

                Console.WriteLine("[Ошибка!] Такого теста не существует!\n");

                Menu();
            }
        }

        static void StartTest()
        {
            LoadTest();

            int userRightAnswers = 0;

            for (int i = 0; i < Test.Count; i++)
            {
                Console.WriteLine($"\n\n{Test[i].question}");

                Console.WriteLine("Варианты ответов:");

                for (int j = 0; j < Test[i].questionAnswers.Length; j++)
                    Console.Write($"{j+1}) {Test[i].questionAnswers[j]}\t");

                Console.WriteLine("\nВведите номер правильного ответа:");

                if (!double.TryParse(Console.ReadLine(), out double userAnswer) || userAnswer > Test[i].questionAnswers.Length || 1 > userAnswer)
                    Console.WriteLine("[Ошибка!] Вы ввели номер несуществующего ответа, либо некорректный символ. Ваш ответ засчитан как неверный");
                
                if (userAnswer == Test[i].questionRightAnswer)
                    userRightAnswers++;
            }

            Console.Clear();

            Console.WriteLine($"\n\nТест завершён в {DateTime.Now}. Процент правильных ответов: {System.Math.Round((double)(userRightAnswers / Convert.ToDouble(Test.Count) * 100))}%\n");

            Test.Clear();

            Menu();
        }

        static void CreateNewTest()
        {
            Test.Clear();

            Console.WriteLine("/Конструктор теста. Шаг 1 из 6/ Введите название теста:");
            string testName = Console.ReadLine();

            Console.WriteLine("\n/Конструктор теста. Шаг 2 из 6/ Введите количество вопросов теста:");
            if (!int.TryParse(Console.ReadLine(), out int testQuestionsCount))
                Exception("[Ошибка!] На Шаге 2 введите целое число.\n");

            Console.WriteLine("\n/Конструктор теста. Шаг 3 из 6/ Введите количество вариантов ответов вопроса (не менее 2):");
            if (!int.TryParse(Console.ReadLine(), out int questionAnswersCount) || questionAnswersCount < 2)
                Exception("[Ошибка!] На Шаге 3 введите целое число, большее чем 1.\n");

            for (int i = 0; i < testQuestionsCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"\n/Конструктор теста. Шаг 4 из 6/ Введите вопрос теста #{i+1}:");
                question.question = Console.ReadLine();
                question.questionAnswers = new string[questionAnswersCount];

                for (int j = 0; j < questionAnswersCount; j++)
                {
                    Console.WriteLine($"\n\t/Конструктор теста. Шаг 5 из 6/ Введите вариант ответа ({j+1}):");
                    question.questionAnswers[j] = Console.ReadLine();
                }

                Console.WriteLine("\n/Конструктор теста. Шаг 6 из 6/ Введите номер правильного ответа:");
                if (!int.TryParse(Console.ReadLine(), out question.questionRightAnswer) || question.questionRightAnswer > questionAnswersCount || question.questionRightAnswer < 1)
                    Exception($"[Ошибка!] На Шаге 6 введите целое число, не большее чем количество ответов.\n");

                Test.Add(question);
            }
            
            SaveTest(testName);

            Menu();
        }

        static void Exception(string message)
        {
            Console.Clear();

            Console.WriteLine(message);

            CreateNewTest();
        }
    }
}
