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
	public class WhenLandingOnLuxuryTax
	{
		[Test]
		public void ThenThePlayerIsDebited75Dollars()
		{
			var randomizer = Substitute.For<IRandomizer>();
			var board = new Board();
			var player = new Player("Joe", board.Squares[34]);
			var cup = new Cup(2, randomizer);

			// They will roll 3 each time, but not doubles
			var numRolls = 0;
			randomizer.GetRandomNumber(1, 6).Returns(
				i => numRolls++ % 2 == 0 ? 2 : 1
				);


			player.TakeTurn(cup);

			player.Balance.Should().Be(1925);
		}
	}
}
