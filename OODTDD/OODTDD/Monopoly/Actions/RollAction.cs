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

            return base.InvokeAction(game);

            //throw new System.NotImplementedException();
        }
    }

    public class RollFromJailAction : AbstractAction
    {
        public RollFromJailAction(Player p)
            : base(p)
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

            return base.InvokeAction(game);

            //throw new System.NotImplementedException();
        }
    }

    public class PayToGetOutOfJailAction : AbstractAction
    {
        public PayToGetOutOfJailAction(Player p)
            : base(p)
        {

        }

        public override IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            _events.Add(new DebitMoneyEvent(_player.Token, 50));
            _events.Add(new AddPlayerActionsEvent(_player, new List<IPlayerAction>(){ new RollAction(_player) }));
            

            return base.InvokeAction(game);

            //throw new System.NotImplementedException();
        }
    }
}