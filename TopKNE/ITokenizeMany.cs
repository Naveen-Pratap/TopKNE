using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    interface ITokenizeMany
    {
        List<List<string>> TokenizeMany(List<string> inputs, ITokenizer tok);
    }
}
