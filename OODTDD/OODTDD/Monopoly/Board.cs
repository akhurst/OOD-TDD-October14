using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;
using OODTDD.Monopoly.Extensions;
using OODTDD.Monopoly.Squares;

namespace OODTDD.Monopoly
{
    public class Board
    {
        public LinkedList<ISquare> Squares { get; set; }

        public IEnumerable<IGameEvent> MoveToken(Token token, int spaces)
        {
            var startSquare = this.Squares.FirstOrDefault(x => x.HasToken(token));
            var currentNode = Squares.Find(startSquare);

            currentNode.Value.RemoveToken(token);

            var moveEvents = new List<IGameEvent>();
            var lastSquare = startSquare;

            foreach (var square in GetNextSquares(currentNode, spaces))
            {
                moveEvents.AddRange(square.Pass(token));
                lastSquare = square;
            }

            moveEvents.AddRange(lastSquare.Land(token));
            
            lastSquare.AddToken(token);

            return moveEvents;
        }

        public ISquare GetStartingSquare()
        {
            return this.Squares.FirstOrDefault();
        }

        public ISquare GetTokenSquare(Token token)
        {
            return this.Squares.FirstOrDefault(x => x.HasToken(token));
        }

        public IEnumerable<ISquare> GetNextSquares(LinkedListNode<ISquare> square, int spaces)
        {
            var squareList = new List<ISquare>();
            LinkedListNode<ISquare> currentNode = square;

            for (int i = 0; i <= spaces; i++)
            {
                currentNode = currentNode.CircularNext();
                squareList.Add(currentNode.Value);
            }

            return squareList;
        }

        public IEnumerable<IGameEvent> MoveToSquare(Token token, ISquare square, bool jail = false)
        {
            var moveEvents = new List<IGameEvent>();
            if (square == null)
                return moveEvents;
            var startSquare = this.Squares.FirstOrDefault(x => x.HasToken(token));
            var currentNode = Squares.Find(startSquare);
            
            currentNode.Value.RemoveToken(token);

            while (currentNode.Value != square)
            {
                currentNode = currentNode.CircularNext();
                if (!jail)
                {
                    currentNode.Value.Pass(token);
                }
            }
            
            currentNode.Value.AddToken(token);

 
            moveEvents.AddRange(currentNode.Value.Land(token));

            return moveEvents;
        }
    }
}