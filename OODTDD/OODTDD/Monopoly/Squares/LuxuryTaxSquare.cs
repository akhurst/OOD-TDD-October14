using System;
using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class LuxuryTaxSquare : AbstractSquare
    {
        public override IEnumerable<IGameEvent> Land(Token token)
        {
            throw new NotImplementedException();
        }
    }
}