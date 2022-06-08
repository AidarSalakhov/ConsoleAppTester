using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

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
            Console.WriteLine("\n\t----Выберите действие----");
            Console.WriteLine("\t[S] - Пройти тест");
            Console.WriteLine("\t[N] - Создать тест");

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.S:
                    StartTest();
                    break;

                case ConsoleKey.N:
                    CreateNewTest();
                    break;

                default:
                    break;
            }
        }

        static void SaveTest(string testName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Test);
                File.WriteAllText($"{testName}.txt", json);
            }
            catch (Exception) 
            {
                Console.Clear();
                Console.WriteLine("Ошибка! Не удалось сохранить!\n");
                Menu();
            }
        }

        static double PrintTest()
        {
            int userRightAnswers = 0;

            for (int i = 0; i < Test.Count; i++)
            {
                Console.WriteLine(Test[i].question);

                Console.WriteLine("\nВарианты ответов:");

                for (int j = 0; j < Test[i].questionAnswers.Length; j++)
                {
                    Console.Write($"{j+1}) {Test[i].questionAnswers[j]}\t");
                }

                Console.WriteLine("\nВведите номер правильного ответа:");

                double userAnswer = int.Parse(Console.ReadLine());

                if (userAnswer == Test[i].questionRightAnswer)
                {
                    userRightAnswers++;
                }
            }

            double percentRightAnswers = System.Math.Round((double)(userRightAnswers / Convert.ToDouble(Test.Count) * 100));

            return percentRightAnswers;
        }

        static void LoadTest(string testName)
        {
            try
            {
                string json = File.ReadAllText($"{testName}.txt").ToString();

                Test = JsonConvert.DeserializeObject<List<Question>>(json);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Ошибка! Такого теста не существует!\n");
                Menu();
            }
        }

        static void CreateNewTest()
        {
            Console.Clear();
            
            Console.WriteLine("\nВведите название теста:");
            string testName = Console.ReadLine();

            Console.WriteLine("\nВведите количество вопросов теста:");
            int testQuestionsCount = int.Parse(Console.ReadLine());

            Console.WriteLine("\nВведите количество вариантов ответа одного вопроса:");
            int questionAnswersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < testQuestionsCount; i++)
            {
                Console.Clear();

                Console.WriteLine($"\nВведите вопрос теста #{i+1}:");
                question.question = Console.ReadLine();

                question.questionAnswers = new string[questionAnswersCount];

                for (int j = 0; j < questionAnswersCount; j++)
                {
                    Console.WriteLine($"\n\tВведите вариант ответа ({j+1}):");
                    
                    question.questionAnswers[j] = Console.ReadLine();
                }

                Console.WriteLine("\nВведите номер правильного ответа:");
                question.questionRightAnswer = int.Parse(Console.ReadLine());

                Test.Add(question);
            }
            
            SaveTest(testName);

            Console.Clear();

            Console.WriteLine($"\nТест сохранён в файл. Название теста для его прохождения: {testName}");

            Menu();
        }

        static void StartTest()
        {
            Console.Clear();

            Console.WriteLine("Введите название теста для его прохождения:");

            string testName = Console.ReadLine();

            LoadTest(testName);

            Console.Clear();

            Console.WriteLine($"Тест завершён. Процент правильных ответов: {PrintTest()}");

            Menu();
        }
    }
}
