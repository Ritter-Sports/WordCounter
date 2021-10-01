using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    public class FileHandler
    {
        private static FileHandler instance;

        private string fileName;
        public string FileName { get { return fileName; } }

        private string filePath;
        public string FilePath { get { return filePath; } }

        public DateTime ParseTime { get; set; }

        private Dictionary<string, int> dic = new Dictionary<string, int>();
        public Dictionary<string, int> Dic { get { return dic; } set { dic = value; } }


        private FileHandler()
        {


        }
        public static FileHandler GetInstance()
        {
            if (instance == null)
                instance = new FileHandler();
            return instance;
        }
        public static FileHandler CreateNew() {
            instance = new FileHandler();
            return instance;
        }


        public void SetPath(string f)
        {
            filePath = f;
            string[] arr = f.Split(@"\",'/');
            fileName = arr[arr.Length - 1];
        }

        /// <summary>
        /// Проверяет указывает ли путь в существующий и доступный файл
        /// </summary>
        public static bool PathCheck(string path)
        {
            try
            {
                FileStream fs = File.Open(path,FileMode.Open);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

           
        }

        /// <summary>
        /// Проверяет указывает ли путь в существующую директорию
        /// </summary>
        public static bool PathDirCheck(string path)
        {
            FileAttributes fileAttributes = File.GetAttributes(path);

            if (fileAttributes.HasFlag(FileAttributes.Directory))
            {
                return true;
            }
            return false;

        }

    }
}
