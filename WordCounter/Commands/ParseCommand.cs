using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

/// <summary>
/// Осуществляет парсинг открытого файла
/// </summary>
public class ParseCommand : Command
{
    
    IParser parser;
   
    public override void Execute()
    {
        FileHandler file = FileHandler.GetInstance();
        Program.LogFile($"Try Parse command");
        if (String.IsNullOrEmpty(file.FilePath))
        {
            Program.Print("Нет открытого файла");
            Program.LogFile($"No open file", LogSatus.War);
        }
        else
        {
            //выбирает класс обработки в зависимости от расшиерния файла
            string format = file.FileName.Split('.').Last();
            switch (format)
            {
                case "html":
                    parser = new HtmlParse();
                    Program.LogFile($"HTMl parse");
                    break;              
                default:
                    Program.Print("Не поддерживаемый формат файла");
                    Program.LogFile($"Unsupported file format", LogSatus.War);
                    break;
            }
            if (parser != null)
            {
                parser.Parse(file);
                Program.LogFile($"Parse command executed");
            }
        }
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
   

}

