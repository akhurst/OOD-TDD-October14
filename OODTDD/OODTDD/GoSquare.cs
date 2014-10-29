using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class GoSquare : Square
    {
        public event EventHandler<PlayerPassedEventArgs> PlayerPassed;

        public override void PassOver(Player player)
        {
            base.PassOver(player);
            if (PlayerPassed != null)
            {
                PlayerPassed(this, new PlayerPassedEventArgs(player));
            }
            player.Credit(200);
        }
    }
}
