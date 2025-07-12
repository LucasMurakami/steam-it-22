using System;
using System.Collections.Generic;
using System.Linq;

namespace Staut {
    public class User {
        
        private static int _globalIdCounter;

        private int Id { get; }
        private string Username { get; }
        private string Password { get; }
        public string Email { get; private set; }
        public string FullName { get; private set; }
        public string Description { get; private set; }
        public double Balance { get; private set; }
        public int Gems { get; private set; }

        public Status Status { get; private set; }
        public Library Library { get; }
        public Cart Cart { get; }

        public User(
            string username,
            string password,
            string fullName,
            string email,
            string description,
            Status status
        ) {

            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty.");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name cannot be empty.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            Id = _globalIdCounter++;
            Username = username;
            Password = password;
            FullName = fullName;
            Email = email;
            Description = description; 
            Balance = 0.0;
            Gems = 0;
            Status = status;
            Library = new Library(new List<Game>(), new List<Item>());
            Cart = new Cart(this);
        }
        
        /*
         * ===BALANCE METHODS===
         * Add Balance: Adds amount to user balance.
         * Subtract Balance: Subtracts amount from user balance.
         */
        public bool AddBalance(double amount) {
            if (amount < 0) return false;
            Balance += amount;
            return true;
        }
        
        public bool SubtractBalance(double amount) {
            if (amount < 0 || amount > Balance) return false;
            Balance -= amount;
            return true;
        }

        /*
         * === CHECK METHODS ===
         * Check Games: return value of all library games.
         * Check Items: return value of all library items.
         * Check Items By Game: return value of all items from a specific game.
         */
        
        public List<Game> CheckGames() {
            return Library.GameList;
        }
        
        public List<Item> CheckItems() {
            return Library.ItemList;
        }
        
        public List<Item> CheckItemsByGame(Game game) {
            List<Item> query = (from myGame in CheckGames()
                where myGame.Name.Equals(game.Name)
                from item in myGame.Content
                select item).ToList();

            return query;
        }
        
        /*
         * === GEM METHODS===
         * Add Gems: Adds amount to user gems.
         * Subtract Gems: Subtracts amount from user gems.
         */
        public bool AddGems(int amount) {
            if (amount <= 0) return false;
            Gems += amount;
            return true;
        }

        public bool SubtractGems(int amount) {
            if (amount <= 0 || amount > Gems) return false;
            Gems -= amount;
            return true;
        }
        
        
        /*
         * === UPDATE METHODS===
         * Description, Email & Full Name
         */
        public bool UpdateDescription(string newDescription) {
            if (string.IsNullOrWhiteSpace(newDescription)) return false;
            Description = newDescription;
            return true;
        }

        public bool UpdateEmail(string newEmail) {
            if (string.IsNullOrWhiteSpace(newEmail)) return false;
            Email = newEmail;
            return true;
        }

        public bool UpdateFullName(string newFullName) {
            if (string.IsNullOrWhiteSpace(newFullName)) return false;
            FullName = newFullName;
            return true;
        }

    }
}