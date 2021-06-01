using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    class ThirdBranch:SquareDecorator
    {
        public ThirdBranch(SquareBase square) : base(square.GetName().Replace(" с двумя филиалами", " с тремя филиалами"), square.GetIndex(), square.GetCost(), square)
        {
            Branches.AddLast(3);
        }
        public override int GetCost()
        {
            return square.GetCost() + 300;
        }
    }
}
