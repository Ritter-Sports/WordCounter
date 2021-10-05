using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

/// <summary>
/// Создает новый FileHandler указывая путь и имя файла
/// </summary>
public class OpenCommand : Command
{
    string path;
    public OpenCommand(string p)
    {
        path = p;
    }
    public override void Execute()
    {
        Program.LogFile($"Try Open command with path:{path}");
        if (String.IsNullOrEmpty(path))
        {
            Program.Print("Не указан путь файла");
            Program.LogFile($"Empty path", LogSatus.War);
        }
        else
        {
            string? name = FileHandler.PathCheck(path);
            if (name == null)//если это не путь
            {
                name = FileHandler.URLCheck(path);
                if (name == null) //если это не путь и не url
                {
                    Program.Print("Не поддерживаемый формат файла");
                    Program.LogFile("Unsupported file format", LogSatus.Err);
                }
                else
                {
                    Program.Print("Файл успешно найден");
                    FileHandler file = FileHandler.CreateNew();
                    file.SetPath(path,name);
                    file.IsLocal = false;
                    Program.LogFile($"Open command executed");
                }
            }
            else {
                Program.Print("Файл успешно найден");
                FileHandler file = FileHandler.CreateNew();
                file.SetPath(path,name);              
                Program.LogFile($"Open command executed");
            }
           
        }
        

    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

