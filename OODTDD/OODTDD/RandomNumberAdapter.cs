using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
    public class RandomNumberAdapter : IRandomizer
    {
        private static readonly Random randomGenerator = new Random();

        public int GetRandomNumber(int minValue, int maxValue)
        {
            return randomGenerator.Next(minValue, maxValue + 1);
        }
    }
}
