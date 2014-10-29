using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
	public class LuxurySquare : Square
	{
		public override void LandOn(Player player)
		{
			base.LandOn(player);
			player.Debit(75);
		}
	}
}
