﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public interface ITopK
    {
        List<Token> DoOperation(List<string> input, int k);
    }
}
