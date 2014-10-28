using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Cup : IRollable
    {
        public IList<IRollable> Dice { get; private set; }
        public Cup(int numDie)
        {
            NumDie = numDie;
            Dice = RollableFactory.GetDie(numDie);
        }

        public int NumDie { get; set; }

        public int LastValue { get; private set; }

        public int Roll()
        {
            LastValue = Dice.Sum(die => die.Roll());
            return LastValue;
        }
    }
}
