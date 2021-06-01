using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    public class Piece
    {
        private SquareBase location;
        

        public Piece(SquareBase loc)
        {
            this.location = loc;
        }

        public void SetLocation(SquareBase loc)
        {
            this.location = loc;
        }
        public SquareBase GetLocation() => location;
       
    }
}
