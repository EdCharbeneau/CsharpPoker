using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CsharpPoker
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

        private readonly ConcurrentDictionary<CardValue, int> pairs;

        public HandScorer(Hand hand)
        {
            this.hand = hand;
            this.pairs = hand.Cards.Map(cards => CreatePairs(cards));
            HighCardValue = GetHighCard();
            Score = GetHandScore();
        }

        public CardValue HighCardValue { get; private set; }
        public HandScore Score { get; private set; }

        private HandScore GetHandScore()
        {
            return HasFourOfAKind() ? HandScore.FourOfAKind : 
                   HasStraight() ? HandScore.Straight :
                   HasThreeOfAKind() ? HandScore.ThreeOfAKind :
                   HasTwoPair() ? HandScore.TwoPair :
                   HasPair() ? HandScore.Pair :
                   HandScore.HighCard;
        }

        private bool HasOfAKind(int numberOfAKind) => 
                this.pairs
                .Count(item => item.Value == numberOfAKind) == 1;

        private bool HasPair() => HasOfAKind(2);

        private bool HasTwoPair() => pairs.Count(item => item.Value == 2) == 2;
        
        private bool HasThreeOfAKind() => HasOfAKind(3);

        private bool HasFourOfAKind() => HasOfAKind(4);

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


        private ConcurrentDictionary<CardValue, int> CreatePairs(List<Card> cards)
        {
            var dict = new ConcurrentDictionary<CardValue, int>();
            cards.ForEach(
                card => dict.AddOrUpdate(card.Value, 1,
                    (k, v) => v + 1
                ));
            return dict;
        }
    }
}