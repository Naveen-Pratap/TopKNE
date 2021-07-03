using System;
using Xunit;
using TopKNE;
using System.Collections.Generic;
using FluentAssertions;

namespace TopKNETest
{
    public class TweetTokenizerTest
    {
        [Fact]
        public void Test_StandardCase()
        {
            TweetTokenizer tt = new TweetTokenizer();
            var tweets = new List<string> {"Hello my name is Eren", "Nice to meet you"};
            var tok = new SimpleTokenizer();

            List<List<string>> expected = new List<List<string>>
                {
                    new List<string>{ "hello", "my", "name", "is", "eren" },
                    new List<string>{ "nice", "to", "meet", "you" }
                };
            List<List<string>> res = tt.TokenizeMany(tweets, tok);
            expected.Should().BeEquivalentTo(res);
        }


    }
}