using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day2\\input.txt";

        static List<Game> games = new List<Game>();
        static void Main(string[] args)
        {
            ReadInput();
            //Console.WriteLine(GetSumOfPossibleGames(12, 13, 14));
            Console.WriteLine(GetSumOfThePowers());
            Console.ReadLine();

        }

        static void ReadInput()
        {
            var lines = File.ReadLines(input);

            foreach (var line in lines)
            {
                Game game = new Game(line.Trim());
                games.Add(game);
  
            }
        }

        static bool IsGamePossible(Game game, int red, int green, int blue)
        {
            foreach(var set in game.CubeSets)
            {
                if(set.Red > red || set.Green > green || set.Blue > blue)
                    return false;
            }
            return true;
        }

        static int GetSumOfPossibleGames(int red, int green ,int blue)
        {
            int sum = 0;
            foreach(var game in games)
            {
                if(IsGamePossible(game, red, green, blue))
                {
                    sum += game.Id;
                }
            }
            return sum;
        }

        static int GetSumOfThePowers()
        {
            int sum = 0;

            foreach(var game in games)
            {
                sum += GetPowerOfGame(game);
                //Console.WriteLine(GetPowerOfGame(game));
            }

            return sum;
        }

        static int GetPowerOfGame(Game game)
        {
            int minRed = 0, minGreen = 0, minBlue = 0;
            foreach(var set in game.CubeSets)
            {
                if(set.Red > minRed) minRed = set.Red;
                if(set.Green > minGreen) minGreen = set.Green;
                if(set.Blue > minBlue) minBlue = set.Blue;
            }
            return minRed * minGreen * minBlue;
        }
    }
}
