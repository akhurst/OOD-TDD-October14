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

            InitializeBoard();
            InitializeDice();
            InitializePlayers(numPlayers);
        }

        private void InitializeDice()
        {
            Cup = new Cup(2);
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
                var player = new Player("Player " + i);
                Players.Add(player);
                player.CurrentSquare = Board.FirstSquare;
            }
        }

        public IList<Player> Players { get; set; }
        public Board Board { get; set; }
        public Cup Cup { get; set; }
    }
}
