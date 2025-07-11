using System;
using System.Collections.Generic;

namespace Staut {
    public class Card : Item {
        private List<String> iconPackage;

        public List<String> IconPackage { get; }

        public Card(List<String> iconPackage, int id, string name, double price, Game game, string description, Rarity rarity) : Item(int id, string name, double price, Game game, string description, Rarity rarity)
        {
            this.iconPackage = iconPackage;
        }
    }
}