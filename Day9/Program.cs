using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day9
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day9\\input.txt";

        public static List<List<int>> oasisReport = new List<List<int>>();
        static void Main(string[] args)
        {
            ReadInput();
            Console.WriteLine(GetSumOfExtrapolatedValues());
            Console.ReadLine();
        }

        public static void ReadInput()
        {
            var lines = File.ReadLines(input);

            foreach (var line in lines)
            {
                oasisReport.Add(line.Split(' ').Select(x => int.Parse(x.Trim())).ToList());
            }
        }

        public static int GetSumOfExtrapolatedValues()
        {
            var sum = 0;
            foreach(var history in oasisReport)
            {
                sum += GetExtrapolatedValue(history);
            }
            return sum;
        }

        public static int GetExtrapolatedValue(List<int> history)
        {
            List<List<int>> sequences = new List<List<int>>();
            sequences.Add(history);

            while (sequences.Last().Count(x => x == 0) != sequences.Last().Count) //while not all zeroes
            {
                List<int> nextSequence = new List<int>();
                for (int i = 0; i < sequences.Last().Count -1; i++)
                {
                    nextSequence.Add(sequences.Last()[i+1] - sequences.Last()[i]);
                }
                sequences.Add(nextSequence);
            }

            List<int> extrapolations = new List<int>();
            extrapolations.Add(0);
            for(int i = sequences.Count - 2; i >=0 ;i--)
            {
                extrapolations.Add(extrapolations.Last() + sequences[i].Last());
            }
            return extrapolations.Last();

        }
    }
}
