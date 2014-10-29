using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper.Business
{
    public class CoveredFlaggedSquareState : SquareState
    {
        public override void ToggleFlag(Square square)
        {
            square.IsFlagged = false;
            square.SquareState = new ConveredUnflaggedSquareState();
        }

        public override void Uncover(Square square)
        {
        }

        public override bool IsFlagged
        {
            get { return true; }
        }

        public override bool IsCovered
        {
            get { return true; }
        }
    }
}
