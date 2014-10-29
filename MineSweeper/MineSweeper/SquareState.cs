using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper.Business
{
    public abstract class SquareState
    {
        public abstract void ToggleFlag(Square square);
        public abstract void Uncover(Square square);

        public abstract bool IsFlagged { get; }
        public abstract bool IsCovered { get; }
    }
}
