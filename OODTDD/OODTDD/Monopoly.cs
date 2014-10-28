using System;
using System.Collections.Generic;
using System.Linq;

namespace OODTDD.Monopoly
{
    public class MonopolyGame
    {
        public static Game GetGame(IEnumerable<Player> players)
        {
            var playerList = new LinkedList<Player>(players);
            if (playerList.Count() < 2 || playerList.Count() > 10)
            {
                throw new ArgumentException("Too many or few players");
            }

            var game = new Game {Players = playerList};

            var squareList = new LinkedList<ISquare>(Enumerable.Range(1, 35).Select(x => new GenericSquare()));
            squareList.AddFirst(new GoSquare());

            var board = new Board {Squares = squareList};

            game.Board = board;

            var startingSquare = game.Board.Squares.FirstOrDefault();
            foreach (var p in playerList)
            {
                startingSquare.AddToken(p.Token);
            }

            game.Board = board;

            return game;
        }
    }
}