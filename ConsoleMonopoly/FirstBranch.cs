using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    class FirstBranch: SquareDecorator
    {
        public FirstBranch(SquareBase square):base(square.GetName() + " с одним филиалом", square.GetIndex(),square.GetCost(), square)
        {
            Branches.AddLast(1);
        }
        public override int GetCost()
        {
            return square.GetCost()+100;
        }
    }
}
