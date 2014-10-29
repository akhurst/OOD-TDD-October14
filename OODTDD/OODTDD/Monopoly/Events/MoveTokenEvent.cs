using System.Collections.Generic;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly.Events
{
    public class MoveTokenEvent : IGameEvent
    {
        private Token _token;
        private int _spaces;

        public MoveTokenEvent(Token token, int spaces)
        {
            _token = token;
            _spaces = spaces;
        }

        public IEnumerable<IGameEvent> InvokeEvent(Game game)
        {
            return game.Board.MoveToken(_token, _spaces);
        }
    }
}