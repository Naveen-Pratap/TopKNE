using System;
using Xunit;
using TopKNE;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using System.Net.Http;
using Moq.Protected;
using System.Net;
using System.Threading.Tasks;
using System.Threading;

namespace TopKNETest
{
    public class TwitterServiceTest
    {
        [Fact]
        public void Test_GetTwitterDataStandardCase()
        {
            string apiResponse = "{\"data\": [{\"id\": \"1390028772842246144\", \"text\": \"Test https://t.co/7zcvuiG0a9\"}," +
                "{\"id\": \"1382435705847226369\",\"text\": \"Today https://t.co/gPL1Mecv1G\"}]}";

            List<string> expected = new List<string> {"Test https://t.co/7zcvuiG0a9", "Today https://t.co/gPL1Mecv1G"};
            string uid = "52544275";


            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(apiResponse),
               })
               .Verifiable();

            // use real http client with mocked handler here
            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://api.twitter.com/2/"),
            };

            var ts = new TwitterService(httpClient);
            List<string> res = ts.GetTweets(uid);
            expected.Should().BeEquivalentTo(res);


        }
    }
}
