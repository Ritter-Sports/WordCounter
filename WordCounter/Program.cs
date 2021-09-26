using WordCounter.Commands;
namespace WordCounter;

public class Program
{
    public static void Main() {
        Invoker invoker = new Invoker();
        do
        {
            string[] command = Console.ReadLine().Split(' ');

            switch (command[0])
            {
                case "OpenFile":
                    if ( command.Length!=2)
                    {
                        Console.WriteLine("некоректный путь файла");
                        break;
                    }
                    Console.WriteLine($"Поиск файла {command[1]}");
                    FileHandler fileHandler = FileHandler.GetInstance();
                    fileHandler.SetName(command[1]);
                    OpenFileCommnad openFileCommnad = new OpenFileCommnad(fileHandler);    
                    invoker.SetCommand(openFileCommnad);
                    invoker.Run();
                    break;
                case "Exit":
                    Console.WriteLine("GoodBye!");
                    ExitCommand exitCommand = new ExitCommand();
                    invoker.SetCommand(exitCommand);
                    invoker.Run();
                    break;
                default:
                    Console.WriteLine("Такой команды не сущесвтует");
                    break;
            }
        }while (true);
    }
}

