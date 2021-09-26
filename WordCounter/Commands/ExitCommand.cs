using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Commands;

internal class ExitCommand : Command
{
    public override void Execute()
    {
        Environment.Exit(0);
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

