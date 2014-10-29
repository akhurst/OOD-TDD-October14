using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OODTDD
{
    public class Board
    {
        public Board()
        {
            InitializeSquares();
        }

        private void InitializeSquares()
        {
	        Squares = SquareFactory.GetSquares(40);
        }
        public IList<Square> Squares { get; set; }

        public GoSquare GoSquare
        {
            get { return Squares[0] as GoSquare; }
        }
    }
}
