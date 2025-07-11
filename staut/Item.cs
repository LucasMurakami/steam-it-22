using System;

namespace Staut {
    public abstract class Item {
        private int id;
        private String name;
        private double price;
        private DateTime? obtainedDate;
        private Game game;
        private String description;
        private Rarity rarity;

        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set => price = value < 0 ? 0 : value }
        public DateTime? ObtainedDate { get; set; }
        public Game Game { get; }
        public string Description { get; set; }
        public Rarity Rarity { get; }

        protected Item(int id, string name, double price, Game game, string description, Rarity rarity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.obtainedDate = null;
            this.game = game;
            this.description = description;
            this.rarity = rarity;
        }
    }
    
}