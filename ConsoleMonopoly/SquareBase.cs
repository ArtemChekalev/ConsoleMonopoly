using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    public abstract class SquareBase
    {
        private string Name;
        private SquareBase Next;
        private int index;
        private int Cost;
        private bool bought;
        public LinkedList<int> Branches = new LinkedList<int>();
        public SquareBase(string name, int ind, int cost)
         {
            this.Name = name;
            this.index = ind;
            this.Cost = cost;
         }
        public abstract int GetCost();
        public void setNextSquare(SquareBase square)
        {
            Next = square;
        }
        public SquareBase getNextSquare() => Next;
        public string GetName() => Name;
       // public string SetName(string i) => Name += i;
        public int GetIndex() => index;

        public bool Buy(Board board, int i)
        {
            return board.GetSquare(board.GetStartSquare(), i).bought = true;
        }

        public bool isBought(Board board, int i)
        {
            return board.GetSquare(board.GetStartSquare(), i).bought;
        }

        public void SetLoc(SquareBase square)
        {
            this.Name = square.Name;
            this.Cost = square.GetCost();
            this.Branches = square.Branches;
        }
       // public LinkedList<int> GetBranches() => Branches;
    }
}
