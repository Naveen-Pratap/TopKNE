using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    interface IPipelineObjectTopK
    {
        List<Token> Execute(List<string> input, ITopK algo);
    }
}
