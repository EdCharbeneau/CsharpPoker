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
    public class CardTests
    {

        [Fact]
        public void CanCreateCardWithSuitAndValue()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);

            card.Value.Should().Be(CardValue.Ace);
            card.Suit.Should().Be(CardSuit.Spades);
        }

        [Fact]
        public void CanWriteCardSuitAndValue()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);

            card.ToString().Should().Be("Ace of Spades");
        }

        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand();
            hand.Cards.Any().Should().Be(false);
        }

        [Fact]
        public void CanHandDrawCard()
        {
            var card = new Card(CardValue.Ace, CardSuit.Spades);
            var hand = new Hand();

            hand.Draw(card);

            hand.Cards.First().Should().Be(card);
        }
    }
}
