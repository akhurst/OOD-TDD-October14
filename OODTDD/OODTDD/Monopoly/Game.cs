using System.Collections.Generic;
using System.Linq;

namespace OODTDD.Monopoly
{
    public class Game
    {
        public Board Board { get; set; }
        public LinkedList<Player> Players { get; set; }
        public Cup cup = new Cup(2);
        public GameState GameState;
        public LinkedListNode<Player> CurrentPlayer { get; set; } 
        
        public void RollAndMove(Player player1)
        {
            var roll = cup.Roll();

            //Roll conditions
            var events = this.Board.MoveToken(player1.Token, roll);
            foreach (IGameEvent e in events)
            {
                e.InvokeEvent(this);
            }
        }

        public bool PassedGo(IEnumerable<ISquare> passedSquares )
        {
            return passedSquares.Contains(Board.GetStartingSquare());
        }

        public void TakeTurn()
        {
            RollAndMove(CurrentPlayer.Value);

            if (Players.Any(x => x.Money >= 1000))
                this.GameState = GameState.Finished;

            if (cup.LastValue.Max() != cup.LastValue.Min())
            {
                CurrentPlayer = CurrentPlayer.CircularNext();
            }
        }
    }

    public enum GameState
    {
        Active,
        Finished
    }
}