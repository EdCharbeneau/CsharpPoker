using System.Collections.Generic;
using static CsharpPoker.Ranks.CommonEvals;

namespace CsharpPoker.Ranks
{
    public class FiveCardPokerRanks
    {
        public FiveCardPokerRanks()
        {
            HandRanks = new List<Rank>
            {
                new Rank("High card", (cards)=> true, 0),
                new Rank("Pair",(cards)=> HasPair(cards), 1),
                new Rank("Two pair", (cards)=> HasTwoPair(cards),2),
                new Rank("Three of a kind", (cards)=> HasThreeOfAKind(cards),3),
                new Rank("Straight", (cards)=> HasStraight(cards),4),
                new Rank("Flush", (cards)=> HasFlush(cards),5),
                new Rank("Full house", (cards)=> HasFullHouse(cards),6),
                new Rank("Four of a kind", (cards)=> HasFourOfAKind(cards),7),
                new Rank("Straight flush", (cards)=> HasStraightFlush(cards),8)
            };
        }
        public List<Rank> HandRanks { get ; private set; }
        
    }
}
