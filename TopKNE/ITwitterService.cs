using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public interface ITwitterService
    {
        List<string> GetTweets(string uid);

        List<Token> GetTopK(string username, int k);
    }
}
