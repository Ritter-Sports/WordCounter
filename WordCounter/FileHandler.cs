using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

public class FileHandler
{
    private static FileHandler instance;

    private string fileName;
    public string FileName { get { return fileName; } }

    private string filePath;
    public string FilePath { get { return filePath; } }

    private bool isLocal;
    public bool IsLocal { get { return isLocal; }set { isLocal = value; } }

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
    public static FileHandler CreateNew()
    {
        instance = new FileHandler();
        return instance;
    }


    public void SetPath(string f)
    {
        filePath = f;
        string[] arr = f.Split(@"\", '/');
        fileName = arr[arr.Length - 1];
    }
    public void SetPath(string f,string n)
    {
        filePath = f;           
        fileName = n;
    }

        /// <summary>
        /// Проверяет указывает ли путь в существующий и доступный файл или юрл
        /// </summary>
        /// <returns>Возвращает имя файла с расширением, если файл не поддерживается возвращает null</returns>
        public static string PathCheck(string path)//вложенный try catch не хорошо
    {
        try
        {

            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                string format = path.Split('.').Last();
                string name = path.Split(@"\").Last();
                switch (format)
                {
                    case "html":
                        return name;
                    default:
                        return null;
                }
            }
            return null;

        }
        catch (Exception e)
        {         
            return null;
        }


    }
    /// <summary>
    /// Проверяет указывает ли ссылка на файл или html-страницу
    /// </summary>
    /// <returns>Возвращает имя файла с расширением, если файл не поддерживается возвращает null</returns>
    public static string URLCheck(string path)//вложенный try catch не хорошо
    {

        try
        {
            WebClient webClient = new WebClient();
            using (Stream stream = webClient.OpenRead(path))
            {
                var request = HttpWebRequest.Create(path);
                request.Method = "HEAD";
                string r = request.GetResponse().ContentType.Split(';').First();
                switch (r)
                {
                    case "text/plain":
                        return "txt";
                    case "text/html":
                        return "html";
                    default:                       
                        return null;
                }
            }
            return null;
        }
        catch (Exception e2)
        {           
            return null;
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

