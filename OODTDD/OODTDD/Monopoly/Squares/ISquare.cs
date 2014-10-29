using System.Collections.Generic;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public interface ISquare
    {
        IEnumerable<Token> Tokens { get; set; }
        bool HasToken(Token token);
        void AddToken(Token token);
        void RemoveToken(Token token);

        IEnumerable<IGameEvent> Pass(Token token);
        IEnumerable<IGameEvent> Land(Token token);

    }
}