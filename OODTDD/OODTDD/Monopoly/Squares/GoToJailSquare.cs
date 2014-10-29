using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class GoToJailSquare : AbstractSquare
    {
        public override IEnumerable<IGameEvent> Land(Token token)
        {
            var events = new List<IGameEvent>();
            events.Add(new GoToJailEvent(token));
            return events;
        }
    }
}