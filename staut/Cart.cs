using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.IO;

namespace Staut {
    public class Cart {
        private List<Game>? games;
        private List<Item>? items;
        private double totalPrice;
        private int gems;
        private User user;

        static string moneySound;
        SoundPlayer player;

        static void Main(string[] args) {
            Cart cart = new Cart();
            cart.purchase();
        }
        public Cart() {
            moneySound = "sounds/money.wav";
            player = new SoundPlayer(moneySound);
            player.Load();
        }


        public bool purchase() {
            Console.Clear();
            Console.WriteLine("Seu saldo: 0.0");
            Console.WriteLine("Total da compra: R$ " + totalPrice);
            Console.WriteLine("Aperte \"Enter\" para confirmar a compra");

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Compra realizada com sucesso!");
            player.PlaySync();


            return true;
        }

        public void listGames() {
            StringBuilder builder = new StringBuilder();
            foreach (Game game in games) {
                builder.Append(game.Name + " | " + game.Price + "\n");
            }
        }

        public void listItems() {
            StringBuilder builder = new StringBuilder();
            // foreach (Item item in items) {
            //     builder.Append(item.Name + " | " + item.Price + "\n");
            // }
        }
        
        public void listCart() {
            StringBuilder builder = new StringBuilder();
            builder.Append("== GAMES ==\n");
            foreach (Game game in games) {
                builder.Append(game.Name + " | " + game.Price + "\n");
            }
            // builder.Append("== GAMES ==\n");
            // foreach (Item item in items) {
            //     builder.Append(item.Name + " | " + item.Price + "\n");
            // }
        }
    }
}