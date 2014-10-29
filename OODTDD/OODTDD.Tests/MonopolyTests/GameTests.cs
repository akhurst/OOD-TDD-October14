using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using NUnit.Framework;
using NSubstitute;
using OODTDD.Monopoly;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;
        private Game finishedGame;
        private Token horsey;
        private Token topHat;
        private Player player1;
        private Player player2;
        private Cup doublesCup = new Cup(2);

        [TestFixtureSetUp]
        public virtual void SetUp()
        {
            this.horsey = new Token {Name = TokenType.Horsey};
            this.topHat = new Token {Name = TokenType.TopHat};

            this.player1 = new Player {Token = horsey};
            this.player2 = new Player() {Token = topHat};

            game = MonopolyGame.GetGame(new List<Player>{player1, player2});

            finishedGame = MonopolyGame.GetGame(new List<Player> {player1, player2});

            doublesCup = Substitute.For<Cup>();
        }

        [Test]
        public void CreateGameWith40Squares()
        {
            Assert.AreEqual(game.Board.Squares.Count(), 40);
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

            var newGame = MonopolyGame.GetGame(new List<Player>{p, p2 });

            IEnumerable<Token> sameTokens = newGame.Players.Select(t => t.Token);

            Assert.False(sameTokens.Distinct().Count() == sameTokens.Count());
            
        }

        [Test]
        public void TooFewOrTooManyPlayersThrowException()
        {
            Player p = new Player{ Token = new Token()};
            Assert.Throws<ArgumentException>(() => MonopolyGame.GetGame(new List<Player>{ p }));
            Assert.Throws<ArgumentException>(() => MonopolyGame.GetGame(new List<Player>{ p,p,p,p,p,p,p,p,p,p,p,p,p}));
        }
        [Test]
        public void TwoPlayersTakeTheirMoves()
        {
            var startSquare = game.Board.GetStartingSquare();
            
            game.TakeTurn();
            game.TakeTurn();

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
            Assert.AreEqual(game.Board.Squares.Count(), 40);

            Assert.IsNotNull(game.Board.Squares.SingleOrDefault(x => x.HasToken(horsey)));
        }

        [Test]
        public void StartingSquareExistsOnBoard()
        {
            ISquare square = game.Board.GetStartingSquare();
            Assert.IsNotNull(square);

            Assert.IsInstanceOf<ISquare>(square);
        }

        [Test]
        public void PlayerGotMoney()
        {

            while (finishedGame.Players.Any(x => x.Money == 0))
            {
                finishedGame.TakeTurn();
            }

            Assert.AreNotEqual(finishedGame.GameState, GameState.Finished);
        }

        [Test]
        public void PlayersMoneyIncreasesWhenPassingGo()
        {
            while (finishedGame.GameState != GameState.Finished)
            {
                finishedGame.TakeTurn();
            }

            Assert.GreaterOrEqual(finishedGame.Players.Max(x => x.Money), 1000);
        }

        [Test]
        public void PlayerRollsDoublesAndGetsAnotherTurn()
        {
            doublesCup.Roll().Returns(12);
            doublesCup.LastValue.Returns(new List<int>(){6,6});
            
            game.cup = doublesCup;
            var p = game.CurrentPlayer.Value;

            //game.Board.Squares.FirstOrDefault(x => x.HasToken(p.Token));

            game.TakeTurn();


        }

            
    }

        
}

   
