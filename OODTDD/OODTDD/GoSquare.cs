﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class GoSquare : Square
    {
        public event EventHandler<PlayerEventArgs> PlayerPassed;

        public override void PassOver(Player player)
        {
            base.PassOver(player);
            player.Credit(200);
            if (PlayerPassed != null)
            {
                PlayerPassed(this, new PlayerEventArgs(player));
            }
        }
    }
}
