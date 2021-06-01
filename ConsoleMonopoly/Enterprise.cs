using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    class Enterprise:SquareDecorator
    {
        public Enterprise(SquareBase square) : base(square.GetName().Replace(" с тремя филиалами", " с предприятием"), square.GetIndex(), square.GetCost(), square)
        {
            Branches.AddLast(4);
        }
        public override int GetCost()
        {
            return square.GetCost() + 500;
        }
    }
}
