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
            Console.WriteLine(GetPoints());
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
