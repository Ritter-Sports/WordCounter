using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

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
        if (String.IsNullOrEmpty(path))
        {
            Program.Print("Не указан путь файла");
        }
        else if (FileHandler.PathCheck(path)) {
            
            Program.Print("Файл успешно найден");
            file.SetPath(path);
        }
        else {
            Program.Print("Файл не существует или к нему нет доступа");
        }
            
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

