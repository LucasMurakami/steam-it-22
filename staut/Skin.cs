using System;

namespace Staut {
    public class Skin : Item {
        private Item _baseItem;
        private string _texture;

        public Item BaseItem { get; }
        public string texture { get; set; }

        public Skin(Item baseItem, string texture, int id, string name, double price, Game game, string description, Rarity rarity)
            : base(id, name, price, game, description, rarity)
        {
            _baseItem = baseItem;
            _texture = texture;
        }
    }
}