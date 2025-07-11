using System;

namespace Staut {
    public class Skin : Item {
        private string _baseItem;
        private string _texture;

        public string BaseItem { get; }
        public string texture { get; set; }

        public Skin(string baseItem, string texture, int id, string name, double price, Game game, string description, Rarity rarity)
            : base(id, name, price, game, description, rarity)
        {
            _baseItem = baseItem;
            _texture = texture;
        }
    }
}