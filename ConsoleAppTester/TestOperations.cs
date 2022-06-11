﻿using System;
using System.Collections.Generic;

namespace ConsoleAppTester
{
    internal class TestOperations
    {
        public static List<TestContent.Question> newTest = new List<TestContent.Question>();

        public static TestContent.Question question = new TestContent.Question();

        public static void StartTest()
        {
            ShowMessage.Info(3);
            string testName = Console.ReadLine();
            FileOperations.LoadTest(testName);
            int userRightAnswers = 0;

            for (int i = 0; i < newTest.Count; i++)
            {
                Console.WriteLine($"\n{newTest[i].question}");
                ShowMessage.Info(6);

                for (int j = 0; j < newTest[i].questionAnswers.Length; j++)
                    Console.Write($"{j + 1}) {newTest[i].questionAnswers[j]}\t");

                ShowMessage.Info(7);

                if (!double.TryParse(Console.ReadLine(), out double userAnswer) || userAnswer > newTest[i].questionAnswers.Length || 1 > userAnswer)
                    ShowMessage.Error(4);

                if (userAnswer == newTest[i].questionRightAnswer)
                    userRightAnswers++;
            }

            Console.Clear();
            ShowMessage.Info(8);
            Console.Write(Math.Round((double)(userRightAnswers / Convert.ToDouble(newTest.Count) * 100)) + "%");
            newTest.Clear();
            Menu.ShowMenu();
        }

        public static void CreateNewTest()
        {
            newTest.Clear();

            ShowMessage.Info(9);
            string testName = Console.ReadLine();

            ShowMessage.Info(10);
            if (!int.TryParse(Console.ReadLine(), out int testQuestionsCount))
            {
                ShowMessage.Error(5);
                CreateNewTest();
            }

            ShowMessage.Info(11);
            if (!int.TryParse(Console.ReadLine(), out int questionAnswersCount) || questionAnswersCount < 2)
            {
                ShowMessage.Error(6);
                CreateNewTest();
            }

            for (int i = 0; i < testQuestionsCount; i++)
            {
                Console.Clear();
                ShowMessage.Info(12);
                Console.Write(i + 1);
                question.question = Console.ReadLine();
                question.questionAnswers = new string[questionAnswersCount];

                for (int j = 0; j < questionAnswersCount; j++)
                {
                    ShowMessage.Info(13);
                    Console.Write(i + 1);
                    question.questionAnswers[j] = Console.ReadLine();
                }

                ShowMessage.Info(14);
                if (!int.TryParse(Console.ReadLine(), out question.questionRightAnswer) || question.questionRightAnswer > questionAnswersCount || question.questionRightAnswer < 1)
                {
                    ShowMessage.Error(7);
                    CreateNewTest();
                }

                newTest.Add(question);
            }

            FileOperations.SaveTest(testName);
            ShowMessage.Info(1);
            Menu.ShowMenu();
        }
    }
}
