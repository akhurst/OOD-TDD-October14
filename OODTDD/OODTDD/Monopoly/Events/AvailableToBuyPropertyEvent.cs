using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class AvailableToBuyPropertyEvent : IGameEvent
    {
        private Token _token;
        private PropertySquare _square;
        public AvailableToBuyPropertyEvent(PropertySquare propertySquare, Token token)
        {
            _square = propertySquare;
            _token = token;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            var player = game.GetPlayer(_token);
            game.CurrentPlayer.Value.AvailableActions.Add(new BuyPropertyAction(player, _square));

            return new List<IGameEvent>();
        }
    }
}