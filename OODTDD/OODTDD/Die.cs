using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Die : IRollable
    {
        public int Roll()
        {
            var value = new Random().Next(1, 7);
            LastValue = value;
            return value;
        }

        public int LastValue { get; private set; }
    }
}
