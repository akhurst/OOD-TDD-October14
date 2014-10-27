using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Cup : IRollable
    {
        private readonly IList<IRollable> dice; 
        public Cup(int numDie)
        {
            dice = RollableFactory.GetDie(numDie);
        }

        public int Roll()
        {
            return dice.Sum(die => die.Roll());
        }
    }
}
