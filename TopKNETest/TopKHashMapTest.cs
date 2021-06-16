using System;
using Xunit;
using TopKNE;
using System.Collections.Generic;
using FluentAssertions;

namespace TopKNETest
{
    public class TopKHashMapTest
    {
        [Fact]
        public void Test_StandardCase()
        {
            TopKHashMap hm = new TopKHashMap();
            int k = 3;
            List<string> neTokens = new List<string> { "Token1", "Token1", "Token2", "Token1", "Token3", "Token3", "Token3", "Token4", "Token4" };
            Token token1 = new Token("Token1", 3);
            Token token3 = new Token("Token3", 3);
            Token token4 = new Token("Token4", 2);

            List<Token> expected = new List<Token> { token3, token1, token4 };
            List<Token> res = hm.DoOperation(neTokens, k);
            expected.Should().BeEquivalentTo(res);
        }

        [Fact]
        public void Test_DistinctItemsLessThanK()
        {
            TopKHashMap hm = new TopKHashMap();
            int k = 3;
            List<string> neTokens = new List<string> { "Token1", "Token1", "Token2", "Token1" };
            Token token1 = new Token("Token1", 3);
            Token token2 = new Token("Token2", 1);

            List<Token> expected = new List<Token> { token1, token2};
            List<Token> res = hm.DoOperation(neTokens, k);
            expected.Should().BeEquivalentTo(res);
        }

        [Fact]
        public void Test_ZeroItems()
        {
            TopKHashMap hm = new TopKHashMap();
            int k = 3;
            List<string> neTokens = new List<string> {};

            List<Token> expected = new List<Token> {};
            List<Token> res = hm.DoOperation(neTokens, k);
            expected.Should().BeEquivalentTo(res);
        }

        [Fact]
        public void Test_ZeroKValue()
        {
            TopKHashMap hm = new TopKHashMap();
            int k = 0;
            List<string> neTokens = new List<string> { "Token1", "Token1", "Token2", "Token1" };

            List<Token> expected = new List<Token> {};
            List<Token> res = hm.DoOperation(neTokens, k);
            expected.Should().BeEquivalentTo(res);
        }

    }
}
