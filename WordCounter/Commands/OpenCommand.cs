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
    FileHandler file;
    string path;
    public OpenCommand(FileHandler f,string p) {        
        file = f;
        path = p;
    }
    public override void Execute()
    {
        Program.LogFile($"Try Open command with path:{path}");
        if (String.IsNullOrEmpty(path))
        {
            Program.Print("Не указан путь файла");
            Program.LogFile($"Empty path",LogSatus.War);
        }
        else if (FileHandler.PathCheck(path)) {
            
            Program.Print("Файл успешно найден");
            file.SetPath(path);
            Program.LogFile($"Open command executed");

        }
        else {
            Program.Print("Файл не существует или к нему нет доступа");
            Program.LogFile($"Bad path", LogSatus.War);
        }
            
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

