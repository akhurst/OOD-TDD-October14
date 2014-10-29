using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Player
    {
        public Player(string token, Square startingPosition)
        {
            Token = token;
            CurrentSquare = startingPosition;
        }

        public string Token { get; private set; }
        public Square CurrentSquare { get; private set; }
        public int TotalDollars { get; private set; }

        private int doublesCount;

        public event EventHandler<PlayerPassedEventArgs> PlayerCredited;

        public void TakeTurn(Cup cup)
        {
            cup.Roll();

            Move(cup);
            if (doublesCount < 2 && cup.IsLastRollDouble)
            {
                doublesCount++;
                TakeTurn(cup);
            }
            doublesCount = 0;
        }

        private void Move(Cup cup)
        {
            for (int i = 0; i < cup.LastValue; i++)
            {
                Step((i == cup.LastValue - 1));
            }
        }

        private void Step(bool isLastStep)
        {
            CurrentSquare = CurrentSquare.NextSquare;
            CurrentSquare.EnterSquare(this);
            if (isLastStep)
            {
                CurrentSquare.LandOn(this);
            }
        }

        public void Credit(int toAdd)
        {
            TotalDollars += toAdd;
            if (PlayerCredited != null)
            {
                PlayerCredited(this, new PlayerPassedEventArgs(this));
            }
        }

        public void Debit(int toSubtract)
        {
            TotalDollars -= toSubtract;
        }
    }
}
