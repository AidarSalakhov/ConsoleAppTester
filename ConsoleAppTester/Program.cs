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

        public struct Question
        {
            public string testName;
            public int testQuestionsCount;
            public int questionAnswersCount;
            public string question;
            public string[] questionAnswers;
            public int questionRightAnswer;

            public Question(string testName, int testQuestionsCount, int questionAnswersCount) :this()
            {
                this.testName = testName;
                this.testQuestionsCount = testQuestionsCount;
                this.questionAnswersCount = questionAnswersCount;
            }

            public Question(string question, string[] questionAnswers, int questionRightAnswer) : this()
            {
                this.question = question;
                this.questionAnswers = questionAnswers;
                this.questionRightAnswer = questionRightAnswer;
            }
        }

        static void SaveTest(string testName)
        {
            string json = JsonConvert.SerializeObject(Test);
            File.WriteAllText($"{testName}.txt", json);
        }

        static void CreateNewTest()
        {
            Question question = new Question();

            Console.WriteLine("Введите название теста");
            question.testName = Console.ReadLine();

            Console.WriteLine("Введите количество вопросов теста");
            question.testQuestionsCount = int.Parse(Console.ReadLine());
            question.questionsArray = new string[question.testQuestionsCount];

            Console.WriteLine("Введите количество вариантов ответа");
            question.questionAnswersCount = int.Parse(Console.ReadLine());
            question.answersArray = new string[question.testQuestionsCount, question.questionAnswersCount];

            for (int i = 0; i < question.testQuestionsCount; i++)
            {
                Console.WriteLine($"Введите вопрос теста №{i+1}");
                question.questionsArray[i] = Console.ReadLine();

                for (int j = 0; j < question.questionAnswersCount; j++)
                {
                    Console.WriteLine($"Введите вариант ответа №{j+1}");
                    question.answersArray[i,j] = Console.ReadLine();
                }

                Console.WriteLine("Введите номер правильно ответа");
                question.rightAnswersArray = new int[question.testQuestionsCount];
                question.rightAnswersArray[i] = int.Parse(Console.ReadLine());
            }

            SaveTest(question.testName);

            Test.Add(question);
        }

        static void StartTest()
        {

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
                    Console.Clear();
                    break;

                case ConsoleKey.N:
                    Console.Clear();
                    CreateNewTest();
                    break;

                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
