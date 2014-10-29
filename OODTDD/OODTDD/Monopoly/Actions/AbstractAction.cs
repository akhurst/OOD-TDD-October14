using System.Collections.Generic;
using OODTDD.Monopoly.Events;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Actions
{
    public class AbstractAction : IPlayerAction
    {
        protected Player _player;
        protected List<IGameEvent> _events = new List<IGameEvent>(); 
        public AbstractAction(Player p)
        {
            _player = p;
        }


        public virtual IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            throw new System.NotImplementedException();
        }
    }
}