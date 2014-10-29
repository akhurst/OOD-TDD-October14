using System;
using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class LuxuryTaxSquare : AbstractSquare
    {
        public override IEnumerable<IGameEvent> Land(Token token)
        {
            var events = new List<IGameEvent>();
            events.Add(new DebitMoneyEvent(token, 75));

            return events;
        }
    }
}