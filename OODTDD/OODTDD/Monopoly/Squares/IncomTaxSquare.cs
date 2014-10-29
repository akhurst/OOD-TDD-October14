using System;
using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class IncomTaxSquare : AbstractSquare
    {
        public override IEnumerable<IGameEvent> Land(Token token)
        {
            var events = new List<IGameEvent>();
            events.Add(new PayIncomeTaxEvent(token));

            return events;
        }
    }

 
}