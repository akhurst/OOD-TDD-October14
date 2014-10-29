﻿using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Actions;

namespace OODTDD.Monopoly.PlayerStrategies
{
    public class OrderOfActionsStrategy : IPlayerStrategy
    {
        public IPlayerAction GetAction(List<IPlayerAction> availableActions)
        {
            return availableActions.FirstOrDefault();
        }
    }
}