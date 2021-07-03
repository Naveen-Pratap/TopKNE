using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TopKNE
{
    [Serializable]
    class TwitterAPINotOkException : Exception
    {
        public TwitterAPINotOkException() { }

        public TwitterAPINotOkException(int statusCode)
            : base(String.Format($"Twitter API returned non 200 response code : {statusCode}"))
        {

        }
    }
    public class TwitterService: ITwitterService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl = "https://api.twitter.com/2";
        private readonly string _bearerToken = "AAAAAAAAAAAAAAAAAAAAAA8cQwEAAAAAV6Orzry3wRsb5IT6Vo6IEtDtMwQ%3D5B3jsYr2gDP8etgqzhmIfFEjeK10LegODqOFe4e2rAdeGN1PQu";

     

        public TwitterService(HttpClient httpClient)
            {
                _httpClient = httpClient;
                _httpClient.BaseAddress = new Uri(_remoteServiceBaseUrl);
        }

        public List<string> GetTweets(string uid)
        {
            //_httpClient.BaseAddress = new Uri(_remoteServiceBaseUrl);
            List<string> tweets = new List<string>();

            _httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", _bearerToken);

            var response = _httpClient.GetAsync(String.Format($"/2/users/{uid}/tweets")).Result;
            if (response.IsSuccessStatusCode)
            {
                string temp = response.Content.ReadAsStringAsync().Result;
                Console.Write(temp);
                var getTweetRsponseObject = JsonConvert.DeserializeObject<TweetAPIResponseObjects>(temp);
                foreach(var t in getTweetRsponseObject.Data.Select(s => s.Text))
                {
                    tweets.Add(t);
                }
            }
            else
            {
                throw new TwitterAPINotOkException((int)response.StatusCode);
            }

            return tweets;
            
        }

        public string GetUserId(string username)
        {
            //_httpClient.BaseAddress = new Uri(_remoteServiceBaseUrl);
          

            _httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", _bearerToken);

            var response = _httpClient.GetAsync(String.Format($"/2/users/by/username/{username}")).Result;
            if (response.IsSuccessStatusCode)
            {
                string temp = response.Content.ReadAsStringAsync().Result;
                Console.Write(temp);
                var twitterUserIdObject = JsonConvert.DeserializeObject<GetTwitterUserIdObject>(temp);
                return twitterUserIdObject.Data.Id;
            }
            else
            {
                throw new TwitterAPINotOkException((int)response.StatusCode);
            }


        }

        public List<Token> GetTopK(string username, int k)
        {
            string uid = this.GetUserId(username);
            var tweets = this.GetTweets(uid);
            var tokenizer = new SimpleTokenizer();
            var topKAdapter = new TopKAdapter(new TopKHashMap());
            var tokenizedTweets = new TweetTokenizer().TokenizeMany(tweets, tokenizer);
            
            var tweetFilterPipeline = new TweetFilterPipeline();
            //Register the filters to be executed
            tweetFilterPipeline.Register(new StopwordsFilter());
            var filteredTokenizedTweets = tweetFilterPipeline.Process(tokenizedTweets);

            var topKTokens = topKAdapter.DoOperation(filteredTokenizedTweets, k);
            return topKTokens;
        }
    }
}
