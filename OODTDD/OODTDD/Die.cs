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
            FaceValue = value;
            return value;
        }

        public int FaceValue { get; private set; }
    }
}
