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

           

            var endSquare = currentNode.Value;

            endSquare.Land(token);
            endSquare.AddToken(token);
        }

        public ISquare GetStartingSquare()
        {
            return this.Squares.FirstOrDefault();
        }

        public ISquare GetTokenSquare(Token token)
        {
            return this.Squares.FirstOrDefault(x => x.HasToken(token));
        }

        public IEnumerable<ISquare> GetNextSquares(Token token, int spaces)
        {
            var squareList = new List<ISquare>();
            var startingSquare = Squares.Find(GetTokenSquare(token));

            var currentNode = startingSquare;

            for (int i = 0; i <= spaces; i++)
            {
                currentNode = currentNode.Next;
                currentNode.Value.Pass(token);
                squareList.Add(currentNode.Value);
            }

            return squareList;
        }
    }
}