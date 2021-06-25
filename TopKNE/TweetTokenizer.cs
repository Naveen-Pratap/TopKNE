using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    /// <summary>
    /// Tokenizes each item of a list and returns a list of token lists. 
    /// </summary>
    /// <param inputs="List of strings to be tokenized."></param>
    /// <param name="Tokenizer to be used."></param>
    /// <returns>
    /// List of List of tokens.
    /// </returns>
    public class TweetTokenizer: ITokenizeMany
    {
        public List<List<string>> TokenizeMany(List<string> inputs, ITokenizer tok)
        {
            List<List<string>> output = new List<List<string>>();
            foreach (var t in inputs)
            {
                output.Add(tok.DoOperation(t));
            }

            return output;
        }
    }
}
