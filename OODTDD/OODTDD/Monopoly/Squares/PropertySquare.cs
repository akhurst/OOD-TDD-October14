using System;
using System.Collections.Generic;
using System.Linq;
using OODTDD.Monopoly.Events;

namespace OODTDD.Monopoly.Squares
{
    public class PropertySquare : AbstractSquare
    {
        private string _name;
        private PropertyGrouping _group;
        private List<int> _rentTiers;
        public int Price { get; private set; }
        public Token OwnedBy { get; private set; }
        private int _tierIndex;
        public PropertySquare(string Name, PropertyGrouping grouping, int price, List<int> rentTiers )
        {
            _name = Name;
            _group = grouping;
            Price = price;
            _rentTiers = rentTiers;
        }

        public override IEnumerable<IGameEvent> Land(Token token)
        {
            var events = new List<IGameEvent>();

            if (OwnedBy == null)
            {
                events.Add(new AvailableToBuyPropertyEvent(this, token));
            }
            else
            {
                events.Add(new ChargeRentEvent(this, token));
            }
            return events;
        }

        public IEnumerable<IGameEvent> Purchase(Player player, int tierIndex)
        {
            OwnedBy = player.Token;
            _tierIndex = tierIndex;

            return new List<IGameEvent> {new DebitMoneyEvent(player.Token, Price)};
        }

        public IEnumerable<IGameEvent> DeductRent(Player player)
        {

            return new List<IGameEvent> { new DebitMoneyEvent(player.Token, GetRent()), new GetMoneyEvent(OwnedBy, GetRent()) };
        }

        private int GetRent()
        {
            return _rentTiers[_tierIndex];
        }
    }
}