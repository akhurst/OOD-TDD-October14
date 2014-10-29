using System.Collections.Generic;

namespace OODTDD.Monopoly.Events
{
    public class GetOutOfJailEvent : IGameEvent
    {
        private Player _player;

        public GetOutOfJailEvent(Player player)
        {
            _player = player;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            _player.TurnsPlayerInJail = 0;
            _player.PlayerInJail = false;

            return new List<IGameEvent>();
        }
    }
}