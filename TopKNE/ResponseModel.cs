using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TopKNE
{
    public class ResponseModel
    {
        public string Message { set; get; }
        public bool Status { set; get; }
        public List<Token> Data { set; get; }
    }
}
