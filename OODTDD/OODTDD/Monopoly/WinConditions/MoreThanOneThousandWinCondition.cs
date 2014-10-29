using System.Linq;

namespace OODTDD.Monopoly.Squares
{
    public class MoreThanMoneyWinCondition : IWinCondition
    {
        private int _money;
        public MoreThanMoneyWinCondition(int money)
        {
            _money = money;
        }

        public bool IsWinCondition(Game game)
        {
            WinningPlayer = game.Players.OrderByDescending(x => x.Money).FirstOrDefault(x => x.Money >= _money);
            return WinningPlayer != null;
        }

        public Player WinningPlayer { get; private set; }
    }
}