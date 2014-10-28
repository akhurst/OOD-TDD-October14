using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Die : IRollable
    {
        readonly Random random = new Random();
        public int Roll()
        {
            var value = random.Next(1, 7);
            LastValue = value;
            return value;
        }

        public int LastValue { get; private set; }
    }
}
