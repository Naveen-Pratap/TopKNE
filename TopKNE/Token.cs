using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public class Token
    {
        public string value;
        public int count;

        public Token(string value, int count)
        {
            this.count = count;
            this.value = value;
        }
    }
}
