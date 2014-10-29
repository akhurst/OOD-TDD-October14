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
        public int LuxuryTaxSquareIndex { get { return 37; } }
        public int IncomeTaxSquareIndex { get { return 4; } }
        public int JailSquareIndex { get { return 10; } }
        public int GoToJailSquareIndex { get { return 30; } }

        private void InitializeSquares()
        {
            Squares = new List<Square>();

            for (int i = 0; i < 40; i++)
            {
                if (i == GoSquareIndex)
                {
                    Squares.Add(new GoSquare());
                }
                else if (i == IncomeTaxSquareIndex)
                {
                    Squares.Add(new IncomeTaxSquare());
                }
                else if (i == LuxuryTaxSquareIndex)
                {
                    Squares.Add(new LuxuryTaxSquare());
                }
                else if (i == GoToJailSquareIndex)
                {
                    Squares.Add(new GoToJailSquare());
                }
                else
                {
                    Squares.Add(new Square());
                }
            }

            var goToJailSquare = Squares[GoToJailSquareIndex] as GoToJailSquare;
            if (goToJailSquare != null)
                goToJailSquare.JailSquare = Squares[JailSquareIndex];

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
