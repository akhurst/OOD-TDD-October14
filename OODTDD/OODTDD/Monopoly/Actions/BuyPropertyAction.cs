using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Actions;
using OODTDD.Monopoly.Events;
using OODTDD.Monopoly.Extensions;

namespace OODTDD.Monopoly.Squares
{
    public class BuyPropertyAction : AbstractAction
    {
        private PropertySquare _square;

        public BuyPropertyAction(Player p, PropertySquare square)
            : base(p)
        {
            _square = square;
        }

        public override IEnumerable<IGameEvent> InvokeAction(Game game)
        {
            int tierIndex =
                game.Board.Squares.OfType<PropertySquare>().Count(x => x.OwnedBy == game.CurrentPlayer.Value.Token);
            return _square.Purchase(_player, tierIndex);
        }
    }
}