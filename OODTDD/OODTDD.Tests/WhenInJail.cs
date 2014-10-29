using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace OODTDD.Tests
{
    [TestFixture]
    public class WhenInJail
    {
        [Test]
        public void AndTakingTurn_IfRolledDoubles_Moves()
        {
            var board = new Board();
            var player = new Player("1", board.Squares[board.JailSquareIndex]);
            player.IsInJail = true;
            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 2, 3,1};
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);

            player.TakeTurn(new Cup(2, randomizer));

            Assert.IsFalse(player.IsInJail);
            Assert.AreNotEqual(board.Squares[board.JailSquareIndex], player.CurrentSquare);
        }

        [Test]
        public void AndTakingTurn_IfNotRolledDoubles_StayPut()
        {
            var board = new Board();
            var player = new Player("1", board.Squares[board.JailSquareIndex]);
            player.IsInJail = true;
            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 1 };
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);

            player.TakeTurn(new Cup(2, randomizer));

            Assert.IsTrue(player.IsInJail);
            Assert.AreEqual(board.Squares[board.JailSquareIndex], player.CurrentSquare);
        }
        [Test]
        public void AndTakingTwoTurns_MustPay50DollarsIfNotRollingDoubles()
        {
            var board = new Board();
            var player = new Player("1", board.Squares[board.JailSquareIndex]);
            player.IsInJail = true;
            player.Credit(100);
            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 1, 3, 4, 5, 6 };
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);

            
            player.TakeTurn(new Cup(2, randomizer));
            player.TakeTurn(new Cup(2, randomizer));
            player.TakeTurn(new Cup(2, randomizer));

            Assert.IsFalse(player.IsInJail);
            Assert.AreEqual(50, player.TotalDollars);
        }
        [Test]
        public void AndTakingTwoTurns_MustNotPay50DollarsIfRollingDoubles()
        {
            var board = new Board();
            var player = new Player("1", board.Squares[board.JailSquareIndex]);
            player.IsInJail = true;
            player.Credit(100);
            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 1, 3, 4, 6, 6 };
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);


            player.TakeTurn(new Cup(2, randomizer));
            player.TakeTurn(new Cup(2, randomizer));
            player.TakeTurn(new Cup(2, randomizer));

            Assert.IsFalse(player.IsInJail);
            Assert.AreEqual(100, player.TotalDollars);
        }

        
    }
}
