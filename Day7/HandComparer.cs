using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class HandComparer : IComparer<Hand>
    {
        public int Compare(Hand x, Hand y)
        {
            if(!x.handType.Equals(y.handType)) return x.handType.CompareTo(y.handType);

            for(int i = 0;i < x.cards.Count(); i++)
            {
                if (!GetCardPoints(x.cards[i]).Equals(GetCardPoints(y.cards[i]))) return GetCardPoints(x.cards[i]).CompareTo(GetCardPoints(y.cards[i]));
            }
            return 0;
        }

        private int GetCardPoints(char c)
        {
            if (c == 'A') return 14;
            if (c == 'K') return 13;
            if (c == 'Q') return 12;
            if (c == 'J') return 11;
            if (c == 'T') return 10;
            return int.Parse(c.ToString());

        }
    }
}
