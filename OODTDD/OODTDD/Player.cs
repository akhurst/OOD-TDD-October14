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

        public void TakeTurn(Cup cup)
        {
            cup.Roll();

            for (int i = 0; i < cup.LastValue; i++)
            {
                CurrentSquare = CurrentSquare.NextSquare;
            }
        }
    }
}
