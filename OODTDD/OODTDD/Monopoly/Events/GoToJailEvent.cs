using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Events
{
    public class GoToJailEvent : IGameEvent
    {
        private Token _token;
        private JailSquare _jail;

        public GoToJailEvent(Token token, JailSquare jail)
        {
            _token = token;
            _jail = jail;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            var player = game.GetPlayer(_token);

            return game.Board.MoveToSquare(_token, _jail);
        }
    }
}
