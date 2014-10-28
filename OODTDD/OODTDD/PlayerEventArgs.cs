using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class PlayerEventArgs : EventArgs
    {
        public Player Player { get; private set; }
        public PlayerEventArgs(Player player)
        {
            Player = player;
        }
    }
}
