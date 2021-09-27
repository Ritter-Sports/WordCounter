using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal interface IParser
{
    Dictionary<string,int> Pars(string path) {
        return new Dictionary<string, int> { };
    }
}


