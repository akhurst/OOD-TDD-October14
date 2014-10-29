using System.Collections.Generic;
using OODTDD.Monopoly.Actions;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Events
{
    public class RolledDoubleEvent : IGameEvent
    {
        private Player _player;
        public RolledDoubleEvent(Player player)
        {
            _player = player;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            if (_player.TimesRolledThisTurn == 3)
            {
                return new List<IGameEvent>();
            }

            _player.AvailableActions.Add(new RollAction(_player));

            return new List<IGameEvent>();
        }
    }
}