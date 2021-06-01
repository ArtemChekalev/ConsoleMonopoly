using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    class SecondBranch:SquareDecorator
    {
        public SecondBranch(SquareBase square) : base(square.GetName().Replace(" с одним филиалом", " с двумя филиалами"), square.GetIndex(), square.GetCost(), square)
        {
            Branches.AddLast(2);
        }
        public override int GetCost()
        {
            return square.GetCost() + 200;
        }
    }
}
