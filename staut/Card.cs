using System.Collections.Generic;

namespace Staut {
    public class Card : Item {
        public IReadOnlyList<string> IconPackage { get; }

        public Card(
            List<string> iconPackage,
            int id,
            string name,
            double price,
            Game game,
            string description,
            Rarity rarity
        ) : base(id, name, price, game, description, rarity)
        {
            IconPackage = iconPackage.AsReadOnly();
        }
    }
}