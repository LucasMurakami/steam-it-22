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
        private int _gems;

        public int Id => _id;

        public string Name => _name;

        public string Publisher => _publisher;

        public DateTime PublishedAt => _publishedAt;

        public double Price {
            get => _price;
            set => _price = value;
        }

        public List<Item> Content {
            get => _content;
        }

        public int TotalPurchase {
            get => _totalPurchase;
            set => _totalPurchase = value;
        }

        public Category Category {
            get => _category;
            set => _category = value;
        }

        public bool addContent(Item item) {
            if (item != null) {
                _content.Add(item);
                return true;
            }

            return false;
        }

        public int Gems {
            get => _gems;
        }

        public Game(int id, string name, string publisher, DateTime publishedAt, double price, int totalPurchase,
            Category category, int gems) {
            _id = id;
            _name = name;
            _publisher = publisher;
            _publishedAt = publishedAt;
            _price = price;
            _content = new List<Item>();
            _totalPurchase = totalPurchase;
            _category = category;
            _gems = gems;
        }
    }
}