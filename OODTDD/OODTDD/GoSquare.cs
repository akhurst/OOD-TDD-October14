using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class GoSquare : Square
    {
        public event EventHandler<PlayerPassedEventArgs> PlayerPassed;

        public override void EnterSquare(Player player)
        {
            base.EnterSquare(player);
            if (PlayerPassed != null)
            {
                PlayerPassed(this, new PlayerPassedEventArgs(player));
            }
            player.Credit(200);
        }
    }
}
