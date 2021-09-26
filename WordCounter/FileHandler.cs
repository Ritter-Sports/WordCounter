using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    internal class FileHandler
    {
        private static FileHandler instance;

        public string fileName;
        public string filePath;

        private FileHandler()
        {


        }
        public static FileHandler GetInstance()
        {
            if (instance == null)
                instance = new FileHandler();
            return instance;
        }
        public void SetName(string f) {

            filePath = f;
            string[] arr = f.Split('/');
            fileName = arr[arr.Length-1];
        }
        public void OpenFile() {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void ReadFile() {
            
        }
        public void SaveFile() { }
        public void PrintProccess() { }

    }
}
