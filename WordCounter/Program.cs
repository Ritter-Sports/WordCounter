using WordCounter.Commands;
namespace WordCounter;

public class Program
{
    public static void Main()
    {
        Invoker invoker = new Invoker();
        FileHandler fileHandler;
        do
        {
            string[] command = Console.ReadLine().Split(' ');

            switch (command[0])
            {
                case "OpenFile":
                    if (command.Length != 2 && File.Exists(command[1]))
                    {
                        Console.WriteLine("некоректный путь файла или файл не доступен");
                        break;
                    }
                    fileHandler = FileHandler.GetInstance();
                    fileHandler.SetName(command[1]);
                    Command openFileCommand = new OpenFileCommand(fileHandler);
                    invoker.SetCommand(openFileCommand);
                    invoker.Run();
                    break;

                case "PrintResault":
                    if (String.IsNullOrEmpty(fileHandler.filePath))
                    {
                        Console.WriteLine("Нет открытого файла");
                    }
                    else
                    {
                        FileAttributes fileAttributes = File.GetAttributes(fileHandler.filePath);

                        if (command.Length != 2 && !fileAttributes.HasFlag(FileAttributes.Directory))
                        {
                            Console.WriteLine("некоректный путь деректоктории");
                            break;
                        }
                    }
                    break;

                case "ReadFile":

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
        } while (true);
    }
}

