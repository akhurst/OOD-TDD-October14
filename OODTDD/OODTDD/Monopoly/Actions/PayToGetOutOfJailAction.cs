using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Actions
{
    public class PayToGetOutOfJailAction : GetOutOfJailAction
    {
        public PayToGetOutOfJailAction(Player p)
            : base(p)
        {

        }

        public override IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            _events.Add(new DebitMoneyEvent(_player.Token, 50));
            _events.Add(new GetOutOfJailEvent(_player));
            _events.Add(new AddPlayerActionsEvent(_player, new List<IPlayerAction>(){ new RollAction(_player) }));

            return base.InvokeAction(game);
        }
    }
}