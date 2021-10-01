using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

/// <summary>
/// Выводит на экран список всех команд
/// </summary>
internal class HelpCommand : Command
{
   
    public override void Execute()
    {
        Program.LogFile($"Try Help command");
        try
        {
            using (StreamReader sw = new StreamReader("help.txt"))
            {
                do
                {
                    string? row = sw.ReadLine();
                    if (row == null)
                    {
                        break;
                    }
                    Program.Print(row);
                } while (true);

            }
            Program.LogFile($"Help command executed");
        }
        catch(Exception ex)
        {
            Program.Print("Не удалось обнаружить файл help.txt");
            Program.LogFile($"Can't find help.txt",LogSatus.War);
        }
    }

    public override void Undo()
    {
        throw new NotImplementedException();
    }
}

