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

        public GoToJailEvent(Token token)
        {
            _token = token;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            var player = game.Players.FirstOrDefault(x => x.Token == _token);
            var _square = game.Board.Squares.FirstOrDefault(x => x is JailSquare);

            return game.Board.MoveToSquare(_token, _square);
        }
    }
}
