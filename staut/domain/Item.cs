using System;

namespace Staut {
    public abstract class Item {
        public int Id { get; }
        public string Name { get; }
        public double Price { get; }
        public DateTime? ObtainedDate { get; }
        public Game Game { get; }
        public string Description { get; }
        public Rarity Rarity { get; }

        protected Item(int id, string name, double price, Game game, string description, Rarity rarity) {
            Id = id;
            Name = name;
            Price = price < 0 ? 0 : price;
            Game = game;
            Description = description;
            Rarity = rarity;
            ObtainedDate = null;
        }
    }
}