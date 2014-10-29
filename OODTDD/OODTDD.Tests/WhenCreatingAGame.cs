using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using OODTDD;

namespace OODTDD.Tests
{
    [TestFixture]
    public class WhenCreatingAGame
    {
        [Test]
        public void ThenValidPlayersAreCreated()
        {
            var game = new Game(2);

            game.Players.Should().HaveCount(2);
            game.Players.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void ThenThePlayersHaveUniqueTokens()
        {
            var game = new Game(2);

            Assert.That(game.Players.Select(p => p.Token).Distinct().Count(), Is.EqualTo(2));
        }

        [Test]
        public void ThenThereIsABoardWith40Squares()
        {
            var game = new Game(2);

            game.Board.Should().NotBeNull();
            game.Board.Squares.Should().HaveCount(40);
            game.Board.Squares.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void GivenIHaveTooFewPlayersThenIGetAnError()
        {
            Assert.Throws<ArgumentException>(()=>new Game(1));
        }

        [Test]
        public void GivenIHaveTooManyPlayersThenIGetAnError()
        {
            Assert.Throws<ArgumentException>(() => new Game(11));
        }

        [Test]
        public void ThenTheGameHasTwoDice()
        {
            var game = new Game(4);

            game.Cup.NumDie.Should().Be(2);
            game.Cup.Dice.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void ThenEveryPlayerStartsOnTheFirstSquare()
        {
            var game = new Game(4);

            Assert.IsFalse(game.Players.Any(p => p.CurrentSquare == null));
            Assert.That(game.Players.Select(p => p.CurrentSquare).Distinct().Count(), Is.EqualTo(1));

        }

        [Test]
        public void ThenThereIsNoWinner()
        {
            var game = new Game(4);

            game.Winner.Should().BeNull();
            game.IsOver.Should().BeFalse();
        }
    }
}
