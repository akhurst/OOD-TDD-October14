using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper.Business
{
    public class SquareUncoveredEventArgs : EventArgs
    {
        public SquareUncoveredEventArgs(bool wasMine)
        {
            this.WasMine = wasMine;
        }

        public bool WasMine { get; private set; }
    }
}
