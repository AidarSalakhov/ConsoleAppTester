using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;


namespace ConsoleAppTester
{
    internal class FileOperations
    {
        public static void SaveTest(string testName)
        {
            try
            {
                string json = JsonConvert.SerializeObject(Test.newTest);
                File.WriteAllText(testName + Constants.SaveFileExtension, json);
            }
            catch (Exception)
            {
                Messages.SaveFailed(testName);
                Menu.ShowMenu();
            }
        }

        public static List<Test.Question> LoadTest(string testName)
        {
            try
            {
                string json = File.ReadAllText(testName + Constants.SaveFileExtension).ToString();
                return Test.newTest = JsonConvert.DeserializeObject<List<Test.Question>>(json);
            }
            catch (Exception)
            {
                Messages.LoadFailed(testName);
                Menu.ShowMenu();
                return new List<Test.Question>();
            }
        }

        public static void ViewDirectoryTests()
        {
            List<string> TxtFiles = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = dir.GetFiles("*" + Constants.SaveFileExtension + "*");

            foreach (FileInfo fi in files)
                TxtFiles.Add(fi.ToString());

            if (TxtFiles.Count < 1)
            {
                Messages.NoTests();
                Menu.ShowMenu();
            }

            Messages.GotTests(TxtFiles);
        }
    }
}
