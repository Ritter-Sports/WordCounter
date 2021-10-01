﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal static class Ignor
{

    private static List<string> list = new List<string>() { "&lt;", "&gt;", "&amp;", "&nbsp;", "&copy;", "&mdash;", "&laquo;", "&raquo;", 
                                                        "&hellip;", "&sect;", "&cent;", "&pound;", "&reg;", "&deg;", "&plusmn;", "&para;",
                                                        "&middot;", "&frac12;", "&ndash;", "&mdash;", "&rsquo;", "&lsquo;", "&sbquo;", "&ldquo;",
                                                        "&rdquo;", "&bdquo;", "&dagger;", "&Dagger;", "&bull;", "&hellip;", "&Prime;", "&prime;",
                                                        "&euro;", "&trade;", "&asymp;", "&ne;", "&le;", "&ge;", "&lt;", "&gt;" };
    /// <summary>
    /// Возвращает список html маркеров
    /// </summary>
    public static List<string> List { get { return list; } }
}

