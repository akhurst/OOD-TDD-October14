using System.Collections.Generic;

namespace OODTDD.Monopoly
{
    public class Game
    {
        public Board Board { get; set; }
        public IEnumerable<Player> Players { get; set; }
        private Cup cup = new Cup(2);
        public GameState GameState;

        public int currentPlayerIndex;

        public void RollAndMove(Player player1)
        {
            var roll = cup.Roll();

            //Roll conditions

            this.Board.MoveToken(player1.Token, roll);
        }


    }

    public enum GameState
    {
        Finished
    }
}