using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
    public class IncomeTaxSquare : Square
    {
        public override void LandOn(Player player)
        {
            var playerTotal = player.TotalDollars;
            const double maxDebit = 200;
            double toDebit = Math.Min(maxDebit, playerTotal * 0.1);

            player.Debit((int)Math.Floor(toDebit));
        }
    }
}
