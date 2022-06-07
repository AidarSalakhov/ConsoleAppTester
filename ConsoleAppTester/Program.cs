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
        public struct Test
        {
            public int answerCount;
            public string questionText;
            public string[] answersArray;
        }

        static void CreateNewTest()
        {
            Test test = new Test();

            List<Test> list = new List<Test>();

            Console.WriteLine("Введите название теста");
            string testName = Console.ReadLine();

            Console.WriteLine("Введите количество вопросов теста");
            int questionCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < questionCount; i++)
            {
                Console.WriteLine($"Введите вопрос теста №{i+1}");
                test.questionText = Console.ReadLine();

                Console.WriteLine("Введите количество вариантов ответа");
                test.answerCount = int.Parse(Console.ReadLine());

                for (int j = 1; j < test.answerCount; j++)
                {
                    Console.WriteLine($"Введите вариант ответа №{j}");
                    test.answersArray[j-1] = Console.ReadLine();


                }

                list.Add(test);
            }

            

            

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
