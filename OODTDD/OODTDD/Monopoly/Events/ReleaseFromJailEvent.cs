using System.Collections.Generic;

namespace OODTDD.Monopoly.Events
{
    public class ReleaseFromJailEvent : IGameEvent
    {
        private readonly Player _player;

        public ReleaseFromJailEvent(Player player)
        {
            _player = player;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            _player.PlayerInJail = false;
            _player.TurnsPlayerInJail = 0;

            return new List<IGameEvent>();
        }
    }
}