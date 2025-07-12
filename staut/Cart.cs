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
            foreach (Game game in _games) {
                Console.WriteLine($"{game.Name} | ${game.Price:F2}");
            }
        }

        private void ListItems() {
            Console.WriteLine("== ITEMS ==");
            foreach (Item item in _items) {
                Console.WriteLine($"{item.Name} | ${item.Price:F2}");
            }
        }

        public void ShowCart() {
            Console.WriteLine("===== YOUR CART =====");
            ListGames();
            ListItems();
            Console.WriteLine($"Total: ${TotalPrice:F2}");
        }
    }
}