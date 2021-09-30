using NUnit.Framework;
using WordCounter;

namespace WordCounterTest;

public class Tests
{
    [Test]
    public void OpenCommandExist()//Проверка на открытие сущесвтующего файла
    {
        
        Invoker invoker = new Invoker();
        FileHandler fileHandler = FileHandler.GetInstance();
        fileHandler.SetPath("text");
        Command openFileCommand = new OpenFileCommand(fileHandler);
        invoker.SetCommand(openFileCommand);
        

        Assert.Throws<System.IO.FileNotFoundException>(()=>invoker.Run());
    }

}
