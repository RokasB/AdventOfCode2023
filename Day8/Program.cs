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
            Console.WriteLine(GetGhostSteps());
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

        public static int GetGhostSteps(string startNode)
        {
            int count = 0;
            string currentNode = startNode;

            while (true)
            {
                foreach (var instruction in instructions)
                {
                    if (currentNode.EndsWith("Z"))
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

        //Get least common multiple of each ghost paths
        //https://math.libretexts.org/Courses/Mount_Royal_University/MATH_2150%3A_Higher_Arithmetic/4%3A_Greatest_Common_Divisor_least_common_multiple_and_Euclidean_Algorithm/4.3%3A_Least_Common_Multiple
        public static long GetGhostSteps()
        {
            List<string> ghostPaths = new List<string>();
            ghostPaths = nodes.Where(p => p.Key.EndsWith("A")).Select(p => p.Key).ToList();

            List<int> pathSteps = new List<int>();

            foreach(var ghostPath in ghostPaths)
            {
                pathSteps.Add(GetGhostSteps(ghostPath));
            }

            foreach(var pathStep in pathSteps)
            {
                Console.WriteLine(pathStep);
            }
            List<int> testList = new List<int>() { 21883, 13019, 11911, 16897 };
            return LCMOfList(pathSteps);
        }

        //Purely copypasta from ChGippity
        static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static long LCM(long a, long b)
        {
            return (a / GCD(a, b)) * b;  // Watch out for the order to avoid overflow
        }

        static long LCMOfList(List<int> numbers)
        {
            long result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                result = LCM(result, numbers[i]);
            }
            return result;
        }
    }
}
