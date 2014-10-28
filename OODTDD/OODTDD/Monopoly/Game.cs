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
        private int _times;
        public IEnumerable<IWinCondition> WinConditions { get; set; } 
        
        public void RollAndMove(Player player1)
        {
            var roll = cup.Roll();

            //Roll conditions
            var events = this.Board.MoveToken(player1.Token, roll);

            InvokeEvents(events);
        }

        private void InvokeEvents(IEnumerable<IGameEvent> events)
        {
            foreach (IGameEvent e in events)
            {
                e.InvokeEvent(this);
                TestWinConditions();
                if (GameState == GameState.Finished)
                    break;
            }
        }

        private void TestWinConditions()
        {
            if (WinConditions.Any(x => x.IsWinCondition(this)))
            {
                this.GameState = GameState.Finished;
            }
        }

        public bool PassedGo(IEnumerable<ISquare> passedSquares )
        {
            return passedSquares.Contains(Board.GetStartingSquare());
        }

        public void TakeTurn()
        {
            RollAndMove(CurrentPlayer.Value);
            
            _times++;

            if (cup.LastValue.Max() == cup.LastValue.Min())
            {
                if (_times <= 2)
                CurrentPlayer = CurrentPlayer.CircularNext();
                _times = 0;
            }
        }
    }


    //pay money


    //buy properties


    //pay rent

    public enum GameState
    {
        Active,
        Finished
    }
}