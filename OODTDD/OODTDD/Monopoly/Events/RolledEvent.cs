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
            _player.AvailableActions.Add(new EndTurnAction(_player));

            return new List<IGameEvent>();
        }
    }
}