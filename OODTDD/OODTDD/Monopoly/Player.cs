using System.Collections;
using System.Collections.Generic;
using OODTDD.Monopoly.Actions;
using OODTDD.Monopoly.PlayerStrategies;

namespace OODTDD.Monopoly
{
    public class Player
    {
        public Token Token { get; set; }
        public int Money { get; set; }
        public List<IPlayerAction> AvailableActions = new List<IPlayerAction>();
        public int TimesRolledThisTurn { get; set; }

        private IPlayerStrategy _playerStrategy;

        public Player()
        {
            _playerStrategy =  new OrderOfActionsStrategy();
        }
        public Player(IPlayerStrategy strategy)
        {
            _playerStrategy = strategy;
        }

        public IPlayerAction GetAction()
        {
            return _playerStrategy.GetAction(AvailableActions);
        }
    }
}