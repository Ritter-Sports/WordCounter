﻿using System;
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
    private bool isPastAmpersand = false;

    private bool isIgnorTag = false;
    private bool isLastIgnorTag = false;
    private string tag;

    private char[] array = new char[BlockSize];

    private List<char> newWordArr = new List<char>();
    private List<char> newTagArr = new List<char>();


    /// <summary>
    /// Осуществляет парсинг HTML файла путь к которому указан в FileHandker
    /// </summary>
    public void Parse(FileHandler file)
    {
        FileInfo f = new FileInfo(file.FilePath);
        double len = f.Length;
        double acc = 0;
        Span<char> buffer;
        using (StreamReader sr = new StreamReader(file.FilePath))
        {

            buffer = new Span<char>(array);

            do
            {
                buffer.Clear();
                int length = sr.ReadBlock(buffer);
                if (length == 0)
                {
                    break;
                }

                RealParse(buffer);
                acc += length;
                Program.Print(Math.Round(acc / (len / 100), 2) + "% обработанно");

            } while (true);

            string word = new String(newWordArr.ToArray()).ToUpper();
            if (!String.IsNullOrEmpty(word))
            {
                AddSafely(word);
            }



        }

        Program.Print("Обработка завершина");
        file.Dic = dic;
        file.ParseTime = DateTime.UtcNow;
    }

    /// <summary>
    /// Выполняет парсинг отдельного блока байт
    /// </summary>
    private void RealParse(Span<char> buffer)
    {
        foreach (var c in buffer)
        {
            if (inTag)
            {
                if (isIgnorTag)
                {
                    if (c == '<')
                    {
                        isLastIgnorTag = true;
                        newTagArr.Clear();
                    }
                    else if (isLastIgnorTag)
                    {
                        newTagArr.Add(c);
                        tag =new String(newTagArr.ToArray());
                        if (Ignor.Tags.Contains(tag.Trim('/')))
                        {
                            newTagArr.Clear();
                            isIgnorTag = false;
                            isLastIgnorTag = false;
                            inTag = false;
                        }
                    }


                }
                else
                {
                    if (Char.IsLetter(c))
                    {
                        newTagArr.Add(c);
                        tag = new String(newTagArr.ToArray());
                        if (Ignor.Tags.Contains(tag))
                        {
                            isIgnorTag = true;
                            newTagArr.Clear();

                        }

                    }
                    else if (c == '>')
                    {
                        newTagArr.Clear();
                        inTag = false;
                    }
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
                            AddSafely(new String(newWordArr.ToArray()).ToUpper());
                            newWordArr.Clear();
                        }

                        newWordArr.Clear();

                        if (isPastAmpersand)
                        {
                            newWordArr.Add('&');
                            isPastAmpersand = false;
                        }
                        newWordArr.Add(c);
                        isPastLatter = true;
                    }
                }
                else
                {
                    if (c == '<')
                    {
                        newTagArr.Clear();
                        inTag = true;
                    }
                    else if (c == '&')
                    {
                        isPastAmpersand = true;
                    }
                    isPastLatter = false;

                }


            }
        }
    }
    /// <summary>
    /// Перед записью в словарь проверяет не находится ли это слово в Ignor.List
    /// </summary>
    private void AddSafely(string key)
    {
        int value = 0;
        if (dic.TryGetValue(key, out value))
        {
            dic[key] = value + 1;
        }
        else if (!Ignor.List.Contains((key + ';').ToLower()))
        {
            dic.Add(key.Trim('&', ';'), value + 1);

        }
    }
}
