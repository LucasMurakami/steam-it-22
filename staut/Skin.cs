using System;

namespace Staut {
    public class Skin : Item {
        private Item baseItem;
        private String texture;

        public Item BaseItem { get; }
        public String texture { get; set; }

        public Skin(Item baseItem, string texture, int id, string name, double price, Game game, string description, Rarity rarity) : Item(int id, string name, double price, Game game, string description, Rarity rarity)
        {
            this.baseItem = baseItem;
            this.texture = texture;
        }
    }
}