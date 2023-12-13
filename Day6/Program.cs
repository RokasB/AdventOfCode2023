using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day6\\input.txt";

        static List<Race> races = new List<Race>();
        static void Main(string[] args)
        {
            ReadInput2();
            Console.WriteLine(GetNumberOfWays());
            Console.ReadLine();
        }
        static void ReadInput()
        {
            var lines = File.ReadLines(input);
            var times = lines.First().Split(':')[1].Split(' ').Where(x => x != "").ToList();
            var distances = lines.Last().Split(':')[1].Split(' ').Where(x => x != "").ToList();

            for(int i = 0; i< times.Count; i++)
            {
                races.Add(new Race(int.Parse(times[i]), int.Parse(distances[i])));
            }
        }

        static void ReadInput2()
        {
            var lines = File.ReadLines(input);
            var times = lines.First().Split(':')[1].Split(' ').Where(x => x != "").ToList();
            var distances = lines.Last().Split(':')[1].Split(' ').Where(x => x != "").ToList();

            string distance = "", time = "";

            for (int i = 0; i < times.Count; i++)
            {
                distance += distances[i];
                time += times[i];
            }

            races.Add(new Race(long.Parse(time), long.Parse(distance)));
        }

        public static long GetNumberOfWays()
        {
            long sum = 1;

            foreach(var race in races)
            {
                sum *= GetNumberOfWaysForRace(race);
                //Console.WriteLine(GetNumberOfWaysForRace(race));
            }

            return sum;
        }

        public static long GetNumberOfWaysForRace(Race race)
        {
            long count = 0;

            for(long i = 1;  i < race.Time; i++)
            {
                long distance = (race.Time - i) * i;

                if(distance > race.Distance)
                    count++;
            }

            return count;
        }
    }
}
