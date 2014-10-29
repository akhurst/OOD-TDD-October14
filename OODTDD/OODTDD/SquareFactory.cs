using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
	public class SquareFactory
	{
		public static List<Square> GetSquares(int n)
		{
			var squares = new List<Square>(n);
			for (int i = 0; i < n; i++)
			{
				switch (i)
				{
					case 0: squares.Add(new GoSquare());
						break;
					case 4: squares.Add(new IncomeTaxSquare());
						break;
					case 37: squares.Add(new LuxurySquare());
						break;
					default: squares.Add(new Square());
						break;
				}
			}
			LinkSquares(squares);
			return squares;
		}

		//TODO: Refactor this
		private static void LinkSquares(List<Square> squares)
		{

			for (int i = 0; i < squares.Count; i++)
			{
				var currentSquare = squares[i];
				var nextSquare = IsLastSquare(squares.Count, i) ? squares[0] : squares[i + 1];
				currentSquare.NextSquare = nextSquare;
			}
		}

		private static bool IsLastSquare(int count, int i)
		{
			return i == (count - 1);
		}

	}
}
