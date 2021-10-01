using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Text;
using WordCounter.Commands;
namespace WordCounter;


public class Program
{
    public static ILogger<Logger> logger;
    public static void Main()
    {
        Log.Logger = new LoggerConfiguration()
          .WriteTo.File(@"..\..\..\consoleapp.log")
          .CreateLogger();

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        logger = serviceProvider.GetService<ILogger<Logger>>();

        Invoker invoker = new Invoker();//исполнитель команд
        FileHandler fileHandler;//представление файла

        do
        {
            string command = Console.ReadLine();

            switch (command.Split(' ')[0])
            {
                case "Open":
                    string path = command.Substring(4).Trim();
                    Command openCommand = new OpenCommand(path);
                    invoker.SetCommand(openCommand);
                    invoker.Run();

                    break;

                case "Print":
                    Command printCommand = new PrintCommand();
                    invoker.SetCommand(printCommand);
                    invoker.Run();
                    break;

                case "Save":

                    string[] param = command.Substring(4).Trim().Split(' ');
                    if (param.Length != 2)
                    {
                        Print("Не верные параметры");
                        break;
                    }
                    Command SaveCommand = new SaveCommand( param[0], param[1]);
                    invoker.SetCommand(SaveCommand);
                    invoker.Run();
                    break;

                case "Parse":
                    Command openFileCommnad = new ParseCommand();
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
                    param = command.Substring(11).Trim().Split(' ');
                    if (param.Length != 3)
                    {
                        Print("Не верные параметры");
                        break;
                    }

                    Command allCommand = new ParseFromToCommand(param[0], param[1], param[2]);
                    invoker.SetCommand(allCommand);
                    invoker.Run();
                    break;

                default:
                    Print("Такой команды не сущесвтует");
                    break;
            }
        } while (true);
    }
    /// <summary>
    /// Осуществляет вывод в консоль
    /// </summary>
    public static void Print(string text)
    {
        Console.WriteLine(text);
    }
    public static void LogFile(string text)
    {
        if (logger != null)
            logger.LogInformation(text);
    }
    public static void LogFile(string text, LogSatus lg)
    {
        if (logger != null)
        {
            switch (lg)
            {
                case LogSatus.Info:
                    logger.LogInformation(text);
                    break;
                case LogSatus.War:
                    logger.LogWarning(text);
                    break;
                case LogSatus.Err:
                    logger.LogError(text);
                    break;
            }
        }

    }
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(configure => configure.AddSerilog())
               .AddTransient<Logger>();
    }


}

public enum LogSatus
{
    Info = 0,
    War,
    Err
}