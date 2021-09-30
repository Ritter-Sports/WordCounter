using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class SaveCommand : Command
{
    FileHandler file;

    string path;
    string extension;
    ISave saver;

    public SaveCommand(FileHandler f, string p,string e)
    {
        file = f;
        path = p;
        extension = e;  
    }
    public override void Execute()
    {
        if (String.IsNullOrEmpty(path))
        {
            Program.Print("Не указан путь для сохранения файла");
        }
        else if (String.IsNullOrEmpty(file.FilePath))
        {
            Program.Print("Нет открытого файла");
        }
        else if (FileHandler.PathDirCheck(path))
        {
            switch (extension) {
                case "txt":
                    saver = new SaveTXT();
                    break;
                default:
                    Program.Print("Не поддерживаемый формат");
                    break;
            }
            
            saver.Save(file,path);
        }
        else {
            Program.Print("Директория не сущесвтует или не доступна");
        }       
        
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

