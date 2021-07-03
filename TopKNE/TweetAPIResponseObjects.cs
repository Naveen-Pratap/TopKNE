using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public class Tweet
    {
        public string Id;
        public string Text;
    }
    public class User
    {
        public string Id;
        public string Name;
        public string Username;
    }
    public class TweetAPIResponseObjects
    {
        public List<Tweet> Data;
    }

    public class GetTwitterUserIdObject
    {
        public User Data;
    }
}
