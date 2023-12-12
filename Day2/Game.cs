using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    internal class Game
    {
        public int Id { get; set; }
        public List<CubeSet> CubeSets { get; set; } = new List<CubeSet>();

        public Game(string gameInput)
        {
            Id = int.Parse(gameInput.Split(':')[0].Substring(5));//Game always has 5 chars
            var inputSets = gameInput.Split(':')[1].Split(';');
            foreach (var inputSet in inputSets)
            {
                CubeSet cubeSet = new CubeSet();
                var colors = inputSet.Split(',');

                foreach (var color in colors)
                {
                    var set = color.Trim().Split(' ');
                    if (set[1] == "red")
                    {
                        cubeSet.Red = int.Parse(set[0]);
                    }
                    if (set[1] =="green")
                    {
                        cubeSet.Green = int.Parse(set[0]);
                    }
                    if (set[1] =="blue")
                    {
                        cubeSet.Blue = int.Parse(set[0]);
                    }
                }
                CubeSets.Add(cubeSet);
            }
        }
    }

    internal class CubeSet
    {
        public int Red { get; set; } = 0;
        public int Green { get; set; } = 0;
        public int Blue { get; set; } = 0;
    }
}
