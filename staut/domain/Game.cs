using System;
using System.Collections.Generic;

namespace Staut {
    public class Game {
        private readonly int _id;
        private readonly String _name;
        private readonly String _publisher;
        private readonly DateTime _publishedAt;
        private double _price;
        private List<Item> _content;
        private int _totalPurchase;
        private Category _category;

        public int Id => _id;

        public string Name => _name;

        public string Publisher => _publisher;

        public DateTime PublishedAt => _publishedAt;

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public List<Item> Content
        {
            get => _content;
            set => _content = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int TotalPurchase
        {
            get => _totalPurchase;
            set => _totalPurchase = value;
        }

        public Category Category
        {
            get => _category;
            set => _category = value;
        }

        public Game(int id, string name, string publisher, DateTime publishedAt, double price, List<Item> content, int totalPurchase, Category category)
        {
            _id = id;
            _name = name;
            _publisher = publisher;
            _publishedAt = publishedAt;
            _price = price;
            _content = content;
            _totalPurchase = totalPurchase;
            _category = category;
        }
    }
}