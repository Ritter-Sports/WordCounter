using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class ReadFileCommand : Command
{
    FileHandler file;
    public ReadFileCommand(FileHandler f)
    {
        file = f;
    }
    public override void Execute()
    {
        file.ReadFile();
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
   

}

