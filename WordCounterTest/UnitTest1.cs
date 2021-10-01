using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Serilog;
using System.Collections.Generic;
using WordCounter;

namespace WordCounterTest;

public class TestsSets
{

    [Test]
    public void TestSet1()//Простая выборка с тегами и маркерами
    {
        Invoker invoker = new Invoker();
        string path = @"test\file1.html";
 
        Command command = new OpenCommand(path);
        invoker.SetCommand(command);
        invoker.Run();
       
        command = new ParseCommand();
        invoker.SetCommand(command);
        invoker.Run();

        Assert.That(FileHandler.GetInstance().Dic, Does.ContainKey("НЕДОСТАТКИ").WithValue(1));
    }
    [Test]
    public void TestSet2()//Список игнорируемых слов
    {
        Invoker invoker = new Invoker();
        string path = @"test\file2.html";

        Command command = new OpenCommand(path);
        invoker.SetCommand(command);
        invoker.Run();

        command = new ParseCommand();
        invoker.SetCommand(command);
        invoker.Run();

        Assert.IsEmpty(FileHandler.GetInstance().Dic);
    }
    [Test]
    public void TestSet3()//Простой файл с английскими словами
    {
        Invoker invoker = new Invoker();
        string path = @"test\file3.html";

        Command command = new OpenCommand(path);
        invoker.SetCommand(command);
        invoker.Run();

        command = new ParseCommand();
        invoker.SetCommand(command);
        invoker.Run();

        Assert.That(FileHandler.GetInstance().Dic, Does.ContainKey("HTML").WithValue(2));
        Assert.That(FileHandler.GetInstance().Dic, Does.ContainKey("REST").WithValue(1));
    }
}
