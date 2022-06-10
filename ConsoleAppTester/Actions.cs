using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTester
{
    internal class Actions
    {
        public static void StartTest()
        {
            Messages.WriteTestName();

            string testName = Console.ReadLine();

            FileOperations.LoadTest(testName);

            int userRightAnswers = 0;

            for (int i = 0; i < Test.newTest.Count; i++)
            {
                Console.WriteLine($"\n{Test.newTest[i].question}");

                Console.WriteLine("Варианты ответов:");

                for (int j = 0; j < Test.newTest[i].questionAnswers.Length; j++)
                    Console.Write($"{j + 1}) {Test.newTest[i].questionAnswers[j]}\t");

                Console.WriteLine("\nВведите номер правильного ответа:");

                if (!double.TryParse(Console.ReadLine(), out double userAnswer) || userAnswer > Test.newTest[i].questionAnswers.Length || 1 > userAnswer)
                    Exceptions.Error(4);

                if (userAnswer == Test.newTest[i].questionRightAnswer)
                    userRightAnswers++;
            }

            Console.Clear();

            Console.WriteLine($"---Тест завершён в {DateTime.Now}---\n\nПроцент правильных ответов: {System.Math.Round((double)(userRightAnswers / Convert.ToDouble(Test.newTest.Count) * 100))}%\n");

            Test.newTest.Clear();

            Menu.ShowMenu();
        }

        public static void CreateNewTest()
        {
            Test.newTest.Clear();

            Console.WriteLine("/Конструктор теста. Шаг 1 из 6/ Введите название теста:");
            string testName = Console.ReadLine();

            Console.WriteLine("\n/Конструктор теста. Шаг 2 из 6/ Введите количество вопросов теста:");
            if (!int.TryParse(Console.ReadLine(), out int testQuestionsCount))
            {
                Exceptions.Error(5);
                CreateNewTest();
            }

            Console.WriteLine("\n/Конструктор теста. Шаг 3 из 6/ Введите количество вариантов ответов вопроса (не менее 2):");
            if (!int.TryParse(Console.ReadLine(), out int questionAnswersCount) || questionAnswersCount < 2)
            {
                Exceptions.Error(6);
                CreateNewTest();
            }

            for (int i = 0; i < testQuestionsCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"\n/Конструктор теста. Шаг 4 из 6/ Введите вопрос теста #{i + 1}:");
                Test.question.question = Console.ReadLine();
                Test.question.questionAnswers = new string[questionAnswersCount];

                for (int j = 0; j < questionAnswersCount; j++)
                {
                    Console.WriteLine($"\n/Конструктор теста. Шаг 5 из 6/ Введите вариант ответа ({j + 1}):");
                    Test.question.questionAnswers[j] = Console.ReadLine();
                }

                Console.WriteLine("\n/Конструктор теста. Шаг 6 из 6/ Введите номер правильного ответа:");
                if (!int.TryParse(Console.ReadLine(), out Test.question.questionRightAnswer) || Test.question.questionRightAnswer > questionAnswersCount || Test.question.questionRightAnswer < 1)
                {
                    Exceptions.Error(7);
                    Actions.CreateNewTest();
                }

                Test.newTest.Add(Test.question);
            }

            FileOperations.SaveTest(testName);

            Messages.SaveSuccessful(testName);

            Menu.ShowMenu();
        }
    }
}
