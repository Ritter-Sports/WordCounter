using WordCounter.Commands;
namespace WordCounter;

public class Program
{
    public static void Main() {
        Invoker invoker = new Invoker();
        FileHandler fileHandler;
        do
        {
            string[] command = Console.ReadLine().Split(' ');

            switch (command[0])
            {

                case "ReadFile":                  
                    fileHandler = FileHandler.GetInstance();
                    if (String.IsNullOrEmpty(fileHandler.filePath))
                    {
                        Console.WriteLine("Нет открытого файла");
                    }
                    else
                    {
                        Command openFileCommnad = new ReadFileCommand(fileHandler);
                        invoker.SetCommand(openFileCommnad);
                        invoker.Run();
                    }
                    break;
                case "OpenFile":
                    if ( command.Length!=2)
                    {
                        Console.WriteLine("некоректный путь файла");
                        break;
                    }
                    Console.WriteLine($"Поиск файла {command[1]}");

                    fileHandler = FileHandler.GetInstance();
                    fileHandler.SetName(command[1]);

                    Command openFileCommand = new OpenFileCommand(fileHandler);    
                    invoker.SetCommand(openFileCommand);
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

