using System;

namespace Staut {
    public abstract class Item {
        private int _id;
        private string _name;
        private double _price;
        private DateTime? _obtainedDate;
        private Game _game;
        private string _description;
        private Rarity _rarity;

        public int Id => _id;
        public string Name { get; set; }
        public double Price
        {
            get => _price;
            set => _price = value < 0 ? 0 : value;
        }
        public DateTime? ObtainedDate { get; set; }
        public Game Game => _game;
        public string Description { get; set; }
        public Rarity Rarity => _rarity;

        protected Item(int id, string name, double price, Game game, string description, Rarity rarity)
        {
            _id = id;
            _name = name;
            _price = price < 0 ? 0 : price;
            _obtainedDate = null;
            _game = game;
            _description = description;
            _rarity = rarity;
        }
    }
    
}