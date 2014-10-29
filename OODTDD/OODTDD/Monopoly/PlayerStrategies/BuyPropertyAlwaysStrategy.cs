using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Actions;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.PlayerStrategies
{
    public class BuyPropertyAlwaysStrategy : IPlayerStrategy
    {
        public IPlayerAction GetAction(List<IPlayerAction> availableActions)
        {
            return availableActions.FirstOrDefault(x => x is BuyPropertyAction) ?? availableActions.FirstOrDefault();
        }
    }
}