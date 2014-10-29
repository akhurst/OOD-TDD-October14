using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class GoSquare : AbstractSquare
    {
        public override IEnumerable<IGameEvent> Pass(Token token)
        {
            var events = new List<IGameEvent>();
            events.Add(new GetMoneyEvent(token, 200));

            return events;
        }
    }
}