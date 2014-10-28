using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace OODTDD.Tests
{
    [TestFixture]
    public class WhenPassingGo
    {
        [Test]
        public void GivenAPlayerPassesGoThenThatPlayerIsTheWinner()
        {
            var game = new Game(10);
            Player winner = null;
            game.Board.GoSquare.PlayerPassed += (sender, args) => winner = args.Player;

            for (int i = 0; i < 20 && !game.IsOver; i++)
            {
                game.PlayRound();
            }

            game.IsOver.Should().BeTrue();
            game.Winner.Should().Be(winner);
        }
    }
}
