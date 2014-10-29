using System.Collections.Generic;
using OODTDD.Monopoly.Actions;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Events
{
    public class RolledEvent : IGameEvent
    {
        private Player _player;
        public RolledEvent(Player player)
        {
            _player = player;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {

            return new List<IGameEvent>
            {
                new AddPlayerActionsEvent(_player, new List<IPlayerAction> {new EndTurnAction(_player)})
            };
        }
    }
}