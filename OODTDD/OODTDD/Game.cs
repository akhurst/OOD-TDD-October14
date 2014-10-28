using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Game
    {
        public Game(int numPlayers, Cup cup = null)
        {
            if (numPlayers > 10 || numPlayers < 2)
            {
                throw new ArgumentException();
            }

            InitializeBoard();
            InitializeDice(cup);
            InitializePlayers(numPlayers);
        }

        private void InitializeDice(Cup cup)
        {
            if (cup == null)
            {
                Cup = new Cup(2);
            }
            else
            {
                Cup = cup;
            }
        }

        private void InitializeBoard()
        {
            Board = new Board();
            Board.GoSquare.PlayerPassed += GoSquare_PlayerPassed;
        }

        void GoSquare_PlayerPassed(object sender, PlayerEventArgs e)
        {
            
        }

        private void InitializePlayers(int numPlayers)
        {
            Players = new List<Player>();

            for (int i = 0; i < numPlayers; i++)
            {
                var player = new Player("Player " + i, Board.GoSquare);
                Players.Add(player);
                player.BalanceUpdated += Player_BalanceUpdated;
            }
        }

        private void Player_BalanceUpdated(object sender, PlayerEventArgs e)
        {
            if (e.Player.Balance >= 1000)
            {
                Winner = e.Player;
            }
        }

        public IList<Player> Players { get; set; }
        public Board Board { get; set; }
        public Cup Cup { get; set; }
        public bool IsOver { get { return Winner != null; } }
        public Player Winner { get; set; }

        public void PlayRound()
        {
            if(IsOver)
                throw new GameOverException();

            foreach (var player in Players)
            {
                player.TakeTurn(Cup);
                if (IsOver) break;
            }
        }
    }
}
