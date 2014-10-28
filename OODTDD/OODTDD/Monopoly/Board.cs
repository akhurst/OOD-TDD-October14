using System.Collections.Generic;
using System.Linq;

namespace OODTDD.Monopoly
{
    public class Board
    {
        public LinkedList<ISquare> Squares { get; set; }

        public void MoveToken(Token token, int spaces)
        {
            var startSquare = this.Squares.FirstOrDefault(x => x.HasToken(token));
            var currentNode = Squares.Find(startSquare);
            startSquare.RemoveToken(token);

            var lastSquare = startSquare;
            foreach (var square in GetNextSquares(startSquare, spaces))
            {
                square.Pass(token);
                lastSquare = square;
            }

            lastSquare.Land(token);
            
            lastSquare.AddToken(token);
        }

        public ISquare GetStartingSquare()
        {
            return this.Squares.FirstOrDefault();
        }

        public ISquare GetTokenSquare(Token token)
        {
            return this.Squares.FirstOrDefault(x => x.HasToken(token));
        }

        public IEnumerable<ISquare> GetNextSquares(ISquare square, int spaces)
        {
            var squareList = new List<ISquare>();
            var startingSquare = Squares.Find(square);

            var currentNode = startingSquare;

            for (int i = 0; i <= spaces; i++)
            {
                currentNode = currentNode.Next;
                squareList.Add(currentNode.Value);
            }

            return squareList;
        }
    }
}