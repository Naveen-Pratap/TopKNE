using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TopKNE
{
    public class TwitterService: ITwitterService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl = "https://api.twitter.com/2/";
        private readonly string _bearerToken = "";

     

        public TwitterService(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

        public List<string> GetTweets(string uid)
        {
            _httpClient.BaseAddress = new Uri(_remoteServiceBaseUrl);
            List<string> tweets = new List<string>();

            _httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", _bearerToken);

            var response = _httpClient.GetAsync(String.Format("/users/{0}/tweets", uid)).Result;
            if (response.IsSuccessStatusCode)
            {
                string temp = response.Content.ReadAsStringAsync().Result;
                Console.Write(temp);
                var getTweetRsponseObject = JsonConvert.DeserializeObject<GetTweetResponseObject>(temp);
                foreach(var t in getTweetRsponseObject.Data.Select(s => s.Text))
                {
                    tweets.Add(t);
                }
            }

            return tweets;
            
        }
    }
}
