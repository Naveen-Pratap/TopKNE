using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    interface ITwitterService
    {
        List<string> GetTweets(string uid);
        //string getUIDOfUser(string username);

        //List<Token> getTopK(string username, int k);
    }
}
