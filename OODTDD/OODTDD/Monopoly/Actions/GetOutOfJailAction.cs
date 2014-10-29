using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Actions
{
    public class GetOutOfJailAction : AbstractAction
    {
        public GetOutOfJailAction(Player p) : base(p)
        {
           
        }
        public override IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            _events.Add(new RemovePlayerActionsEvent(_player, _player.AvailableActions.OfType<GetOutOfJailAction>()));

            return base.InvokeAction(game);
        }
    }
}