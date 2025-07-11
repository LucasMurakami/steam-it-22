using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.IO;

namespace Staut {
    public class Cart {
        List<Game>? games;
        List<Item>? items;
        double totalPrice;
        int gems;

        static string moneySound;
        SoundPlayer player;

        public Cart() {
            moneySound = "sounds/money.wav";
            player = new SoundPlayer(moneySound);
            player.Load();
        }


        public bool purchase() {
            Console.WriteLine("Aperte qualquer tecla para comprar");
            Console.ReadKey();
            player.PlaySync();

            return true;
        }

        // public void listGames() {
        //     StringBuilder builder = new StringBuilder();
        //     foreach (Game game in games) {
        //         builder.Append(game.getName() + " | " + game.getPrice() + "\n");
        //     }
        // }

        // public void listItems() {
        //     StringBuilder builder = new StringBuilder();
        //     foreach (Item item in items) {
        //         builder.Append(item.getName() + " | " + item.getPrice() + "\n");
        //     }
        // }
        
        // public void listCart() {
        //     StringBuilder builder = new StringBuilder();
        //     builder.Append("== GAMES ==\n");
        //     foreach (Game game in games) {
        //         builder.Append(game.getName() + " | " + game.getPrice() + "\n");
        //     }
        //     builder.Append("== GAMES ==\n");
        //     foreach (Item item in items) {
        //         builder.Append(item.getName() + " | " + item.getPrice() + "\n");
        //     }
        // }
    }
}