using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;
using FluentAssertions;

namespace CsharpPoker.Tests
{
    public partial class CardTests
    {
        public class ScorerTests
        {
            [Fact]
            public void CanScoreHighCard()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Ace, CardSuit.Diamonds),
                    new Card(CardValue.Eight, CardSuit.Spades),
                    new Card(CardValue.Jack, CardSuit.Spades),
                    new Card(CardValue.Queen, CardSuit.Spades),
                    new Card(CardValue.Six, CardSuit.Clubs)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.HighCardValue.Should().Be(CardValue.Ace);
                scorer.Score.Name.Should().Be("High card");
            }

            [Fact]
            public void CanScorePair()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Ace, CardSuit.Diamonds),
                    new Card(CardValue.Eight, CardSuit.Spades),
                    new Card(CardValue.Queen, CardSuit.Spades),
                    new Card(CardValue.Six, CardSuit.Spades),
                    new Card(CardValue.Queen, CardSuit.Clubs)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Pair");
            }

            [Fact]
            public void CanScoreTwoPair()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Eight, CardSuit.Diamonds),
                    new Card(CardValue.Queen, CardSuit.Spades),
                    new Card(CardValue.Six, CardSuit.Spades),
                    new Card(CardValue.Eight, CardSuit.Clubs),
                    new Card(CardValue.Queen, CardSuit.Clubs)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Two pair");
            }

            [Fact]
            public void CanScoreThreeOfAKind()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Eight, CardSuit.Clubs),
                    new Card(CardValue.Six, CardSuit.Spades),
                    new Card(CardValue.Eight, CardSuit.Diamonds),
                    new Card(CardValue.Queen, CardSuit.Spades),
                    new Card(CardValue.Eight, CardSuit.Spades)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Three of a kind");
            }

            [Fact]
            public void CanScoreStraight()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Six, CardSuit.Hearts),
                    new Card(CardValue.Four, CardSuit.Spades),
                    new Card(CardValue.Three, CardSuit.Clubs),
                    new Card(CardValue.Five, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Diamonds)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Straight");
            }

            [Fact]
            public void CanScoreFourOfAKind()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Two, CardSuit.Clubs),
                    new Card(CardValue.Six, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Hearts),
                    new Card(CardValue.Two, CardSuit.Diamonds),
                    new Card(CardValue.Two, CardSuit.Spades)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Four of a kind");
            }

            [Fact]
            public void CanScoreFlush()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Ace, CardSuit.Spades),
                    new Card(CardValue.Six, CardSuit.Spades),
                    new Card(CardValue.Ten, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Spades)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Flush");
            }

            [Fact]
            public void CanScoreFullHouse()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Ace, CardSuit.Diamonds),
                    new Card(CardValue.Ace, CardSuit.Clubs),
                    new Card(CardValue.Ace, CardSuit.Spades),
                    new Card(CardValue.Two, CardSuit.Hearts),
                    new Card(CardValue.Two, CardSuit.Spades)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Full house");
            }

            [Fact]
            public void CanScoreStraightFlush()
            {
                var hand = new Hand();

                new List<Card>
                {
                    new Card(CardValue.Two, CardSuit.Diamonds),
                    new Card(CardValue.Four, CardSuit.Diamonds),
                    new Card(CardValue.Three, CardSuit.Diamonds),
                    new Card(CardValue.Five, CardSuit.Diamonds),
                    new Card(CardValue.Six, CardSuit.Diamonds)
                }
                .ForEach(card => hand.Draw(card));

                var scorer = new HandScorer(hand);

                scorer.Score.Name.Should().Be("Straight flush");
            }
        }
    }
    
}