using System.Collections.Generic;
using System.Linq;

namespace OODTDD.Monopoly
{
    public class Board
    {
        public LinkedList<Square> Squares { get; set; }

        public void MoveToken(Token token, int spaces)
        {
            var startQuare = this.Squares.FirstOrDefault(x => x.HasToken(token));
            
            int indexOf = this.Squares.First.Next;

            startQuare.RemoveToken(token);

            var endSquare = this.Squares[indexOf + spaces];
            endSquare.AddToken(token);
        }

        public Square GetStartingSquare()
        {
            return this.Squares.FirstOrDefault();
        }

        public Square GetTokenSquare(Token token)
        {
            return this.Squares.FirstOrDefault(x => x.HasToken(token));
        }

        public IEnumerable<Square> GetNextSquares(Token token, int i)
        {
            var squareList = new List<Square>();
            int startingIndex = Squares.IndexOf(GetTokenSquare(token));
        }
    }
}