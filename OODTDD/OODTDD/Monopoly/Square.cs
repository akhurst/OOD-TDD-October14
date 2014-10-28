using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using OODTDD;

namespace OODTDD.Monopoly
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

    public interface ISquare
    {
        IEnumerable<Token> Tokens { get; set; }
        bool HasToken(Token token);
        void AddToken(Token token);
        void RemoveToken(Token token);

        IEnumerable<IGameEvent> Pass(Token token);
        IEnumerable<IGameEvent> Land(Token token);

    }

    public interface IGameEvent
    {
        void InvokeEvent(Game game);
    }

    public class GenericSquare : AbstractSquare
    {
        
    }

    public class GoSquare : AbstractSquare
    {
        public override IEnumerable<IGameEvent> Pass(Token token)
        {
            var events = new List<IGameEvent>();
            events.Add(new GetMoneyEvent(token, 200));

            return events;
        }
    }

    public class GetMoneyEvent : IGameEvent
    {
        private Token _token;
        private int _money;

        public GetMoneyEvent(Token token, int money)
        {
            _token = token;
            _money = money;
        }

        public void InvokeEvent(Game game)
        {
            var player = game.Players.FirstOrDefault(x => x.Token == _token);

            player.Money += _money;
        }
    }

    public class WinCondition : IGameEvent
    {
        private Token _winningPlayer;
        public WinCondition(Token token)
        {
            _winningPlayer = token;
        }

        public void InvokeEvent(Game game)
        {
            game.GameState = GameState.Finished;
        }
    }
}