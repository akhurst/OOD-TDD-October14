using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Square
    {
        public Square NextSquare { get; set; }

        public virtual void PassOver(Player player)
        {
        }

		public virtual void LandOn(Player player)
		{
			
		}
    }
}
