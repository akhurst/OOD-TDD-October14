using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD.Tests
{
    public static class RollableTestExtensions
    {
        public static List<int> SetUp1000000Results(this IRollable rollable)
        {
            var rollableResults = new List<int>();

            for (int i = 0; i < 1000000; i++)
            {
                int result = rollable.Roll();
                rollableResults.Add(result);
            }

            return rollableResults;
        }

    }
}
