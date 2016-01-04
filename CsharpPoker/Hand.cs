using System;
using System.Collections.Generic;

namespace CsharpPoker
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public List<Card> Cards { get; private set; }

        public void Draw(Card card)
        {
            Cards.Add(card);
        }
    }
}