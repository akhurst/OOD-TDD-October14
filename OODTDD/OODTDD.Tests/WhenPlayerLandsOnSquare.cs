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
    class WhenPlayerLandsOnSquare
    {
        [Test]
        public void GivenPlayerLandsOnLuxuryTaxPlayerIsDebited75Dollars()
        {
            var board = new Board();
            var player = new Player("1", board.Squares[34]);
            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 1};
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);
            int playerPreviousTotal = player.TotalDollars;
            player.TakeTurn(new Cup(2,randomizer));

            Assert.AreEqual(playerPreviousTotal - 75, player.TotalDollars);
        }

        [Test]
        public void GivenPlayerLandsOnIncomeTaxPlayerIsDebited10Percent()
        {
            var board = new Board();
            var player = new Player("1", board.Squares[1]);
            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 1 };
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);
            player.Credit(200);
            player.TakeTurn(new Cup(2, randomizer));

            Assert.AreEqual(180, player.TotalDollars);
        }

        [Test]
        public void GivenPlayerLandsOnIncomeTaxAndIsRich_PlayerIsDebited200Dollars()
        {
            var board = new Board();
            var player = new Player("1", board.Squares[1]);
            var randomizer = Substitute.For<IRandomizer>();
            var rolls = new[] { 2, 1 };
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(i => rolls[numRolls++]);
            player.Credit(3000);
            player.TakeTurn(new Cup(2, randomizer));

            Assert.AreEqual(2800, player.TotalDollars);
        }
    }
}
