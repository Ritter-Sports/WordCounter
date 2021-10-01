using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;
/// <summary>
///  Сохраняет в файл данные из FileHandler
/// </summary>
internal class SaveCommand : Command
{
    string path;
    string extension;
    ISave saver;

    public SaveCommand( string p,string e)
    {
        
        path = p;
        extension = e;  
    }
    public override void Execute()
    {
        FileHandler file = FileHandler.GetInstance();
        Program.LogFile($"Try Save command with path:{path} fileFormat{extension}");
        if (String.IsNullOrEmpty(path))
        {
            Program.Print("Не указан путь для сохранения файла");
            Program.LogFile($"Empty path", LogSatus.War);
        }
        else if (String.IsNullOrEmpty(file.FilePath))
        {
            Program.Print("Нет открытого файла");
            Program.LogFile($"No open file", LogSatus.War);
        }
        else if (FileHandler.PathDirCheck(path))
        {
            switch (extension) {
                case "txt":
                    saver = new SaveTXT();
                    Program.LogFile($"Try TXT saver");
                    break;
                default:
                    Program.Print("Не поддерживаемый формат");
                    Program.LogFile($"Unsupported file format", LogSatus.War);
                    break;
            }
            
            saver.Save(file,path);
            Program.LogFile($"Save command executed");
        }
        else {
            Program.Print("Директория не сущесвтует или не доступна");
            Program.LogFile("Directory does not exist or is not accessible", LogSatus.Err);
        }       
        
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

