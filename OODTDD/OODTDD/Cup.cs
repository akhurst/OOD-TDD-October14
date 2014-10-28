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

        public Cup(): this(2)
        {
            
        }

        public int NumDie { get; set; }

        public virtual List<int> LastValue { get; private set; }

        public virtual int Roll()
        {
            LastValue = Dice.Select(die => die.Roll()).ToList();
            return LastValue.Sum();
        }
    }
}
