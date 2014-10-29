using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public abstract class AbstractSquare : ISquare
    {
        private List<Token> _tokens = new List<Token>();

        public IEnumerable<Token> Tokens
        {
            get { return _tokens; }
            set { _tokens = value.ToList(); }
        }

        public void AddToken(Token token)
        {
            _tokens.Add(token);
        }

        public bool HasToken(Token token)
        {
            return this._tokens.Contains(token);
        }

        public void RemoveToken(Token token)
        {
            _tokens.Remove(token);
        }

        public virtual IEnumerable<IGameEvent> Pass(Token token)
        {
            return new List<IGameEvent>();
        }

        public virtual IEnumerable<IGameEvent> Land(Token token)
        {
            return new List<IGameEvent>();
        }
    }
}