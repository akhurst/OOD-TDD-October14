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
    public class WhenPassingGo
    {
      
        [Test]
        public void GivenAPlayerPassesGoThenThatPlayerReceives200Dollars()
        {
            //arrange
            var board = new Board();
            int startPosition = board.GoSquareIndex == 0 ? board.Squares.Count()-1 : board.GoSquareIndex - 1;
            var player = new Player("1", board.Squares[startPosition]);
            int previousBalance = player.TotalDollars;

            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 1 };
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);
            //act
            player.TakeTurn(new Cup(2, randomizer));

            //assert
            Assert.AreEqual(previousBalance + 200, player.TotalDollars);
        }

    }
}
