using System;
using System.Collections.Generic;
using System.Linq;

namespace OODTDD.Monopoly
{
    public class MonopolyGame
    {
        public static Game GetGame(IEnumerable<Player> players)
        {
            var playerList = players as IList<Player> ?? players.ToList();
            if (playerList.Count() < 2 || playerList.Count() > 10)
            {
                throw new ArgumentException("Too many or few players");
            }

            var game = new Game {Players = playerList};

            var board = new Board {Squares = Enumerable.Range(1, 36).Select(x => new Square()).ToList()};

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