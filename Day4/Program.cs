using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day4\\input.txt";

        static List<Card> cards = new List<Card>();
        static void Main(string[] args)
        {
            ReadInput();
            //Console.WriteLine(GetPoints());
            Console.WriteLine(GetTotalCardCount());
            Console.ReadLine();
        }

        static void ReadInput()
        {
            var lines = File.ReadLines(input);

            foreach (var line in lines)
            {
                Card game = new Card(line.Trim());
                cards.Add(game);
            }
        }

        static int GetTotalCardCount()
        {
            for (int i = 0; i< cards.Count; i++)
            {
                //For each instance of card do lottery
                for(int j = 1; j<= cards[i].Count; j++)
                {
                    //Get count
                    int points = 0;
                    foreach (int myNumber in cards[i].MyNumbers)
                    {
                        if (cards[i].WinningNumbers.Contains(myNumber))
                        {
                            points++;
                        }
                    }

                    //Add winned cards
                    if (points > cards.Count - i + 1)
                        points = cards.Count - i + 1;

                    for (int k = 1; k <= points; k++)
                    {
                        cards[i + k].Count++;
                    }
                }
            }

            int sum = 0;
            foreach(var card in cards)
            {
                sum += card.Count;
            }
            return sum;
        }

        static int GetPoints()
        {
            int sum = 0;

            foreach (var card in cards)
            {
                int points = 0;
                foreach(int myNumber in card.MyNumbers)
                {
                    if(card.WinningNumbers.Contains(myNumber))
                    {
                        points++;
                    }
                }
                if(points > 0)
                    sum += IntPow(2, points - 1);
            }

            return sum;
        }

        static int IntPow(int x, int pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
    }
}
