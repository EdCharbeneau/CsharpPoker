using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpPoker.Ranks
{
    public static class EvalExtensions
    {
        public static IEnumerable<Card> OrderedByValue(this IEnumerable<Card> cards) => cards.OrderBy(card => card.Value);

        public static bool AreAllSequential(this IEnumerable<Card> cards) =>
            cards.SelectConsecutive((n, next) => areSequential(n.Value, next.Value)).All(result => result);

        private static readonly Func<CardValue, CardValue, bool> areSequential = (n, next) => n + 1 == next;

        public static bool HasOfAKind(this IEnumerable<Card> cards, int numberOfAKind) =>
            cards.ToPairs().Count(item => item.Value == numberOfAKind) == 1;

        public static ConcurrentDictionary<CardValue, int> ToPairs(this IEnumerable<Card> cards) =>
            cards.OrderedByValue().Map(c => CreatePairs(c));

        private static ConcurrentDictionary<CardValue, int> CreatePairs(IEnumerable<Card> cards)
        {
            var pairs = new ConcurrentDictionary<CardValue, int>();
            foreach (var card in cards)
            {
                pairs.AddOrUpdate(card.Value, 1,
                    (cardValue, quantity) => quantity + 1
                );
            }
            return pairs;
        }
    }
}