using System.Collections.Generic;
using System.Linq;
using OODTDD;

namespace OODTDD.Monopoly
{
    public class Square
    {
        private List<Token> _tokens = new List<Token>();

        public IEnumerable<Token> Tokens
        {
            get { return _tokens; }
            set { _tokens = value.ToList(); }
        }

        public void AddToken(Token t)
        {
            _tokens.Add(t);
        }

        public bool HasToken(Token token)
        {
            return this._tokens.Contains(token);
        }

        public void RemoveToken(Token token)
        {
            _tokens.Remove(token);
        }
    }
}