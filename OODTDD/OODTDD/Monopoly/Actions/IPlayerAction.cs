using System.Collections.Generic;
using OODTDD.Monopoly.Events;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Actions
{
    public interface IPlayerAction
    {
        IEnumerable<IGameEvent> InvokeAction(Game game);
    }
}