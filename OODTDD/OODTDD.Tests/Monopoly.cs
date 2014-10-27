//using System;
//using System.Linq;

//namespace OODTDD.Tests
//{
//    public class Monopoly
//    {
//        public static Game GetGame(int numPlayers)
//        {
//            if (numPlayers < 2 || numPlayers > 10)
//            {
//                throw new Exception("Too many or few players");
//            }

//            var players = Enumerable.Repeat(new Player(), numPlayers);

//            foreach (var p in players)
//            {
//                p.Token = new Token();
//            }

//            var game = new Game {Players = players};

//            var board = new Board {Squares = Enumerable.Repeat(new Square(), 36)};

//            game.Board = board;

//            return game;
//        }
//    }
//}