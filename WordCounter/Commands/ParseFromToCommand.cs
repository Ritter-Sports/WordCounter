﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class ParseFromToCommand : MacroCommand
{
    /// <summary>
    /// Макро команда выполняющая последовательно команды Open, Parse, Save
    /// </summary>
    public ParseFromToCommand(string from,string to ,string ex) 
    {
        Program.LogFile($"Try ParseFromTo command with fromPath:{from} toPath:{to} fileFormat{ex}");
        FileHandler fileHandler = FileHandler.CreateNew();
        Command open = new OpenCommand(fileHandler, from);
        Command parse = new ParseCommand(fileHandler);
        Command save = new SaveCommand(fileHandler, to, ex);
        base.Commands = new Command[] { open, parse, save };
        Program.LogFile($"ParseFromTo command executed");
    }
}

