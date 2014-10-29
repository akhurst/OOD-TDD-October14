using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MineSweeper.Business;
using NUnit.Framework;

namespace MineSweeperTest
{
    [TestFixture]
    public class WhenUncoveringASquare
    {
        [Test]
        public void GivenTheSquareHasNoMinesAsNeighborsThenAllMyNeighborsAreExposed()
        {
            var square = new Square(false);

            square.Neighbors = SquareTestHelpers.GenerateSquares(3);
            square.Uncover();

            square.Neighbors.ForEach(s=>Assert.That(s.IsCovered, Is.False));
        }

        [Test]
        public void GivenTheSquareIsAMineThenTheGameIsOver()
        {
            var game = MineSweeperGame.Instance;
            game.Initialize(10,10,100);
            int minePosition=-1;
            for (var i=0;i< game.Squares.Values.Count;i++)
            {
                if (game.Squares[i].IsMine)
                {
                    minePosition = i;
                    break;
                }
            }

            Assert.That(minePosition, Is.GreaterThan(-1));

            game.Uncover(minePosition);

            Assert.That(game.GameOver, Is.True);
        }

        [Test]
        public void GivenTheSquareIsFlaggedThenNothingHappens()
        {

			var square = new Square(false);
			square.Neighbors = SquareTestHelpers.GenerateSquares(3);
			square.ToggleFlag();
			square.Uncover();


			Assert.That(square.IsCovered, Is.True);
        }
    }
}
