using System.Collections;
using System.Collections.Generic;
using OODTDD.Monopoly.Actions;

namespace OODTDD.Monopoly
{
    public class Player
    {
        public Token Token { get; set; }
        public int Money { get; set; }
        public List<IPlayerAction> AvailableActions = new List<IPlayerAction>();
        public int TimesRolledThisTurn { get; set; }

        private IPlayerStrategy _playerStrategy = new OrderOfActionsStrategy();


        public IPlayerAction GetAction()
        {
            return _playerStrategy.GetAction(AvailableActions);
        }
    }
}