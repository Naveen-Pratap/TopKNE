using System;
using Xunit;
using TopKNE;
using System.Collections.Generic;
using FluentAssertions;

namespace TopKNETest
{
    public class ExecuteTest
    {
        [Fact]
        public void Test_StandardCase()
        {

            List<List<string>> input = new List<List<string>>
                {
                    new List<string>{ "Hello", "my", "name", "is", "Eren" },
                    new List<string>{ "Nice", "to", "meet", "you" }
                };

            List<List<string>> expected = new List<List<string>>
                {
                    new List<string>{ "Hello", "name", "Eren" },
                    new List<string>{ "Nice", "meet" }
                };
            var res = new StopwordsFilter().Execute(input);
            expected.Should().BeEquivalentTo(res);
        }


    }
}
