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

        public int GoSquareIndex{ get{ return 0; } }

        private void InitializeSquares()
        {
            Squares = new List<Square>();

            for (int i = 0; i < 36; i++)
            {
                if (i == GoSquareIndex)
                {
                    Squares.Add(new GoSquare());
                }
                else
                {
                    Squares.Add(new Square());
                }
            }

            LinkSquares();
        }

        private void LinkSquares()
        {

            for (int i = 0; i < Squares.Count; i++)
            {
                var currentSquare = Squares[i];
                var nextSquare = IsLastSquare(i) ? GoSquare : Squares[i + 1];
                currentSquare.NextSquare = nextSquare;
            }
        }

        private bool IsLastSquare(int i)
        {
            return i == (Squares.Count - 1);
        }


        public IList<Square> Squares { get; set; }

        public GoSquare GoSquare
        {
            get { return Squares[GoSquareIndex] as GoSquare; }
        }
    }
}
