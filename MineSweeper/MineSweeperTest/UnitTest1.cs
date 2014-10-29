using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeper.Business;

namespace MineSweeperTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddFlagToMine()
        {
            var mineSweeper = MineSweeperGame.Instance;

            var square = mineSweeper.Squares.FirstOrDefault().Value;

            Assert.IsFalse(square.IsFlagged);

            square.ToggleFlag();

            Assert.IsTrue(square.IsFlagged);
        }

        public void GenerateMinesWithUniquePlaces()
        {

            foreach (var num in Enumerable.Range(1, 1000))
            {
                
            }
        }
    }
}
