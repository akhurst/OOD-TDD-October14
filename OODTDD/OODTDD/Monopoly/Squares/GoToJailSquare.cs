using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class GoToJailSquare : AbstractSquare
    {
        private readonly JailSquare _square;

        public GoToJailSquare(JailSquare square)
        {
            _square = square;
        }

        public override IEnumerable<IGameEvent> Land(Token token)
        {
            var events = new List<IGameEvent>();
            events.Add(new GoToJailEvent(token, _square));
            return events;
        }
    }
}