using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker.Tests
{
    public class HandScorer
    {
        public enum HandScore
        {
            HighCard,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
        }

        private readonly Hand hand;

        public HandScorer(Hand hand)
        {
            this.hand = hand;
            HighCardValue = GetHighCard();
            Score = GetHandScore();
        }

        private HandScore GetHandScore()
        {
            return HasFourOfAKind() ? HandScore.FourOfAKind : 
                   HasStraight() ? HandScore.Straight :
                   HasThreeOfAKind() ? HandScore.ThreeOfAKind :
                   HasTwoPair() ? HandScore.TwoPair :
                   HasPair() ? HandScore.Pair :
                   HandScore.HighCard;
        }

        private bool HasPair()
        {
            var dict = new ConcurrentDictionary<CardValue, int>();
            hand.Cards.ForEach(
                card => dict.AddOrUpdate(card.Value, 1,
                    (k, v) => v + 1
                ));
            return dict.Count(item => item.Value == 2) == 1;
        }
        private bool HasTwoPair()
        {
            var dict = new ConcurrentDictionary<CardValue, int>();
            hand.Cards.ForEach(
                card => dict.AddOrUpdate(card.Value, 1,
                    (k, v) => v + 1
                ));
            return dict.Count(item => item.Value == 2) == 2;
        }
        private bool HasThreeOfAKind()
        {
            var dict = new ConcurrentDictionary<CardValue, int>();
            hand.Cards.ForEach(
                card => dict.AddOrUpdate(card.Value, 1,
                    (k, v) => v + 1
                ));
            return dict.Count(item => item.Value == 3) == 1;
        }

        private bool HasFourOfAKind()
        {
            var dict = new ConcurrentDictionary<CardValue, int>();
            hand.Cards.ForEach(
                card => dict.AddOrUpdate(card.Value, 1,
                    (k, v) => v + 1
                ));
            return dict.Count(item => item.Value == 4) == 1;
        }

        private bool HasStraight() {

            return hand.Cards.Take(hand.Cards.Count() -1)
                .Select(
                        (item, index) => item.Value + 1 == hand.Cards.ElementAt(index +1).Value
                       )
                    .All(result => result);
        }

        private CardValue GetHighCard()
        {
            return hand.Cards
                .OrderBy(card => card.Value)
                .Last()
                .Value;
        }

        public CardValue HighCardValue { get; private set; }
        public HandScore Score { get; private set; }
    }
}