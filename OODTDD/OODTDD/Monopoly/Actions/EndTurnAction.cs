using System.Collections.Generic;
using OODTDD.Monopoly.Events;
using OODTDD.Monopoly.Extensions;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Actions
{
    public class EndTurnAction : AbstractAction
    {
        public EndTurnAction(Player p) : base(p)
        {
            
        }

        public override IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            game.CurrentPlayer = game.CurrentPlayer.CircularNext();

            return _events;
        }
    }
}