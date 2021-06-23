using System;
using Xunit;
using TopKNE;
using System.Collections.Generic;
using FluentAssertions;

namespace TopKNETest
{
    public class NERCRFClassifierTest
    {
        [Fact]
        public void Test_StandardCase()
        {
            NERCRFClassifier ner = new NERCRFClassifier();
            string input = "Hello my name is Eren";

            List<string> expected = new List<string> {"Eren"};
            List<string> res = ner.DoOperation(input);
            expected.Should().BeEquivalentTo(res);
        }


    }
}
