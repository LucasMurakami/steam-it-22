using System;
using System.Collections.Generic;

namespace Staut {
    public class Card : Item {
        private List<String> _iconPackage;

        public List<String> IconPackage { get; }

        public Card(List<String> iconPackage, int id, string name, double price, Game game, string description, Rarity rarity)
            : base(id, name, price, game, description, rarity)
        {
            _iconPackage = iconPackage;
        }
    }
}