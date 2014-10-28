using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
    public class RandomAdapter : IRandomizer
    {
        private static readonly Random random = new Random();

        public int GetRandomNumber(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue + 1);
        }
    }
}
