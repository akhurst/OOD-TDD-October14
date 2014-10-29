using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Actions;
using OODTDD.Monopoly.Events;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly
{
    public class Game
    {
        public Board Board { get; set; }
        public LinkedList<Player> Players { get; set; }
        public Cup cup = new Cup(2);
        public GameState GameState;
        public LinkedListNode<Player> CurrentPlayer { get; set; }
        public IEnumerable<IWinCondition> WinConditions { get; set; } 
      
        private void InvokeEvents(IEnumerable<IGameEvent> events)
        {
            foreach (IGameEvent e in events)
            {
                var subEvents = e.InvokeEvent(this);
                TestWinConditions();
                if (GameState == GameState.Finished)
                    break;

                InvokeEvents(subEvents);
            }
        }

        private void TestWinConditions()
        {
            if (WinConditions.Any(x => x.IsWinCondition(this)))
            {
                this.GameState = GameState.Finished;
            }
        }

        public void TakeTurn()
        {
            var player = this.CurrentPlayer.Value;
            player.TimesRolledThisTurn = 0;

            player.AvailableActions.Add(new RollAction(this.CurrentPlayer.Value));

            while (player.GetAction() != null && this.CurrentPlayer.Value == player)
            {
                var action = this.CurrentPlayer.Value.GetAction();

                if (this.CurrentPlayer.Value.AvailableActions.Contains(action))
                {
                    this.CurrentPlayer.Value.AvailableActions.Remove(action);
                    InvokeEvents(action.InvokeAction(this));
                }
            }
        }
    }


    //pay money


    //buy properties


    //pay rent
}