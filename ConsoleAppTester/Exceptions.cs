using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTester
{
    public static class Exceptions
    {
        public static void Error(int code)
        {
            string[] errors = new string[]
            {
               "[Ошибка 000] Вы нажали неверную клавишу!\n",
               "[Ошибка 001] Введённого вами теста не существует!\n",
               "[Ошибка 003] Не удалось сохранить тест!\n",
               "[Ошибка 004] Вы ввели номер несуществующего ответа, либо некорректный символ. Ваш ответ засчитан как неверный!\n",
               "[Ошибка 005] На Шаге 2 введите целое число!\n",
               "[Ошибка 006] На Шаге 3 введите целое число, большее чем 1!\n",
               "[Ошибка 007] На Шаге 6 введите целое число, не большее чем количество ответов!\n"
            };

            Console.WriteLine(errors[code]);
        }
    }
}







