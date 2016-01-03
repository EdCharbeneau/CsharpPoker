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
            this.pairs = hand.Cards.OrderedByValue().Map(cards => CreatePairs(cards));
            HighCardValue = GetHighCard();
            Score = GetHandScore();
        }

        public CardValue HighCardValue { get; private set; }
        public HandScore Score { get; private set; }

        private HandScore GetHandScore() =>
                   HasStraightFlush() ? HandScore.StraightFlush :
                   HasFourOfAKind() ? HandScore.FourOfAKind :
                   HasFullHouse() ? HandScore.FullHouse :
                   HasFlush() ? HandScore.Flush : 
                   HasStraight() ? HandScore.Straight :
                   HasThreeOfAKind() ? HandScore.ThreeOfAKind :
                   HasTwoPair() ? HandScore.TwoPair :
                   HasPair() ? HandScore.Pair :
                   HandScore.HighCard;

        private bool HasOfAKind(int numberOfAKind) => 
                this.pairs
                .Count(item => item.Value == numberOfAKind) == 1;

        private bool HasPair() => HasOfAKind(2);

        private bool HasTwoPair() => pairs.Count(item => item.Value == 2) == 2;
        
        private bool HasThreeOfAKind() => HasOfAKind(3);
        
        private bool HasFourOfAKind() => HasOfAKind(4);

        private bool HasStraight() => hand.Cards.OrderedByValue().AreAllSequential();

        private bool HasFlush() => hand.Cards.Select(card => card.Suit).Distinct().Count() == 1;

        private bool HasFullHouse() => HasPair() && HasThreeOfAKind();

        private bool HasStraightFlush() => HasStraight() && HasFlush();
        
        private CardValue GetHighCard() => hand.Cards.Max(card => card.Value);
    
        private ConcurrentDictionary<CardValue, int> CreatePairs(IEnumerable<Card> cards)
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