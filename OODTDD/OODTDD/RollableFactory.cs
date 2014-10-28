using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
    public static class RollableFactory
    {
        public static IRollable GetSingleDie()
        {
            
            return new Die();
        }

        public static IList<IRollable> GetDie(int numDie)
        {
            Random _rand = new Random();

            var dice = new List<IRollable>();
            for (var i = 0; i < numDie; i++)
            {
                dice.Add(GetSingleDie());
            }
            return dice;
        }
    }
}
