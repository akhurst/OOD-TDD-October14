using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace OODTDD.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        private Token horsey;
        private Token topHat;
        private Player player1;
        private Player player2;

        [TestFixtureSetUp]
        public virtual void SetUp()
        {
            this.horsey = new Token {Name = "Horsey"};
            this.topHat = new Token {Name = "TopHat"};

            this.player1 = new Player {Token = horsey};
            this.player2 = new Player() {Token = topHat};

            game = Monopoly.GetGame(new List<Player>{player1, player2});
        }

        [Test]
        public void CreateGameWith36Squares()
        {
            Assert.AreEqual(game.Board.Squares.Count(), 36);
        }

        [Test]
        public void CreateGameWith2Players()
        {
            Assert.AreEqual(game.Players.Count(), 2);
        }

        [Test]
        public void CreateGameWherePlayersHaveUniqueTokens()
        {
            IEnumerable<Token> tokens = game.Players.Select(t => t.Token);
            Assert.True(tokens.Distinct().Count() == tokens.Count());

            Player p = new Player{ Token = horsey };
            Player p2 = new Player {Token = horsey};

            var newGame = Monopoly.GetGame(new List<Player>{p, p2 });

            IEnumerable<Token> sameTokens = newGame.Players.Select(t => t.Token);

            Assert.False(sameTokens.Distinct().Count() == sameTokens.Count());
            
        }

        [Test]
        public void TooFewOrTooManyPlayersThrowException()
        {
            Player p = new Player{ Token = new Token()};
            Assert.Throws<Exception>(() => Monopoly.GetGame(new List<Player>{ p }));
            Assert.Throws<Exception>(() => Monopoly.GetGame(new List<Player>{ p,p,p,p,p,p,p,p,p,p,p,p,p}));
        }
        [Test]
        public void TwoPlayersTakeTheirMoves()
        {
            var startSquare = game.Board.Squares.FirstOrDefault(x => x.HasToken(player1.Token));
            game.RollAndMove(player1);
            //game.EndTurn(player1);
            game.RollAndMove(player2);
            //game.EndTurn(player2);
            //Finds the square that has a specified token
            var square = game.Board.Squares.FirstOrDefault(x => x.HasToken(player1.Token));
            var squareList = game.Board.Squares.ToList();
            Assert.Greater(squareList.IndexOf(square), squareList.IndexOf(startSquare));

            var square2 = game.Board.Squares.FirstOrDefault(x => x.HasToken(player1.Token));
            var squareList2 = game.Board.Squares.ToList();
            Assert.Greater(squareList.IndexOf(square2), squareList.IndexOf(startSquare));

        }

        [Test]
        public void TokenExistsOnOneAndOnlyOneSquare()
        {
            Assert.AreEqual(game.Board.Squares.Count(), 36);

            Assert.IsNotNull(game.Board.Squares.SingleOrDefault(x => x.HasToken(horsey)));
        }
    }

    public class Token
    {
        public string Name { get; set; }
    }

    public class Monopoly
    {
        public static Game GetGame(IEnumerable<Player> players)
        {
            var enumerable = players as IList<Player> ?? players.ToList();
            if (enumerable.Count() < 2 || enumerable.Count() > 10)
            {
                throw new Exception("Too many or few players");
            }

            var game = new Game {Players = enumerable};

            var board = new Board {Squares = Enumerable.Range(1, 36).Select(x => new Square()).ToList()};

            game.Board = board;

            var startingSquare = game.Board.Squares.FirstOrDefault();
            foreach (var p in enumerable)
            {
                startingSquare.AddToken(p.Token);
            }

            game.Board = board;

            return game;
        }
    }

    public class Game
    {
        public Board Board { get; set; }
        public IEnumerable<Player> Players { get; set; }
        Cup cup = new Cup(2);
        //public void RollDice(Player p)
        //{
        //    //random roll

        //    MovePlayer(int roll);

        //}
        

        public void MoveToken(Token token, int spaces)
        {
            var startQuare = this.Board.Squares.FirstOrDefault(x => x.HasToken(token));
            int indexOf = this.Board.Squares.IndexOf(startQuare);

            startQuare.RemoveToken(token);

            var endSquare = this.Board.Squares[indexOf + spaces];
            endSquare.AddToken(token);
        }

        public void RollAndMove(Player player1)
        {
            this.MoveToken(player1.Token, cup.Roll());
        }
    }

    public class Player
    {
        public Token Token { get; set; }
    }

    public class Board
    {
        public List<Square> Squares { get; set; }
    }

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