namespace OODTDD.Monopoly.Squares
{
    public interface IWinCondition
    {
        bool IsWinCondition(Game game);
        Player WinningPlayer { get; }
    }
}