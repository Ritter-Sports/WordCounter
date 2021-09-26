using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class OpenFileCommnad : Command
{
    FileHandler file;
    public OpenFileCommnad(FileHandler f) { 
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

