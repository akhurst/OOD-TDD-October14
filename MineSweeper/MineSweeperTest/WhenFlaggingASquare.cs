using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MineSweeper.Business;
using NUnit.Framework;

namespace MineSweeperTest
{
    [TestFixture]
    public class WhenFlaggingASquare
    {
        [Test]
        public void GivenTheSquareIsCoveredThenTheSquareIsFlagged()
        {
            var square = new Square(false);
            square.Neighbors = SquareTestHelpers.GenerateSquares(3);

            square.ToggleFlag();

            Assert.That(square.IsFlagged, Is.True);
        }

        [Test]
        public void GivenTheSquareIsUncoveredThenNothingHappens()
        {
            
        }


    }
}
