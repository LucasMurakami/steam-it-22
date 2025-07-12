using System;
using System.Collections.Generic;
using System.Linq;

namespace Staut {
    public class User {
        public static int ID = 0;
        private readonly int _id;
        private readonly String _username;
        private String _name;
        private String _password;
        private String _email;
        private double _balance;
        private readonly Library _library;
        private String _description;
        private Status _status;
        private readonly Cart _cart;
        private int _gems;

        public User(string username, string password, string name, string email, string description,
            Status status) {
            _id = ID++;
            _username = username;
            _password = password;
            _name = name;
            _email = email;
            _description = description;
            _status = status;
            _gems = 0;
            _library = new Library(new List<Game>(), new List<Item>());
            _cart = new Cart(this);
            _balance = 0.0;
        }

        public string Name {
            get => _name;

            private set {
                if (!String.IsNullOrEmpty(value)) {
                    _name = value;
                }
            }
        }

        public string Password {
            get => _password;

            private set {
                if (!String.IsNullOrEmpty(value)) {
                    _password = value;
                }
            }
        }

        public double Balance => _balance;

        public bool AddBalance(double amount) {
            if (amount > 0) {
                _balance += amount;
                return true;
            }

            return false;
        }
        
        

        public bool SubtractBalance(double amount)
        {
            if (amount > 0 && _balance >= amount)
            {
                _balance -= amount;
                return true;
            }

            return false;
        }

        public List<Game> CheckGames() {
            return _library.GameList;
        }

        public List<Item> CheckItems() {
            return _library.ItemList;
        }

        public List<Item> CheckItemsByGame(Game game) {
            List<Item> query = (from myGame in CheckGames()
                where myGame.Name.Equals(game.Name)
                from item in myGame.Content
                select item).ToList();

            return query;
        }

        public string Description {
            get => _description;
            private set => _description = value;
        }

        public bool ChangeDescription(string newDescription) {
            if (!newDescription.Equals(" ")) {
                Description = newDescription;
                return true;
            }

            return false;
        }

        public string Email {
            get => _email;
            private set => _email = value;
        }

        public bool ChangeEmail(string newEmail) {
            if (!newEmail.Equals(" ")) {
                Email = newEmail;
                return true;
            }

            return false;
        }

        public Status Status {
            get => _status;
            set => _status = value;
        }

        public Cart CheckCart => _cart;

        public int Gems => _gems;
        
        public bool AddGems(int amount) {
            if (amount > 0) {
                _gems += amount;
                return true;
            }

            return false;
        }

        public bool SubtractGems(int amount)
        {
            if (amount > 0 && _gems >= amount)
            {
                _gems -= amount;
                return true;
            }

            return false;
        }
        
    }
}