using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class HelpCommand : Command
{

    public override void Execute()
    {
        using (StreamReader sw = new StreamReader("help.txt"))
        {
            Program.Print(sw.ReadLine());
        }
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

