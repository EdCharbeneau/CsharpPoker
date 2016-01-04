using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
namespace CsharpPoker
{
    public class HandScorer
    {
        private readonly List<Rank> rules;
        private readonly Hand hand;
        public HandScorer(Hand hand, List<Rank> rules)
        {
            this.hand = hand;
            this.rules = rules;
        }

        public Rank GetScore() =>
            rules.OrderByDescending(rule => rule.Strength)
            .First(rule => rule.Eval(hand.Cards));

    }
}