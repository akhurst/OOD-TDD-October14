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
            return GetSingleDie(new RandomAdapter());
        }

        public static IRollable GetSingleDie(IRandomizer randomizer)
        {
            return new Die(randomizer);
        }

        public static IList<IRollable> GetDie(int numDie)
        {
            return GetDie(numDie, new RandomAdapter());
        }

        public static IList<IRollable> GetDie(int numDie, IRandomizer randomizer)
        {
            var dice = new List<IRollable>();
            for (var i = 0; i < numDie; i++)
            {
                dice.Add(GetSingleDie(randomizer));
            }
            return dice;
        }
    }
}
