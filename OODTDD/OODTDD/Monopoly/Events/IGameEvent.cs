using System.Collections.Generic;

namespace OODTDD.Monopoly.Events
{
    public interface IGameEvent
    {
        IEnumerable<IGameEvent> InvokeEvent(Game game);
    }
}