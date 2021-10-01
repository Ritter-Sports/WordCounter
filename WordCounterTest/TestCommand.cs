using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter;

namespace WordCounterTest;

public class TestCommand
{
    [Test]
    public void ReopenTest()//Не корректный вызов команды Open не стирает данные
    {
        Invoker invoker = new Invoker();
        string path = @"..\..\..\test\file4.html";

        //команда открыть тестовый файл
        Command openFileCommand = new OpenCommand(path);
        invoker.SetCommand(openFileCommand);
        invoker.Run();

        //команда открыть с ошибкой
        openFileCommand = new OpenCommand("");
        invoker.SetCommand(openFileCommand);
        invoker.Run();

        FileHandler fileHandler = FileHandler.GetInstance();
        Assert.AreEqual(path, fileHandler.FilePath);

    }
    [Test]
    public void ParseFromToTest()
    {
        Invoker invoker = new Invoker();
        string from = @"..\..\..\test\file4.html";
        string to = @"..\..\..\test\";

        string resaltFile = @"..\..\..\test\file4Resault.txt";
        if (File.Exists(resaltFile)) { File.Delete(resaltFile); }

        //команда открыть тестовый файл
        Command сommand = new ParseFromToCommand(from, to, "txt");
        invoker.SetCommand(сommand);
        invoker.Run();


        Assert.IsTrue(File.Exists(resaltFile));
    
    }
}

