using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Game
    {
        public Game(int numPlayers)
        {
            if (numPlayers > 10 || numPlayers < 2)
            {
                throw new ArgumentException();
            }

            InitializePlayers(numPlayers);
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Board = new Board();
        }

        private void InitializePlayers(int numPlayers)
        {
            Players = new List<Player>();

            for (int i = 0; i < numPlayers; i++)
            {
                Players.Add(new Player("Player " + i));
            }
        }

        public IList<Player> Players { get; set; }
        public Board Board { get; set; }
    }
}
