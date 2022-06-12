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
                string json = JsonConvert.SerializeObject(TestOperations.newTest);
                File.WriteAllText(testName + Constants.SaveFileExtension, json);
            }
            catch (Exception)
            {
                ShowMessage.Error(3);
                Menu.ShowMenu();
            }
        }

        public static List<TestContent.Question> LoadTest(string testName)
        {
            try
            {
                string json = File.ReadAllText(testName + Constants.SaveFileExtension).ToString();
                return TestOperations.newTest = JsonConvert.DeserializeObject<List<TestContent.Question>>(json);
            }
            catch (Exception)
            {
                ShowMessage.Error(7);
                Menu.ShowMenu();
                return new List<TestContent.Question>();
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
                ShowMessage.Info(2);
                Menu.ShowMenu();
            }

            for (int i = 0; i < TxtFiles.Count; i++)
                Console.WriteLine(Path.GetFileNameWithoutExtension(TxtFiles[i]));
        }
    }
}
