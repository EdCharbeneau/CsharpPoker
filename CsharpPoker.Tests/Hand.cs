using System;
using System.Collections.Generic;

namespace CsharpPoker.Tests
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public List<Card> Cards { get; set; }

        public void Draw(Card card)
        {
            Cards.Add(card);
        }
    }
}