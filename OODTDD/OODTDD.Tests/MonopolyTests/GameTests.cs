using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using NUnit.Framework;
using NSubstitute;
using OODTDD.Monopoly;
using OODTDD.Monopoly.PlayerStrategies;
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
        private Token wheelBarrow;
        private Token battleShip;
        private Player player1;
        private Player player2;
        private Cup doublesCup = new Cup(2);

        [TestFixtureSetUp]
        public virtual void SetUp()
        {
            this.horsey = new Token {Name = TokenType.Horsey};
            this.topHat = new Token {Name = TokenType.TopHat};
            this.wheelBarrow = new Token {Name = TokenType.Wheelbarrow};
            this.battleShip = new Token { Name = TokenType.Battleship };

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
        public void PlayerHasWonTheGameWithOver5000()
        {
            while (finishedGame.GameState != GameState.Finished)
            {
                finishedGame.TakeTurn();
            }

            Assert.GreaterOrEqual(finishedGame.Players.Max(x => x.Money), 5000);
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
        
        [Test]
        public void PlayerLandsOnLuxuryTaxAndLosesMoney()
        {
            Player player3 = new Player() { Token = wheelBarrow };
            Player player4 = new Player() { Token = battleShip };

            player3.Money = 200;
            player4.Money = 200;

            Game gameLuxury = new Game {Players = new LinkedList<Player>(new List<Player> {player3, player4})};

            List<ISquare> squares = new List<ISquare>();
            squares.Add(new GoSquare());
            foreach (var o in Enumerable.Range(1, 20))
            {
                squares.Add(new LuxuryTaxSquare());
            }

            var squareList = new LinkedList<ISquare>(squares);
            var board = new Board { Squares = squareList };
            gameLuxury.Board = board;

            var startingSquare = gameLuxury.Board.Squares.FirstOrDefault();
            foreach (var p in gameLuxury.Players)
            {
                startingSquare.AddToken(p.Token);
            }

            gameLuxury.CurrentPlayer = gameLuxury.Players.First;
            gameLuxury.Board.Squares.AddFirst(new LuxuryTaxSquare());
            gameLuxury.Board.Squares.AddFirst(new LuxuryTaxSquare());

            Cup luxuryTaxCup = Substitute.For<Cup>();
            luxuryTaxCup.Roll().Returns(2);
            luxuryTaxCup.LastValue.Returns(new List<int>() { 1, 1 });
            gameLuxury.cup = luxuryTaxCup;

            //var p = game.CurrentPlayer.Value;
            gameLuxury.TakeTurn();

            Assert.Less(player3.Money, player4.Money);
        }


        [Test]
        public void PlayerLandsOnIncomeTaxAndLosesMoney()
        {
            var p1 = new Player { Token = horsey };
            var p2 = new Player() { Token = topHat };

            p1.Money = 1000;
            p2.Money = 5000;

            var playerList = new LinkedList<Player>(new List<Player>{p1, p2});

            var game = new Game { Players = playerList, };
            game.CurrentPlayer = game.Players.First;
            
            List<ISquare> squares = new List<ISquare>();
            squares.Add(new GoSquare());
            foreach (var o in Enumerable.Range(1, 20))
            {
                squares.Add(new IncomTaxSquare());
            }

            var squareList = new LinkedList<ISquare>(squares);
            var board = new Board { Squares = squareList };
            game.Board = board;

            var startingSquare = game.Board.Squares.FirstOrDefault();
            foreach (var p in playerList)
            {
                startingSquare.AddToken(p.Token);
            }

            var rollFiveDice = Substitute.For<Cup>();
            rollFiveDice.Roll().Returns(5);
            rollFiveDice.LastValue.Returns(new List<int>() { 1, 4 });

            game.cup = rollFiveDice;
            
            game.TakeTurn();
            Assert.AreEqual(p1.Money, 800);

            game.TakeTurn();
            Assert.AreEqual(p2.Money, 4500);

        }

        [Test]
        public void PlayerBuysPropertyWhenLanding()
        {
            var p1 = new Player(new BuyPropertyAlwaysStrategy()) { Token = horsey };
            var p2 = new Player() { Token = topHat };

            p1.Money = 2000;
            p2.Money = 5000;

            var playerList = new LinkedList<Player>(new List<Player> { p1, p2 });

            var game = new Game { Players = playerList, };
            game.CurrentPlayer = game.Players.First;

            List<ISquare> squares = new List<ISquare>();
            squares.Add(new GoSquare());
            foreach (var o in Enumerable.Range(1, 40))
            {
                squares.Add(new PropertySquare("Property", PropertyGrouping.Default, 500, new List<int>{25, 50, 75, 100}));
            }

            var squareList = new LinkedList<ISquare>(squares);
            var board = new Board { Squares = squareList };
            game.Board = board;

            var startingSquare = game.Board.Squares.FirstOrDefault();
            foreach (var p in playerList)
            {
                startingSquare.AddToken(p.Token);
            }

            var rollFiveDice = Substitute.For<Cup>();
            rollFiveDice.Roll().Returns(5);
            rollFiveDice.LastValue.Returns(new List<int>() { 1, 4 });

            game.cup = rollFiveDice;

            game.TakeTurn();
            Assert.AreEqual(p1.Money, 1500);

            var propSquare = game.Board.GetTokenSquare(p1.Token) as PropertySquare;

            Assert.AreEqual(p1.Token, propSquare.OwnedBy);

            game.TakeTurn();
            Assert.AreEqual(p2.Money, 4975);
            Assert.AreEqual(p1.Token, propSquare.OwnedBy);
            Assert.AreEqual(p1.Money, 1525);

            game.TakeTurn();
            Assert.AreEqual(p1.Money, 1025);
            propSquare = game.Board.GetTokenSquare(p1.Token) as PropertySquare;
            Assert.AreEqual(p1.Token, propSquare.OwnedBy);

            game.TakeTurn();
            Assert.AreEqual(p2.Money, 4925);
            Assert.AreEqual(p1.Token, propSquare.OwnedBy);
            Assert.AreEqual(p1.Money, 1075);

            game.TakeTurn();
            Assert.AreEqual(p1.Money, 575);
            propSquare = game.Board.GetTokenSquare(p1.Token) as PropertySquare;
            Assert.AreEqual(p1.Token, propSquare.OwnedBy);

            game.TakeTurn();
            Assert.AreEqual(p2.Money, 4850);
            Assert.AreEqual(p1.Token, propSquare.OwnedBy);
            Assert.AreEqual(p1.Money, 650);

            game.TakeTurn();
            Assert.AreEqual(p1.Money, 150);
            propSquare = game.Board.GetTokenSquare(p1.Token) as PropertySquare;
            Assert.AreEqual(p1.Token, propSquare.OwnedBy);

            game.TakeTurn();
            Assert.AreEqual(p2.Money, 4750);
            Assert.AreEqual(p1.Token, propSquare.OwnedBy);
            Assert.AreEqual(p1.Money, 250);
        }

        [Test]
        public void PlayerGoesToJailOnGoToJailSquare()
        {
            var p1 = new Player { Token = horsey };
            var p2 = new Player() { Token = topHat };
            
            var playerList = new LinkedList<Player>(new List<Player> { p1, p2 });

            var game = new Game { Players = playerList, };
            game.CurrentPlayer = game.Players.First;

            List<ISquare> squares = new List<ISquare>();
            squares.Add(new GoSquare());
            foreach (var o in Enumerable.Range(1, 20))
            {
                squares.Add(new GoToJailSquare());
            }
            var jailSquare = new JailSquare();
            squares.Add(jailSquare);

            var squareList = new LinkedList<ISquare>(squares);
            var board = new Board { Squares = squareList };
            game.Board = board;

            var startingSquare = game.Board.Squares.FirstOrDefault();
            foreach (var p in playerList)
            {
                startingSquare.AddToken(p.Token);
            }

            // Rolling 5 will land on the GoToJail square
            var rollFiveDice = Substitute.For<Cup>();
            rollFiveDice.Roll().Returns(5);
            rollFiveDice.LastValue.Returns(new List<int>() { 1, 4 });

            game.cup = rollFiveDice;

            game.TakeTurn();
            Assert.AreEqual(game.Board.GetTokenSquare(horsey), game.Board.Squares.Find(jailSquare).Value);
        }
    }
}

   
