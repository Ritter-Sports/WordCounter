using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

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
        if (String.IsNullOrEmpty(file.FilePath))
        {
            Program.Print("Нет открытого файла");
        }
        string format = file.FileName.Split('.')[1];
        switch (format)
        {
            case "html":
                parser = new HtmlParse();
                break;
            default:
                throw new Exception("Не поддерживаемый формат файла");
                break;
        }
        parser.Parse(file);
       
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
   

}

