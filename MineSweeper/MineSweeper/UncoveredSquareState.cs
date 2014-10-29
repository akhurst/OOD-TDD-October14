using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper.Business
{
    public class UncoveredSquareState : SquareState
    {
        public override void ToggleFlag(Square square)
        {
        }

        public override void Uncover(Square square)
        {
        }

        public override bool IsFlagged
        {
            get { return false; }
        }

        public override bool IsCovered
        {
            get {return false; }
        }
    }
}
