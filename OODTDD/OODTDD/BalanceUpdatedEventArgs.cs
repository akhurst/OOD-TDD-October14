using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
	public class BalanceUpdatedEventArgs : EventArgs
	{
		public Player Player { get; private set; }
		public BalanceUpdatedEventArgs(Player player)
        {
            Player = player;
        }
	}
}
