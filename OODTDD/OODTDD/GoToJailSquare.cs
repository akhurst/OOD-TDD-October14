using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
    public class GoToJailSquare : Square
    {
        public Square JailSquare { get; set; }

        public override void LandOn(Player player)
        {
            player.JumpTo(JailSquare);
            player.IsInJail = true;
        }

        
    }
}
