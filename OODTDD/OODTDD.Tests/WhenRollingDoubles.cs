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
    public class WhenRollingDoubles
    {
        private IRandomizer randomizer;
        private Board board;
        private Player player;
        [SetUp]
        public virtual void SetUp()
        {
            randomizer = Substitute.For<IRandomizer>();
            board = new Board();
            player = new Player("allen", board.GoSquare);
        }

        [Test]
        public void GivenIHaveNotRolledDoublesThenIGetAnotherTurn()
        {
            var rolls = new[] {6,6,5,2};
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i=>rolls[numRolls++]);

            player.TakeTurn(new Cup(2,randomizer));

            player.CurrentSquare.Should().Be(board.Squares[19]);
        }

        [Test]
        public void GivenIHaveRolledDoublesTwiceThenICannotGetAFourthTurn()
        {
            randomizer.GetRandomNumber(1, 6).Returns(5);

            player.TakeTurn(new Cup(2, randomizer));

            player.CurrentSquare.Should().Be(board.Squares[30]);
        }

        [Test]
        public void GivenIHaveRolledDoublesOnAPreviousTurnThenIAmNotPunishedOnMyNextTurn()
        {
            randomizer.GetRandomNumber(1, 6).Returns(2);

            var cup = new Cup(2, randomizer);
            player.TakeTurn(cup);
            player.TakeTurn(cup);

            player.CurrentSquare.Should().Be(board.Squares[24]);
        }
    }
}
