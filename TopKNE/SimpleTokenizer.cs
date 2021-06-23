using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public class SimpleTokenizer: ITokenizer
    {
        public List<string> DoOperation(string input)
        {
            List<string> tokens = input.Trim().Split(' ').ToList();
            return tokens;
        }
    }
}
