using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Actions
{
    public class RollAction : AbstractAction
    {
        public RollAction(Player p) : base(p)
        {

        }

        public override IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            var roll = game.cup.Roll();
            _player.TimesRolledThisTurn++;

            if (game.cup.LastValue.Max() == game.cup.LastValue.Min())
            {
                _events.Add(new RolledDoubleEvent(_player));
            }
            else
            {
                _events.Add(new RolledEvent(_player));
            }
            
            _events.Add(new MoveTokenEvent(_player.Token, roll));

            return _events;

            //throw new System.NotImplementedException();
        }
    }
}