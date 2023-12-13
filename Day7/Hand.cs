using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Hand
    {
        public string cards;

        public int bid;

        public HandType handType;

        public Hand(string cards, int bid)
        {
            this.cards = cards;
            this.bid = bid;
            this.handType = getHandType(cards);
        }

        public HandType getHandType(string cards)
        {
            var characterCounts = cards
                .GroupBy(c => c)
                .Select(group => new { c = group.Key, count = group.Count() });

            if (characterCounts.Count() == 1) return HandType.FiveOfAKind;

            if (characterCounts.Count() == 2)
            {
                if (characterCounts.Any(group => group.count == 4))  return HandType.FourOfAKind;
                else return HandType.FullHouse;
            }

            if(characterCounts.Count() == 3)
            {
                if (characterCounts.Any(group => group.count == 3)) return HandType.ThreeOfAKind;
                else return HandType.TwoPair;
            }

            if (characterCounts.Count() == 4) return HandType.OnePair;

            return HandType.HighCard;
        }
    }

    public enum HandType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }


}
