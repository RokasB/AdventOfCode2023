using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day8\\input.txt";

        static string instructions;

        static Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        static void Main(string[] args)
        {
            ReadInput();
            Console.WriteLine(GetSteps());
            Console.ReadLine();
        }

        public static void ReadInput()
        {
            var lines = File.ReadLines(input);

            instructions = lines.First();

            foreach (var line in lines.Skip(2))
            {
                string name = line.Split('=')[0].Trim();
                string left = new string(line.Split('=')[1].Trim().Split(',')[0].Skip(1).ToArray());
                string right = new string(line.Split('=')[1].Trim().Split(',')[1].Trim().Take(3).ToArray());//Would be better to take originalString.Length - 1
                Node node = new Node(name, left, right);

                nodes.Add(node.Name, node);
            }
        }

        public static int GetSteps()
        {
            int count = 0;
            string currentNode = "AAA";

            while (true)
            {
                foreach(var instruction in instructions)
                {
                    if (currentNode == "ZZZ")
                        return count;

                    if (instruction == 'L')
                    {
                        currentNode = nodes[currentNode].Left;
                    }
                    else//Assuming 'R'
                    {
                        currentNode = nodes[currentNode].Right;
                    }
                    count++;
                }
            }
        }
    }
}
