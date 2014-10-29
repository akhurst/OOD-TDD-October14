using System.Collections.Generic;
using OODTDD.Monopoly.Actions;

namespace OODTDD.Monopoly.Events
{
    public class AddPlayerActionsEvent : IGameEvent
    {
        private Player _player;
        private IEnumerable<IPlayerAction> _actions;

        public AddPlayerActionsEvent(Player player, IEnumerable<IPlayerAction> actions)
        {
            _player = player;
            _actions = actions;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            _player.AvailableActions.AddRange(_actions);

            return new List<IGameEvent>();
        }
    }
}