using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMonopoly
{
    public class Die
    {
        public const int Max = 6;
        private int Value;
        Random rand = new Random();

        public Die()
        {
            roll();
        }

        public void roll()
        {
            Value = rand.Next(Max) + 1;
        }
        public int GetValue() => Value;
    }
}
