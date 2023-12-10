using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day1\\Input.txt";

        static Dictionary<string, string> numberWords = new Dictionary<string, string>
        {
            {"one", "o1e"},
            {"two", "t2o"},
            {"three", "t3e"},
            {"four", "f4r"},
            {"five", "f5e"},
            {"six", "s6x"},
            {"seven", "s7n"},
            {"eight", "e8t"},
            {"nine", "n9e"}
        };

    public static void Main()
        {
            try
            {
                Console.WriteLine(GetSumOfCalibratedResults());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();

        }

        private static int GetSumOfCalibratedResults()
        {
            int sum = 0;
            var lines = File.ReadLines(input);

            foreach (var line in lines)
            {
                sum += GetCalibratedResult(TranscribeWordsToNumbers(line));
            }

            return sum;
        }

        private static string TranscribeWordsToNumbers(string input)
        {
            string transcribedString =  numberWords.Aggregate(input, (current, kv) => current.Replace(kv.Key, kv.Value));
            Console.WriteLine(transcribedString);
            return transcribedString;
        }

        private static int GetCalibratedResult(string input)
        {
            int firstNumber, lastNumber;
            var numbers = input.Where(Char.IsDigit).ToList();

            int.TryParse(numbers.First().ToString(), out firstNumber);
            int.TryParse(numbers.Last().ToString(), out lastNumber);

            return firstNumber * 10 + lastNumber;
        }
    }
}
