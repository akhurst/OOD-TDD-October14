using System.Collections.Generic;
using System.Linq;
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
                return new List<IGameEvent> { new GoToJailEvent(_player.Token, game.Board.Squares.OfType<JailSquare>().FirstOrDefault()) };
            }

            return new List<IGameEvent>{ new AddPlayerActionsEvent(_player, new List<IPlayerAction>{ new RollAction(_player) })};
        }
    }
}