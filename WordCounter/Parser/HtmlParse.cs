using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal class HtmlParse : IParser
{
    Dictionary<string, int> dic = new Dictionary<string, int>();
    public Dictionary<string,int> Pars(string path)
    {
        using (StreamReader sr = new StreamReader(path))
        {
            bool inTag = false;
            bool isPastLatter = false;
            char[] array = new char[1024];
            Span<char> buffer = new Span<char>(array);
            List<char> newWordArr = new List<char>();

            
            do
            {
                int length = sr.ReadBlock(buffer);
                if (length == 0)
                {
                    break;
                }

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
                                if (newWordArr.Count != 0) {
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

            } while (true);

            return dic;



        }
    }
}
