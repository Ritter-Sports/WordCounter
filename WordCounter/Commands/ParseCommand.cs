using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

/// <summary>
/// Осуществляет парсинг открытого файла
/// </summary>
internal class ParseCommand : Command
{
    FileHandler file;
    IParser parser;
    public ParseCommand(FileHandler f)
    {
        file = f;
    }
    public override void Execute()
    {
        Program.LogFile($"Try Parse command");
        if (String.IsNullOrEmpty(file.FilePath))
        {
            Program.Print("Нет открытого файла");
            Program.LogFile($"No open file", LogSatus.War);
        }
        //выбирает класс обработки в зависимости от расшиерния файла
        string format = file.FileName.Split('.')[1];
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
        parser.Parse(file);
        Program.LogFile($"Parse command executed");
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
   

}

