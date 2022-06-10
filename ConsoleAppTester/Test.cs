using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTester
{
    internal class Test
    {
        public static List<Question> newTest = new List<Question>();

        public static Question question = new Question();

        public struct Question
        {
            public string question;
            public string[] questionAnswers;
            public int questionRightAnswer;
        }
    }
}
