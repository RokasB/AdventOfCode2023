using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    //53885 not good
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day1\\input.txt";

        static Dictionary<string, string> numberWords = new Dictionary<string, string>
        {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"}
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
            string transcribedString = input;
            while(GetFirstOccurenceAndReplace(transcribedString, out transcribedString))
            {

            }


            Console.WriteLine(transcribedString);
            return transcribedString;
        }

        private static bool GetFirstOccurenceAndReplace(in string input, out string output)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                foreach(var pair in numberWords)
                {
                    if (i + pair.Key.Length <= input.Length && input.Substring(i, pair.Key.Length) == pair.Key)
                    {
                        string substring1 = input.Substring(0, i);
                        string substring2 = input.Substring(i + pair.Key.Length);

                        output = substring1 + pair.Value + substring2;
                        return true;
                    }
                }
            }

            output = input;
            return false;
        }

        private static int GetCalibratedResult(string input)
        {
            int firstNumber, lastNumber;
            var numbers = input.Where(Char.IsDigit).ToList();

            int.TryParse(numbers.First().ToString(), out firstNumber);
            int.TryParse(numbers.Last().ToString(), out lastNumber);

            Console.WriteLine($"{firstNumber}{lastNumber}");
            return firstNumber * 10 + lastNumber;
        }
    }
}
