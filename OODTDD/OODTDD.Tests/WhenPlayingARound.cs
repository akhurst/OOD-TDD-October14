using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OODTDD;

namespace OODTDD.Tests
{
    [TestFixture]
    public class WhenPlayingARound
    {
        [Test]
        public void GivenEachPlayerRolls2DiceThenEachPlayerMovesTheNumberOfSpacesShownOnTheDice()
        {
            var board = new Board();
            var player = new Player("allen", board.GoSquare);
            var cup = new Cup(2);

            player.TakeTurn(cup);

            Assert.That(()=>player.CurrentSquare, Is.EqualTo(board.Squares[cup.LastValue]));
        }

        [Test]
        public void GivenIHaveFourPlayersThenEachPlayerGetsATurn()
        {
            var game = new Game(2);

            var startingPositions = game.Players.ToDictionary(player => player, player => player.CurrentSquare);

            game.PlayRound();

            foreach (var player in game.Players)
            {
                Player current = player;
                Assert.That(() => current.CurrentSquare, Is.Not.EqualTo(startingPositions[player]));
            }
        }
    }
}
