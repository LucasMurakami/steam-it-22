using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Media;

namespace Staut {
    [SuppressMessage("Interoperability", "CA1416:Validar a compatibilidade da plataforma")]
    public class Cart {
        private readonly List<Game> _games;
        private readonly List<Item> _items;
        private readonly User _user;
        private readonly SoundPlayer? _player;

        public List<Game> Games => _games;

        public List<Item> Items => _items;

        public Cart(User user) {
            _games = new();
            _items = new();
            _user = user;
            
                var path = Path.Combine(AppContext.BaseDirectory, "sounds", "money.wav");
                if (File.Exists(path)) {
                    _player = new SoundPlayer(path);
                    _player.Load();
                } else {
                    Console.WriteLine("Sound file not found at: " + path);
                }
        }

        public void AddGame(Game game) {
            _games.Add(game);
        }

        public bool RemoveItem(Item item) {
            return _items.Remove(item);
        }

        public bool RemoveGame(Game game) {
            return _games.Remove(game);
        }

        public void AddItem(Item item) {
            _items.Add(item);
        }

        private double TotalPrice => 
            _games.Sum(g => g.Price) + _items.Sum(i => i.Price);

        public bool Purchase() {
            Console.Clear();
            Console.WriteLine($"Your balance: ${_user.Balance:F2}");
            Console.WriteLine($"Total purchase amount: ${TotalPrice:F2}");
            Console.WriteLine("Press Enter to confirm your purchase");

            Console.ReadKey();

            if (_user.SubtractBalance(TotalPrice)) {
                Console.Clear();
                if (_games.Any()) {
                    foreach (Game game in _games) {
                        _user.Library.AddGame(game);
                    }
                    _games.Clear();
                }
                
                if (_items.Any()) {
                    foreach (Item item in _items) {
                        _user.Library.AddItem(item);
                    }
                    _items.Clear();
                }
                
                Console.WriteLine("Purchase completed successfully!");
                _player?.PlaySync();
                return true;
            } else {
                Console.Clear();
                Console.WriteLine("Insufficient balance.");
                return false;
            }
        }

        private void ListGames() {
            Console.WriteLine("== GAMES ==");
            int counter = 0;
            foreach (var game in _games) {
                Console.WriteLine($"{++counter}: {game.Name} | ${game.Price:F2}");
            }
        }

        private void ListItems() {
            Console.WriteLine("== ITEMS ==");
            int counter = 0;
            foreach (var item in _items) {
                Console.WriteLine($"{++counter}: " +
                                  $"{item.Name} | ${item.Price:F2}");
            }
        }

        public void ShowCart() {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║               MY CART                  ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            ListGames();
            ListItems();
            Console.WriteLine($"Total: ${TotalPrice:F2}");
        }
    }
}