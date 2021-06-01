using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    abstract public class SquareDecorator: SquareBase
    {
        protected SquareBase square;
        public SquareDecorator(string name, int ind, int cost, SquareBase Square): base(name, ind, cost)
        {
            this.square = Square;
        }
    }
}
