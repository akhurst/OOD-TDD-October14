using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class ChargeRentEvent : IGameEvent
    {
        private Token _token;
        private PropertySquare _square;
        public ChargeRentEvent(PropertySquare propertySquare, Token token)
        {
            _square = propertySquare;
            _token = token;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            var player = game.GetPlayer(_token);

            return _square.DeductRent(player);
        }
    }
}