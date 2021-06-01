using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    public class MonopolyGame
    {
        private const int rounds = 40;
        private const int players_number = 2;
        private List<Player> players = new List<Player>(players_number);
        private Board board = new Board();
        private Die[] dice = { new Die()};
        private int moneyp1 = 1500;
        private int moneyp2 = 1500;

        public MonopolyGame()
        {
            Player player;
            Console.WriteLine("Введите имена игроков");
            string name = Console.ReadLine();
            string name1 = Console.ReadLine();
            player = new Player($"{name}", dice, board, moneyp1);
            players.Add(player);
            player = new Player($"{name1}", dice, board, moneyp2);
            players.Add(player);
        }
        public void playGame()
        {
                for (int i = 0; i < rounds; i++) playround();
        }
        public List<Player> getPlayers() => players;
        private void playround()
        {
                for (IEnumerator<object> enumerator = players.GetEnumerator(); enumerator.MoveNext();)
                {
                    if (players[0].getMoney() > 0 && players[1].getMoney() > 0)
                    {
                        Console.Clear();
                        Player player = (Player)enumerator.Current;
                        var loc1 = player.getLocation().GetIndex();
                        player.takeTurn();
                        var loc2 = player.getLocation().GetIndex();
                        //int i = players[1].GetEsate().Count;
                        if (loc1 > loc2) player.setMoney(200);
                        Console.WriteLine("Имя игрока: " + $"{players[0].getName()}" +
                                         '\n' + "Позиция: " + $"{players[0].getLocation().GetName()}" + " цена:" + $"{players[0].getLocation().GetCost()}" +
                                         '\n' + "Количество денег: " + $"{players[0].getMoney()}");
                        players[0].Print();
                        Console.SetCursorPosition(70, 0);
                        Console.WriteLine("Имя игрока: " + $"{players[1].getName()}");
                        Console.SetCursorPosition(70, 1);
                        Console.WriteLine("Позиция: " + $"{players[1].getLocation().GetName()}"+ " цена:"+ $"{players[1].getLocation().GetCost()}");
                        Console.SetCursorPosition(70, 2);
                        Console.WriteLine("Количество денег: " + $"{players[1].getMoney()}");
                    int j = 0;
                    string s = "";
                    LinkedListNode<int> temp = players[1].GetEsate().First;
                    for (int i=0;i< players[1].GetEsate().Count; i++)
                    {
                        Console.SetCursorPosition(70, 3 + i);
                        ;
                        Console.WriteLine(board.GetSquare(board.GetStartSquare(), temp.Value).GetName());
                        temp = temp.Next;
                    }
                    Console.ReadKey();
                    }
                    else
                    {
                    Console.Clear();
                    if (players[0].getMoney() < 0)
                        
                        Console.WriteLine($"{players[0].getName()}" + " проиграл");
                        
                    else
                        
                        Console.WriteLine($"{players[1].getName()}" + " проиграл");
                        
                    }
                }

            


        }
      
    }
}
