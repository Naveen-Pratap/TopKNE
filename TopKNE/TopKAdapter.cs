using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    public class TopKAdapter: ITopKAdapter
    {
        private readonly ITopK topK;

        public TopKAdapter(ITopK topK)
        {
            this.topK = topK;
        }
        /// <summary>
        /// Flattens List of Lists to a List. 
        /// </summary>
        /// <param inputs="List of List of strings."></param>
        /// <returns>
        /// Flat list of strings.
        /// </returns>
        public static List<string> ConvertFormat(List<List<string>> input)
        {
            var resp = input.SelectMany(x => x).ToList();
            return resp;
        }

        public List<Token> DoOperation(List<List<string>> input, int k)
        {
            return this.topK.DoOperation(ConvertFormat(input), k);
        }
    }
}
