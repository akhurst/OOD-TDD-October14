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
        private IRandomizer randomizer;
        private Game game;

        [SetUp]
        public virtual void SetUp()
        {
            randomizer = Substitute.For<IRandomizer>();
            var cup = new Cup(2, randomizer);
            game = new Game(10, cup);
        }

        [Test]
        public void ThenPlayersCollect200Dollars()
        {
            // They will roll 10 each time, but not doubles
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(
                i => numRolls++ % 2 == 0 ? 6 : 4
                );

            for (int i = 0; i < 5; i++)
            {
                game.PlayRound();
            }

            game.IsOver.Should().BeFalse();
            game.Players.ToList().ForEach(p=>Assert.That(p.Balance, Is.EqualTo(200)));
        }

        [Test]
        public void GivenMyBalancePasses1000ThenIWinTheGame()
        {
            // They will roll 10 each time, but not doubles
            var numRolls = 0;
            randomizer.GetRandomNumber(1, 6).Returns(
                i => numRolls++ % 2 == 0 ? 6 : 4
                );

            for (int i = 0; i < 18; i++)
            {
                game.PlayRound();
            }

            game.IsOver.Should().BeTrue();
            // The first player will win because he goes first and they're all rolling 10 each time
            game.Winner.Should().Be(game.Players[0]);
        }
    }
}
