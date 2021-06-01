using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    public class Square : SquareBase
    {
        private string Name;
        private int index;
        private int Cost;

        public Square(string name, int ind, int cost, LinkedList<int> branches):base(name, ind, cost)
        {
            this.Cost = cost;
            
            this.Branches = branches;
            Branches.AddLast(0);
        }
        public override int GetCost() => Cost;

        
    }
}
