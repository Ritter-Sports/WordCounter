using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

internal interface ISave
{
    void Save() { }
    void Save(string path) { }

}

