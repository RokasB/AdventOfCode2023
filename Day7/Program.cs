using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day7\\input.txt";

        static List<Hand> hands = new List<Hand>();
        static void Main(string[] args)
        {
            ReadInput();
            hands.Sort(new  HandComparer());
            Console.WriteLine(GetTotalWinnings());
            Console.ReadLine();
        }

        static void ReadInput()
        {
            var lines = File.ReadLines(input);

            foreach (var line in lines)
            {
                hands.Add(new Hand(line.Split(' ')[0], int.Parse(line.Split(' ')[1])));
            }
        }

        static void PrintHands()
        {
            foreach (var hand in hands)
            {
                Console.WriteLine(hand.cards);
            }
            Console.WriteLine();
        }

        static int GetTotalWinnings()
        {
            int sum = 0;

            for(int i = 0; i < hands.Count; i++)
            {
                sum += hands[i].bid * (i + 1);
            }

            return sum;
        }
    }
}
