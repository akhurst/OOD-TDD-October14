using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Events
{
    public class GetMoneyEvent : IGameEvent
    {
        private Token _token;
        private int _money;

        public GetMoneyEvent(Token token, int money)
        {
            _token = token;
            _money = money;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            var player = game.GetPlayer(_token);

            player.Money += _money;

            return new List<IGameEvent>();
        }
    }
}