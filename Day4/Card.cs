using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    internal class Card
    {
        public int Id;

        public List<int> WinningNumbers = new List<int>();
        public List<int> MyNumbers = new List<int>();

        public Card(string gameInput)
        {
            Id = int.Parse(gameInput.Split(':')[0].Substring(5));//Skip 'Card ' text symbols
            var inputSets = gameInput.Split(':')[1].Split('|');

            //Winning numbers
            var numbers = inputSets[0].Trim().Split(' ').ToList();
            foreach (var number in numbers)
            {
                if(number != "")
                    WinningNumbers.Add(int.Parse(number.Trim()));
            }

            //My numbers
            numbers = inputSets[1].Trim().Split(' ').ToList();
            foreach(var number in numbers)
            {
                if (number != "")
                    MyNumbers.Add(int.Parse(number.Trim()));
            }
        }
    }
}
