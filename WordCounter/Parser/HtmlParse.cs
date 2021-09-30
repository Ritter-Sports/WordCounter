using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class HtmlParse : IParser
{
    private Dictionary<string, int> dic = new Dictionary<string, int>();

    private static int BlockSize = 24;//Количество байт считываемое за раз

    private bool inTag = false;
    private bool isPastLatter = false;
    private char[] array = new char[BlockSize];

    private List<char> newWordArr = new List<char>();

    public void Parse(FileHandler file)
    {
        FileInfo f = new FileInfo(file.FilePath);
        double len = f.Length;
        double acc = 0;
        using (StreamReader sr = new StreamReader(file.FilePath))
        {

            Span<char> buffer = new Span<char>(array);
            do
            {
                int length = sr.ReadBlock(buffer);
                if (length == 0)
                {
                    break;
                }
                
                RealParse(buffer);
                acc += length;
                                Program.Print(Math.Round(acc/(len/100),2)+"% обработанно");

            } while (true);

        }
        Program.Print("Обработка завершина");
        file.Dic = dic;
    }

    private void RealParse(Span<char> buffer)
    {
        foreach (var c in buffer)
        {
            if (inTag)
            {
                if (Char.IsLetter(c))
                {
                    continue;
                }
                else if (c == '>')
                {
                    inTag = false;
                }
            }
            else
            {
                if (Char.IsLetter(c))
                {
                    if (isPastLatter)
                    {
                        newWordArr.Add(c);
                    }
                    else
                    {
                        if (newWordArr.Count != 0)
                        {
                            string word = new String(newWordArr.ToArray()).ToUpper();
                            int count = 0;
                            if (dic.TryGetValue(word, out count))
                            {
                                dic[word] = count + 1;
                            }
                            else
                            {
                                dic.Add(word, count + 1);
                            }
                            newWordArr.Clear();
                        }

                        newWordArr.Clear();
                        newWordArr.Add(c);
                        isPastLatter = true;
                    }
                }
                else
                {
                    if (c == '<')
                    {
                        inTag = true;
                    }
                    isPastLatter = false;

                }


            }
        }
    }
}
