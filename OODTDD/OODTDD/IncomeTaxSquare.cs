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
			base.LandOn(player);
			int x = Convert.ToInt32(player.Balance * 0.1);
			player.Debit(Math.Min(200, x));
		}
	}
}
