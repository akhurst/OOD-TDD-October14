using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Die : IRollable
    {
        private readonly IRandomizer randomizer;
        public Die()
        {
            randomizer = new RandomNumberAdapter();
        }

        public int Roll()
        {
            var value = randomizer.GetRandomNumber(1, 6);
            LastValue = value;
            return value;
        }

        public int LastValue { get; private set; }
    }
}
