using System.Collections.Generic;
using OODTDD.Monopoly.Actions;

namespace OODTDD.Monopoly
{
    public interface IPlayerStrategy
    {
        IPlayerAction GetAction(List<IPlayerAction> availableActions);
    }
}