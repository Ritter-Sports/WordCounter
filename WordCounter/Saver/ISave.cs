using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

public interface ISave
{
    
    void Save(FileHandler file, string p) { }

}

