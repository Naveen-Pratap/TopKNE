using System;
using Xunit;
using TopKNE;
using System.Collections.Generic;
using FluentAssertions;

namespace TopKNETest
{
    public class SimpleTokenizerTest
    {
        [Fact]
        public void Test_StandardCase()
        {
            SimpleTokenizer tok = new SimpleTokenizer();
            string input = "Hello my name is Eren";

            List<string> expected = new List<string> {"Hello", "my", "name", "is", "Eren" };
            List<string> res = tok.DoOperation(input);
            expected.Should().BeEquivalentTo(res);
        }

        [Fact]
        public void Test_TrailingSpaces()
        {
            SimpleTokenizer tok = new SimpleTokenizer();
            string input = "Hello my name is Eren ";

            List<string> expected = new List<string> { "Hello", "my", "name", "is", "Eren" };
            List<string> res = tok.DoOperation(input);
            expected.Should().BeEquivalentTo(res);
        }

    }
}