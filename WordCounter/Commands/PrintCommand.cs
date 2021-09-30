using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter.Commands
{
    internal class PrintCommand : WordCounter.Command
    {
        FileHandler file;
        public PrintCommand(FileHandler f)
        {
            file = f;
        }
        public override void Execute()
        {
            if (String.IsNullOrEmpty(file.FilePath))
            {
                Program.Print("Нет открытого файла");
            }
            else
            {
                var allWord = from entry in file.Dic orderby entry.Value select entry;
                foreach (var item in allWord)
                {
                    Program.Print(item.Key + "  " + item.Value);
                }
            }
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
