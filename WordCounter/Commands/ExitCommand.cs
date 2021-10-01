using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Commands;

/// <summary>
/// Завершает работу приложения
/// </summary>
internal class ExitCommand : WordCounter.Command
{
    public override void Execute()
    {
        Program.LogFile($"Exit command");
        Environment.Exit(0);
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

