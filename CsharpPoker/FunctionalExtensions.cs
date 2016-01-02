using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPoker
{
    public static class FunctionalExtensions
    {
        public static TResult Map<TSource, TResult>(
            this TSource @this,
            Func<TSource, TResult> fn) => fn(@this);
            
    }
}
