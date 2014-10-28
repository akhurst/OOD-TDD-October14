using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class PlayerPassedEventArgs : EventArgs
    {
        public Player Player { get; private set; }
        public PlayerPassedEventArgs(Player player)
        {
            Player = player;
        }
    }
}
