using System.Collections.Generic;
using OODTDD.Monopoly.Actions;

namespace OODTDD.Monopoly
{
    internal interface IPlayerStrategy
    {
        IPlayerAction GetAction(List<IPlayerAction> availableActions);
    }
}