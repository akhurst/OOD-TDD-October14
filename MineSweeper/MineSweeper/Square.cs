using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper.Business
{
    public class Square
    {
        private Boolean isCovered = true;
        public Boolean IsMine { get; private set; }
        public int Value { get; private set; }

        public List<Square> Neighbors { get; set; }

        public event EventHandler<SquareUncoveredEventArgs> SquareUncovered;

        public Square(Boolean isMine)
        {
            IsMine = isMine;
            SquareState = new ConveredUnflaggedSquareState();
        }

        public bool IsCovered
        {
            get { return SquareState.IsCovered; }
        }

        public void IncrementValue()
        {
            Value++;
        }

        public void Uncover()
        {
            SquareState.Uncover(this);
        }

        public void UncoverCoveredSquare()
        {
            if (!IsMine)
            {
                if (Value == 0)
                {
                    foreach (Square neighbor in Neighbors)
                    {
                        neighbor.Uncover();
                    }
                }
            }

            if (SquareUncovered != null)
            {
                SquareUncovered(this, new SquareUncoveredEventArgs(IsMine));
            }
        }

        public void ToggleFlag()
        {
	       SquareState.ToggleFlag(this);
        }

        public bool IsFlagged { get; set; }
        public SquareState SquareState { get; set; }

        public override string ToString()
        {
            if (IsMine)
            {
                return "*";
            }
            else { 
                return Value.ToString();
            }
        }

        public void MakeMine()
        {
            IsMine = true;
        }
    }
}
