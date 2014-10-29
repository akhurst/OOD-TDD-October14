using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Actions;

namespace OODTDD.Monopoly.Events
{
    public class RemovePlayerActionsEvent : IGameEvent
    {
        private Player _player;
        private IEnumerable<IPlayerAction> _actions;

        public RemovePlayerActionsEvent(Player player, IEnumerable<IPlayerAction> actions)
        {
            _player = player;
            _actions = actions;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            _player.AvailableActions.RemoveAll(x => _actions.Contains(x));

            return new List<IGameEvent>();
        }
    }
}