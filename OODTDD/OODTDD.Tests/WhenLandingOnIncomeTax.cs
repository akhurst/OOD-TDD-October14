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
	public class WhenLandingOnIncomeTax
	{
		private Player player;
		private Cup cup;

		[SetUp]
		public void SetUp()
		{
			var randomizer = Substitute.For<IRandomizer>();
			var board = new Board();
			player = new Player("Joe", board.Squares[1]);
			cup = new Cup(2, randomizer);

			// They will roll 3 each time, but not doubles
			var numRolls = 0;
			randomizer.GetRandomNumber(1, 6).Returns(
				i => numRolls++ % 2 == 0 ? 2 : 1
				);
		}

		[Test]
		public void ThenThePlayerIsDebitedIncomeTax()
		{
			player.TakeTurn(cup);
			player.Balance.Should().Be(1800);
		}

		[Test]
		public void ThenThePlayerIsDebited10PercentIfLessThan2000Dollars()
		{
			player.Debit(1000);
			player.TakeTurn(cup);
			player.Balance.Should().Be(900);
		}
	}
}
