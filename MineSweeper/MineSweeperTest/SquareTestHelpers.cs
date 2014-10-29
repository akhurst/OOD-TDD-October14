using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MineSweeper.Business;

namespace MineSweeperTest
{
    public static class SquareTestHelpers
    {
        public static List<Square> GenerateSquares(int number)
        {
            var squares = new List<Square>();
            for (int i = 0; i < number; i++)
            {
                var square = new Square(false);
                square.Neighbors = new List<Square>();
                squares.Add(square);
            }
            return squares;
        }
    }
}
