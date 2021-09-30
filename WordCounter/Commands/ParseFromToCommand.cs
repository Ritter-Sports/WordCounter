using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class ParseFromToCommand : MacroCommand
{
    public ParseFromToCommand(params Command[] c) : base(c)
    {
    }
}

