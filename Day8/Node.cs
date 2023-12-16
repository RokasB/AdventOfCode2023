using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Node
    {
        public string Name;
        public string Left;
        public string Right;

        public Node(string name, string left, string right)
        {
            this.Name = name;
            this.Left = left;
            this.Right = right;
        }
    }
}
