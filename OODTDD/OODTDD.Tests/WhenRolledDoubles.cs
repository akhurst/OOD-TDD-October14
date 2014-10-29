using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace OODTDD.Tests
{
    [TestFixture]
    public class WhenRolledDoubles
    {
        [Test]
        public void GivenNot3PreviousDoublesRolled_PlayerGetsAnotherTurn()
        {
            var randomizer = Substitute.For<IRandomizer>();
            var board = new Board();
            var player = new Player("1", board.GoSquare);

            var rolls = new []{6, 6, 5, 2};
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);

            player.TakeTurn(new Cup(2,randomizer));

            player.CurrentSquare.Should().Be(board.Squares[19]);
        }
        [Test]
        public void Given3PreviousDoublesRolled_PlayerDoesNotGetAnotherTurn()
        {
            var randomizer = Substitute.For<IRandomizer>();
            var board = new Board();
            var player = new Player("1", board.GoSquare);

            var rolls = new[] { 6, 6, 2, 2, 3, 3, 5, 2 };
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);

            player.TakeTurn(new Cup(2, randomizer));

            player.CurrentSquare.Should().Be(board.Squares[22]);
        }

    }
}
