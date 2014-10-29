using System;
using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Squares;

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

            var game = new Game {Players = playerList, };
            game.CurrentPlayer = game.Players.First;

            game.WinConditions = new List<IWinCondition>{ new MoreThanOneThousandWinCondition()};

            List<ISquare> squares = new List<ISquare>();
            squares.Add(new GoSquare());
            foreach (var o in Enumerable.Range(1, 39))
            {
                squares.Add(new GenericSquare());
            }

            var squareList = new LinkedList<ISquare>(squares);

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