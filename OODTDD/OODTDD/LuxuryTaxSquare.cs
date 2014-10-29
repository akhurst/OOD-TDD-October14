using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
	public class LuxuryTaxSquare : Square
	{
		public override void LandOn(Player player)
		{
			//player.Balance -= Math.Min((int)player.Balance * 0.1, 200);
		}
	}
}
