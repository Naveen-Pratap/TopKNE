using System;
using Xunit;
using TopKNE;
using System.Collections.Generic;
using FluentAssertions;

namespace TopKNETest
{
    public class ConvertFormatTest
    {
        [Fact]
        public void Test_StandardCase()
        {
            List<List<string>> input = new List<List<string>>
                {
                    new List<string>{ "Hello", "my", "name", "is", "Eren" },
                    new List<string>{ "Nice", "to", "meet", "you" }
                };

            List<string> expected = new List<string> { "Hello", "my", "name", "is", "Eren", "Nice", "to", "meet", "you" };
            List<string> res = TopKAdapter.ConvertFormat(input);
            expected.Should().BeEquivalentTo(res);
        }


    }
}