using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleMonopoly
{
    public class Board
    {
        private const int Size = 10;
        private List<object> Squares = new List<object>();

        public Board()
        {
            BuildSquares();
            LinkSquares();
        }

        public SquareBase GetSquare(SquareBase start, int distance)
        {
            int end = (start.GetIndex() + distance) % Size;
            return (SquareBase)Squares.ElementAt(end);
        }

        public SquareBase GetStartSquare() => (SquareBase)Squares.ElementAt(0);

        public void BuildSquares()
        {
            for (int i = 1; i <= Size; i++) build(i);
        }

        private void build(int i)
        {
            SquareBase square = new Square("Square " + i, i - 1, 100+10*i,  new LinkedList<int>());
            Squares.Add(square);
        }
        
        private void LinkSquares()
        {
            for (int i = 0; i < (Size - 1); i++) link(i);
            Square first = (Square)Squares.ElementAt(0);
            Square last = (Square)Squares.ElementAt(Size - 1);
            last.setNextSquare(first);
        }
        private void link(int i)
        {
            Square current = (Square)Squares.ElementAt(i);
            Square next = (Square)Squares.ElementAt(i + 1);
            current.setNextSquare(next);
        }
    }
}
