using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class OpenFileCommand : Command
{
    FileHandler file;
    public OpenFileCommand(FileHandler f) { 
        file = f;
    }
    public override void Execute()
    {    
        try
        {
            StreamReader sr = new StreamReader(file.filePath);
            Console.WriteLine("Файл успешно найден");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

