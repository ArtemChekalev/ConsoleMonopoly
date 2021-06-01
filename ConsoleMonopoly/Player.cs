using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    public class Player 
    {
        private string Name;
        private Piece piece;
        private Board board;
        private Die[] dice;
        private int money;
        private LinkedList<int> Real_Estate = new LinkedList<int>();
        private LinkedList<int> branches;
        Random rnd = new Random();

        public Player(string name, Die[] dice, Board board, int money)
        {
            this.Name = name;
            this.dice = dice;
            this.board = board;
            this.money = money;
            piece = new Piece(board.GetStartSquare());
        }
        public void takeTurn()
        {
            int rollvalue = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i].roll();
                rollvalue += dice[i].GetValue();
            }
            var square = board.GetSquare(piece.GetLocation(), rollvalue);
            SquareBase newLoc = new Square(square.GetName(), square.GetIndex(), square.GetCost(), square.Branches);
            branches = newLoc.Branches;
            piece.SetLocation(newLoc);
            int temp = rnd.Next(2) + 1;
            Console.SetCursorPosition(30, 20);
            if (newLoc.isBought(board, newLoc.GetIndex()))
            {
                if (Real_Estate.Contains(newLoc.GetIndex()))
                {
                    if (branches.Contains(4))
                    {

                    }
                    else if (branches.Contains(3))
                    {
                        newLoc = new Enterprise(newLoc);
                        piece.SetLocation(newLoc);
                        board.GetSquare(piece.GetLocation(), 0).SetLoc(newLoc);
                    }
                    else if (branches.Contains(2))
                    {
                        newLoc = new ThirdBranch(newLoc);
                        piece.SetLocation(newLoc);
                        board.GetSquare(piece.GetLocation(), 0).SetLoc(newLoc);
                    }
                    else if (branches.Contains(1))
                    {
                        newLoc = new SecondBranch(newLoc);
                        piece.SetLocation(newLoc);
                        board.GetSquare(piece.GetLocation(), 0).SetLoc(newLoc);
                    }
                    else if (branches.Contains(0))
                    {
                        newLoc = new FirstBranch(newLoc);
                        piece.SetLocation(newLoc);
                        board.GetSquare(piece.GetLocation(), 0).SetLoc(newLoc);
                    }
                }
                else
                {
                    money = money - newLoc.GetCost() / 2;
                    Console.WriteLine("Игрок " + $"{Name}" + " находится на чужой собственности и " +
                        "получает штраф " + $"{newLoc.GetCost() / 2}");
                }
            }
            else if (temp == 1)
            {
                Buy(newLoc.GetCost());
                newLoc.Buy(board, newLoc.GetIndex());
                Real_Estate.AddLast(newLoc.GetIndex());

                Console.WriteLine("Игрок " + $"{ Name} " + " купил " + $"{newLoc.GetName()}" + " за " + $"{newLoc.GetCost()}");
            }
            else
            {
                Console.WriteLine("Игрок " + $"{ Name} " + " находится на  " + $"{newLoc.GetName()}");
            }
            Console.SetCursorPosition(0, 0);
        }
        public SquareBase getLocation() => piece.GetLocation();
        public string getName() => Name;
        public int getMoney() => money;
        public void setMoney(int i)
        {
            money = money + i;
        }

        public void Buy(int i)
        {
            money = money - i;
        }
        public void Print()
        {
            foreach (int el in Real_Estate) Console.Write($"{board.GetSquare(board.GetStartSquare(), el).GetName()}" + '\n');
        }
        public LinkedList<int> GetEsate() => Real_Estate;
    }
}
