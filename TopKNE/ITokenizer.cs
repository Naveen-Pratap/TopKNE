using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    interface ITokenizer
    {
        List<string> DoOperation(string input);
    }
}
