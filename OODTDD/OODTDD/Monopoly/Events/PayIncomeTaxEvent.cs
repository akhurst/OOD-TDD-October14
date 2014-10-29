using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Events
{
        public class PayIncomeTaxEvent : IGameEvent
        {
            private Token _token;

            public PayIncomeTaxEvent(Token token)
            {
                _token = token;
            }

            public IEnumerable<IGameEvent> InvokeEvent(Game game)
            {
                var player = game.Players.FirstOrDefault(x => x.Token == _token);

                if (player.Money > 2000)
                {
                    player.Money -= (int)(player.Money * .1);
                }
                else
                {
                    player.Money -= 200;
                }

                return new List<IGameEvent>();
            }
        }
}