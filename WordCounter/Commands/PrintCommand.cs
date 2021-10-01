using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Выводит в консоль данные открытого файла
/// </summary>
namespace WordCounter.Commands
{
    internal class PrintCommand : WordCounter.Command
    {
        public override void Execute()
        {
            FileHandler file = FileHandler.GetInstance();
            Program.LogFile($"Try Print command");
            if (String.IsNullOrEmpty(file.FilePath))
            {
                Program.Print("Нет открытого файла");
                Program.LogFile($"No open file", LogSatus.War);
            }
            else
            {
                Program.Print($"File Name: {file.FileName}");
                Program.Print($"Parse Time: {file.ParseTime}");
                var allWord = from entry in file.Dic orderby entry.Value select entry;
                foreach (var item in allWord)
                {
                    Program.Print(item.Key + "  " + item.Value);
                }
            }
            Program.LogFile($"Print command executed");
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
