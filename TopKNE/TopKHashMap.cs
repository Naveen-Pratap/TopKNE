using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public class TopKHashMap: ITopK
    {

        public List<Token> DoOperation(List<string> input, int k)
        {
            List<Token> TopKTokens = new List<Token>();

            Dictionary<string, int> HashMap = new Dictionary<string, int>();

            // Handle edge case
            if (k <= 0)
            {
                return TopKTokens;
            }

            for (int i = 0; i < input.Count; i++)
            {
                if (HashMap.ContainsKey(input[i]) == true)
                {
                    HashMap[input[i]] = HashMap[input[i]] + 1;
                }

                else
                {
                    HashMap.Add(input[i], 1);
                }
            }

            var CountByFrequency = new List<List<string>>();
            for (int i = 0; i < input.Count; i++)
            {
                CountByFrequency.Add(new List<string>());
            }

            foreach (KeyValuePair<string, int> x in HashMap)
            {
                CountByFrequency[x.Value].Add(x.Key);                
            }

            int count = 0;
            for (int i = input.Count - 1; i >= 0; i--)
            {
                // to get the most recent value first
                CountByFrequency[i].Reverse();
                foreach (string val in CountByFrequency[i])
                {
                    TopKTokens.Add(new Token(val, i));
                    count++;
                    if (count == k)
                    {
                        return TopKTokens;
                    }
                }
            }
            return TopKTokens;


        }

    }
}
