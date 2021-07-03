using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopKNE
{
    /// <summary>
    /// A filter to be registered in the tweet processing pipeline
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFilter<T>
    {
        /// <summary>
        /// Filter implementing this method would perform processing on the input type T
        /// </summary>
        /// <param name="input">The input to be executed by the filter</param>
        /// <returns></returns>
        T Execute(T input);
    }
}
