using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

abstract class MacroCommand : Command
{
    Command[] command;
    public MacroCommand(params Command[] c) {
        command = c;
    }
    public override void Execute()
    {
        foreach (var c in command) {
            c.Execute();        
        }
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

