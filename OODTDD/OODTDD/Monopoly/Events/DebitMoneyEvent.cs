using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD.Monopoly.Events
{
    public class DebitMoneyEvent : IGameEvent
    {
        private Token _token;
        private int _money;

        public DebitMoneyEvent(Token token, int money)
        {
            _token = token;
            _money = money;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            var player = game.GetPlayer(_token);

            player.Money -= _money;

            return new List<IGameEvent>();
        }
    }
}
