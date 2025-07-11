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

        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set => price = value < 0 ? 0 : value }
        public DateTime? ObtainedDate { get; set; }
        public Game Game { get; }
        public string Description { get; set; }
        public Rarity Rarity { get; }

        protected Item(int id, string name, double price, Game game, string description, Rarity rarity)
        {
            _id = id;
            _name = name;
            if(price < 0)
            {
                _price = 0;
            }
            else
            {
                _price = price;
            }
            _obtainedDate = null;
            _game = game;
            _description = description;
            _rarity = rarity;
        }
    }
    
}