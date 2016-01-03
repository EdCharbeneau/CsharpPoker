using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPoker
{
   public static class CardHelperExtensions
    {
        public static IEnumerable<Card> OrderedByValue(this IEnumerable<Card> cards) => cards.OrderBy(card => card.Value);

        public static bool AreAllSequential(this IEnumerable<Card> cards) =>
            cards.SelectConsecutive((n, next) => areSequential(n.Value, next.Value)).All(result => result);

        private static readonly Func<CardValue, CardValue, bool> areSequential = (n, next) => n + 1 == next;

    }
}
