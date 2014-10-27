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
            Squares = new List<Square>();

            for (int i = 0; i < 36; i++)
            {
                Squares.Add(new Square());
            }
        }

        public IList<Square> Squares { get; set; }
    }
}
