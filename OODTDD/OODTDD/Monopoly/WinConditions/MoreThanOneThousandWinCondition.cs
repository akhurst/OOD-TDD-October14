using System.Linq;

namespace OODTDD.Monopoly.Squares
{
    public class MoreThanOneThousandWinCondition : IWinCondition
    {
        public bool IsWinCondition(Game game)
        {
            WinningPlayer = game.Players.OrderByDescending(x => x.Money).FirstOrDefault(x => x.Money >= 1000);
            return WinningPlayer != null;
        }

        public Player WinningPlayer { get; private set; }
    }

    public class MoreThanFiveThousandWinCondition : IWinCondition
    {
        public bool IsWinCondition(Game game)
        {
            WinningPlayer = game.Players.OrderByDescending(x => x.Money).FirstOrDefault(x => x.Money >= 5000);
            return WinningPlayer != null;
        }

        public Player WinningPlayer { get; private set; }
    }
}