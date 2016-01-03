using System;
using System.Diagnostics;
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

        public static List<T> Shuffle<T>(this List<T> list, Random rnd)
        {
            for (var i = 0; i < list.Count; i++)
                list.Swap(i, rnd.Next(i, list.Count));
            return list.ToList();
        }

        public static void Swap<T>(this IList<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> items) => items.Take(items.Count() - 1);

        public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
        {
            int index = -1;
            foreach (TSource element in source.SkipLast())
            {
                checked { index++; }
                yield return selector(element, source.ElementAt(index + 1));
            }
        }

    }
}
