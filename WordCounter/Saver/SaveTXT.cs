using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class SaveTXT:ISave
{
    public void Save(FileHandler file,string p) {

        string path =p+ file.FileName.Split('.')[0] + "Resault.txt";
        try
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                var sortedDic = from entry in file.Dic orderby entry.Value select entry;
                foreach (var item in sortedDic)
                {
                    sw.WriteLine(item.Key + "  " + item.Value);

                }

            }
        }catch (Exception ex) { 
            Program.Print(ex.Message);
        }
    }
    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}

