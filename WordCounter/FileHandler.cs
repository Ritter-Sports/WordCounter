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

        private IParser parser;


        private FileHandler()
        {


        }
        public static FileHandler GetInstance()
        {
            if (instance == null)
                instance = new FileHandler();
            return instance;
        }

        //<summary>
        //Устанавливает имя и путь к файлу
        //</summary>
        public void SetName(string f)
        {

            filePath = f;
            string[] arr = f.Split('/');
            fileName = arr[arr.Length - 1];
        }
        public void ReadFile()
        {
            string format = fileName.Split('.')[1];
            switch (format)
            {
                case "html":
                    parser = new HtmlParse();
                    break;
                default:
                    throw new Exception("Не поддерживаемый формат файла");
                    break;
            }
            PrintResault(parser.Pars(filePath));

        }
        public void SaveFile() { }
        public void PrintProccess() { }
        public void PrintResault(Dictionary<string, int> dic)
        {
            var sortedDic = from entry in dic orderby entry.Value ascending select entry;
            foreach (var item in sortedDic)
            {
                Console.WriteLine(item.Key + "  " + item.Value);
            }
        }
    }
}
