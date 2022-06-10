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
            File.LoadTest();

            int userRightAnswers = 0;

            for (int i = 0; i < Test.Count; i++)
            {
                Console.WriteLine($"\n{Test[i].question}");

                Console.WriteLine("Варианты ответов:");

                for (int j = 0; j < Test[i].questionAnswers.Length; j++)
                    Console.Write($"{j + 1}) {Test[i].questionAnswers[j]}\t");

                Console.WriteLine("\nВведите номер правильного ответа:");

                if (!double.TryParse(Console.ReadLine(), out double userAnswer) || userAnswer > Test[i].questionAnswers.Length || 1 > userAnswer)
                    Console.WriteLine("[Ошибка!] Вы ввели номер несуществующего ответа, либо некорректный символ. Ваш ответ засчитан как неверный.");

                if (userAnswer == Test[i].questionRightAnswer)
                    userRightAnswers++;
            }

            Console.Clear();

            Console.WriteLine($"---Тест завершён в {DateTime.Now}---\n\nПроцент правильных ответов: {System.Math.Round((double)(userRightAnswers / Convert.ToDouble(Test.Count) * 100))}%\n");

            Test.Clear();

            Menu.ShowMenu();
        }

        public static void CreateNewTest()
        {
            Test.Clear();

            Console.WriteLine("/Конструктор теста. Шаг 1 из 6/ Введите название теста:");
            string testName = Console.ReadLine();

            Console.WriteLine("\n/Конструктор теста. Шаг 2 из 6/ Введите количество вопросов теста:");
            if (!int.TryParse(Console.ReadLine(), out int testQuestionsCount))
                Exceptions.Exception("[Ошибка!] На Шаге 2 введите целое число.\n");

            Console.WriteLine("\n/Конструктор теста. Шаг 3 из 6/ Введите количество вариантов ответов вопроса (не менее 2):");
            if (!int.TryParse(Console.ReadLine(), out int questionAnswersCount) || questionAnswersCount < 2)
                Exceptions.Exception("[Ошибка!] На Шаге 3 введите целое число, большее чем 1.\n");

            for (int i = 0; i < testQuestionsCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"\n/Конструктор теста. Шаг 4 из 6/ Введите вопрос теста #{i + 1}:");
                question.question = Console.ReadLine();
                question.questionAnswers = new string[questionAnswersCount];

                for (int j = 0; j < questionAnswersCount; j++)
                {
                    Console.WriteLine($"\n/Конструктор теста. Шаг 5 из 6/ Введите вариант ответа ({j + 1}):");
                    question.questionAnswers[j] = Console.ReadLine();
                }

                Console.WriteLine("\n/Конструктор теста. Шаг 6 из 6/ Введите номер правильного ответа:");
                if (!int.TryParse(Console.ReadLine(), out question.questionRightAnswer) || question.questionRightAnswer > questionAnswersCount || question.questionRightAnswer < 1)
                    Exceptions.Exception($"[Ошибка!] На Шаге 6 введите целое число, не большее чем количество ответов.\n");

                Test.Add(question);
            }

            File.SaveTest(testName);

            Menu.ShowMenu();
        }
    }
}
