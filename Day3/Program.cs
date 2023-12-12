using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Program
    {
        static string input = "C:\\Users\\dev\\source\\repos\\AdventOfCode2023\\Day3\\input.txt";
        static char[,] engineMatrix;
        static void Main(string[] args)
        {
            ReadInput();
            //PrintMatrix();
            Console.WriteLine(GetSumOfPartNumbers());
            Console.ReadLine();
        }

        static void ReadInput()
        {
            var lines = File.ReadAllLines(input);
            int rows = lines.Length;
            int cols = lines[0].Length;

            engineMatrix = new char[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    engineMatrix[i,j] = lines[i][j];
                }
            }
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < engineMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < engineMatrix.GetLength(1); j++)
                {
                    Console.Write(engineMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static bool CheckIfSymbolAdjacent(int row, int numberStartIndex, int numberEndIndex)
        {
            //create a square around given number coordinates
            int top, bottom, left, right;

            if(row - 1 >= 0) top = row - 1;
            else top = 0;

            if (row + 1 <= engineMatrix.GetLength(0) - 1) bottom = row + 1;
            else bottom = engineMatrix.GetLength(0) - 1;

            if(numberStartIndex - 1 >= 0) left = numberStartIndex - 1;
            else left = 0;

            if(numberEndIndex + 1 <= engineMatrix.GetLength(1) - 1) right = numberEndIndex + 1;
            else right = engineMatrix.GetLength(1) - 1;

            for(int i = top; i <= bottom; i++)
            {
                for(int j = left; j <=right; j++)
                {
                    if (engineMatrix[i,j] != '.' && !char.IsNumber(engineMatrix[i,j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static int GetSumOfPartNumbers()
        {
            int sum = 0;

            for (int i = 0;i < engineMatrix.GetLength(0);i++)
            {
                for(int j = 0;j < engineMatrix.GetLength(1);j++)
                {
                    if (char.IsNumber(engineMatrix[i,j]))
                    {
                        int startIndex = j;
                        while (j + 1 < engineMatrix.GetLength(1) && char.IsNumber(engineMatrix[i, j + 1]))
                        {
                            j++;
                        }
                        int endIndex = j;

                        if(CheckIfSymbolAdjacent(i,startIndex,endIndex))
                        {
                            string snumber = "";
                            for(int k =  startIndex; k <= endIndex; k++)
                            {
                                snumber += engineMatrix[i, k];
                            }
                            int number = int.Parse(snumber);
                            Console.WriteLine(number);
                            sum += number;
                        }
                    }
                }
            }

            return sum;
        }

        static int SubstituteForGears()
        {
            int sum = 0;

            for (int i = 0; i < engineMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < engineMatrix.GetLength(1); j++)
                {
                    if (engineMatrix[i, j] == '*')
                    {
                        int num1, num2;
                        if(IsAdjacentToTwoNumbers(int i, int j, out num1, out num2))
                        {
                            int ratio = num1 * num2;
                            sum += ratio - num1 - num2;
                        }

                       
                    }
                }
            }
            return sum;
        }

        static bool IsAdjacentToTwoNumbers(int i, int j, out int num1, out int num2)
        {
            int top, bottom, left, right;

            if (i - 1 >= 0) top = i - 1;
            else top = 0;

            if (i + 1 <= engineMatrix.GetLength(0) - 1) bottom = i + 1;
            else bottom = engineMatrix.GetLength(0) - 1;

            if (j - 1 >= 0) left = j - 1;
            else left = 0;

            if (j + 1 <= engineMatrix.GetLength(1) - 1) right = j + 1;
            else right = engineMatrix.GetLength(1) - 1;


        }
    }
}
