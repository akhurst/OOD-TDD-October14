using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Actions
{
    public class RollFromJailAction : GetOutOfJailAction
    {
        public RollFromJailAction(Player p)
            : base(p)
        {

        }

        public override IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            var roll = game.cup.Roll();
           

            if (game.cup.LastValue.Max() == game.cup.LastValue.Min())
            {
                _events.Add(new GetOutOfJailEvent(_player));
            }
            else
            {
                _player.TurnsPlayerInJail++;
                if (_player.TurnsPlayerInJail >= 4)
                    _events.Add(new GetOutOfJailEvent(_player));
            }

            _events.Add(new AddPlayerActionsEvent(_player, new List<IPlayerAction>{new EndTurnAction(_player)}));
            
            return base.InvokeAction(game);

            //throw new System.NotImplementedException();
        }
    }
}