using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TopKNE
{
    public class Token
    {
        public string Value { get; set; }
        public int Count { get; set; }

        public Token(string value, int count)
        {
            Count = count;
            Value = value;
        }
    }
}
