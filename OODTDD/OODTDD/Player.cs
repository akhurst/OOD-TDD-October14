using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Player
    {
        private int doublesCounter = 0;

        public Player(string token, Square startingPosition)
        {
            Token = token;
            CurrentSquare = startingPosition;
        }

        public event EventHandler<PlayerEventArgs> BalanceUpdated; 
        public string Token { get; private set; }
        public Square CurrentSquare { get; private set; }
        public int Balance { get; private set; }

        public void TakeTurn(Cup cup)
        {
            cup.Roll();

            Move(cup);

            if (cup.LastRollWasDoubles && doublesCounter < 2)
            {
                doublesCounter++;
                TakeTurn(cup);
            }

            doublesCounter = 0;
        }

        private void Move(Cup cup)
        {
            for (int i = 0; i < cup.LastValue; i++)
            {
                Step();
            }
        }

        private void Step()
        {
            CurrentSquare = CurrentSquare.NextSquare;
            CurrentSquare.PassOver(this);
        }

        public void Credit(int amount)
        {
            Balance += amount;
            if (BalanceUpdated != null)
            {
                BalanceUpdated(this, new PlayerEventArgs(this));
            }
        }
    }
}
