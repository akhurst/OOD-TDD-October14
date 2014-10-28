using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using NUnit.Framework;
using OODTDD.Monopoly;

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

        [TestFixtureSetUp]
        public virtual void SetUp()
        {
            this.horsey = new Token {Name = TokenType.Horsey};
            this.topHat = new Token {Name = TokenType.TopHat};

            this.player1 = new Player {Token = horsey};
            this.player2 = new Player() {Token = topHat};

            game = MonopolyGame.GetGame(new List<Player>{player1, player2});

            finishedGame = MonopolyGame.GetGame(new List<Player> {player1, player2});
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
            var startSquare = game.Board
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

        [Test]
        public void StartingSquareExistsOnBoard()
        {
            Square square = game.Board.GetStartingSquare();
            Assert.IsNotNull(square);

            Assert.IsInstanceOf<Square>(square);
        }

        public void CurrentPlayerRollsAndMoves()
        {

            game.RollAndMove(player1);

        }

        public void GameStateIsFinished()
        {

            //while (true)
            //{
            //var nextRound = game.TakeRound();

            while (game.GameState != GameState.Finished)
            {
                foreach (Player p in game.Players)
                {
                    game.RollAndMove(p);
                }
            }


            Assert.Equals(finishedGame.GameState, GameState.Finished);
        }


    }

   
}