using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class SaveTXT:ISave
{
    /// <summary>
    /// Сохроняет данные из FileHandler в текстовый файл по указанному пути
    /// </summary>
    public void Save(FileHandler file,string p) {

        string path =p+ file.FileName.Split('.')[0] + "Resault.txt";
        try
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine($"File Name: {file.FileName}");
                sw.WriteLine($"Parse Time: {file.ParseTime}");

                var sortedDic = from entry in file.Dic orderby entry.Value select entry;
                foreach (var item in sortedDic)
                {
                    sw.WriteLine(item.Key + "  " + item.Value);

                }

            }
            Program.Print("Файл успешно сохранен");
        }catch (Exception ex) { 
            Program.Print(ex.Message);
        }
    }
    /// <summary>
    /// Добавлет одну строку в указанный поток
    /// </summary>
    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}

