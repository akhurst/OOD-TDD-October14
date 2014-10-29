using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper.Business
{
    public class ConveredUnflaggedSquareState : SquareState
    {
        public override void ToggleFlag(Square square)
        {
            square.IsFlagged = true;
            square.SquareState=new CoveredFlaggedSquareState();
        }

        public override void Uncover(Square square)
        {
            square.SquareState = new UncoveredSquareState();
            square.UncoverCoveredSquare();
        }

        public override bool IsFlagged
        {
            get { return false; }
        }

        public override bool IsCovered
        {
            get { return true; }
        }
    }
}
