using System.Text;
using WordCounter.Commands;
namespace WordCounter;

public class Program
{
    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
    public static void Main()
    {

        Invoker invoker = new Invoker();

        do
        {
            string[] command = Console.ReadLine().Split(' ');

            switch (command[0])
            {
                case "Open":
                    FileHandler fileHandler = FileHandler.CreateNew();
                    Command openCommand = new OpenCommand(fileHandler, command[1]);
                    invoker.SetCommand(openCommand);
                    invoker.Run();
                    break;

                case "Print":
                    fileHandler = FileHandler.GetInstance();
                    Command printCommand = new PrintCommand(fileHandler);
                    invoker.SetCommand(printCommand);
                    invoker.Run();
                    break;

                case "Save":
                    fileHandler = FileHandler.GetInstance();
                    Command SaveCommand = new SaveCommand(fileHandler, command[1], command[2]);
                    invoker.SetCommand(SaveCommand);
                    invoker.Run();
                    break;

                case "Parse":
                    fileHandler = FileHandler.GetInstance();
                    Command openFileCommnad = new ParseCommand(fileHandler);
                    invoker.SetCommand(openFileCommnad);
                    invoker.Run();
                    break;

                case "Help":
                    Command helpCommand = new HelpCommand();
                    invoker.SetCommand(helpCommand);
                    invoker.Run();
                    break;

                case "Exit":
                    Print("GoodBye!");
                    ExitCommand exitCommand = new ExitCommand();
                    invoker.SetCommand(exitCommand);
                    invoker.Run();
                    break;

                case "ParseFromTo":
                    fileHandler = FileHandler.CreateNew();
                    Command open = new OpenCommand(fileHandler, command[1]);
                    Command parse = new ParseCommand(fileHandler);
                    Command save = new SaveCommand(fileHandler, command[2], command[3]);
                    Command allCommand = new ParseFromToCommand(open, parse, save);
                    invoker.SetCommand(allCommand);
                    invoker.Run();
                    break;

                default:
                    Print("Такой команды не сущесвтует");
                    break;
            }
        } while (true);
    }
    public static void Print(string text)
    {
        Console.WriteLine(text);
    }

}

