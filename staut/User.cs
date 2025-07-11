using System;
using System.Collections.Generic;
using System.Linq;

namespace Staut
{
    public class User
    {
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
            Status status)
        {
            _id = ID++;
            _username = username;
            _password = password;
            _name = name;
            _email = email;
            _description = description;
            _status = status;
            _gems = 0;
            _library = new Library(new List<Game>(), new List<Item>());
            _cart = new Cart();
            _balance = 0.0;
        }


        private string Name
        {
            get => _name;

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }

        private string Password
        {
            get => _password;

            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _password = value;
                }
            }
        }

        private double Balance
        {
            get => _balance;

            set
            {
                if (value > 0)
                {
                    _balance += value;
                }
            }
        }

        private List<Game> checkGames()
        {
            return _library.GameList;
        }

        private List<Item> checkItems()
        {
            return _library.ItemList;
        }

        private List<Item> checkItemsByGame(Game game)
        {
            List<Item> query = (from myGame in checkGames()
                where myGame.Name.Equals(game.Name)
                from item in myGame.Content
                select item).ToList();

            return query;
        }

        public string Description
        {
            get => _description;
            private set => _description = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        public Status Status
        {
            get => _status;
            private set => _status = value;
        }
        
        private Cart checkCart => _cart;

        private int Gems
        {
            get => _gems;
            set => _gems = value;
        }
    }
}