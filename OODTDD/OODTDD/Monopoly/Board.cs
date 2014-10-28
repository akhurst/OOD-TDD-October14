using System.Collections.Generic;
using System.Linq;

namespace OODTDD.Monopoly
{
    public class Board
    {
        public List<Square> Squares { get; set; }

        public void MoveToken(Token token, int spaces)
        {
            var startQuare = this.Squares.FirstOrDefault(x => x.HasToken(token));
            
            int indexOf = this.Squares.IndexOf(startQuare);

            startQuare.RemoveToken(token);

            var endSquare = this.Squares[indexOf + spaces];
            endSquare.AddToken(token);
        }

        public Square GetStartingSquare()
        {
            return this.Squares.FirstOrDefault();
        }
    }
}