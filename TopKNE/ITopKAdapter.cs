using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    interface ITopKAdapter
    {
        List<Token> DoOperation(List<List<string>> input, int k);
    }
}
