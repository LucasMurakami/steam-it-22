using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace Staut {
    public class FileReader {
        public static List<Game> CreateGamesFromJson(string jsonFilePath) {
            var json = File.ReadAllText(jsonFilePath);
            var gameJsonList = JsonSerializer.Deserialize<List<GameJson>>(json);

            var games = new List<Game>();
            foreach (var g in gameJsonList!) {
                // Parse category string to enum
                if (!Enum.TryParse<Category>(g.category, out var category))
                    category = Category.Rpg; // fallback or handle error

                games.Add(new Game(
                    g.id,
                    g.name,
                    g.publisher,
                    g.publishedAt,
                    g.price,
                    g.items ?? new List<Item>(),
                    g.totalPurchase,
                    category
                ));
            }
            return games;
        }

        public static List<Item> CreateItemsFromJson(string jsonFilePath, List<Game> games) {
            var json = File.ReadAllText(jsonFilePath);
            var itemJsonList = JsonSerializer.Deserialize<List<ItemJson>>(json);

            var items = new List<Item>();
            foreach (var item in itemJsonList!) {
                var game = games.FirstOrDefault(g => g.Id == item.gameId);
                if (game == null) continue;

                if (!Enum.TryParse<Rarity>(item.rarity, out var rarity))
                    rarity = Rarity.Common;

                if (item.type == "Card") {
                    items.Add(new Card(
                        item.icons ?? new List<string>(),
                        item.id,
                        item.name,
                        item.price,
                        game,
                        item.description,
                        rarity
                    ));
                }
                else if (item.type == "Skin" && item.baseCard != null) {
                    var baseCardGame = games.FirstOrDefault(g => g.Id == item.baseCard.gameId);
                    if (baseCardGame == null) continue;

                    if (!Enum.TryParse<Rarity>(item.baseCard.rarity, out var baseRarity))
                        baseRarity = Rarity.Common;

                    var baseCard = new Card(
                        item.baseCard.icons ?? new List<string>(),
                        item.baseCard.id,
                        item.baseCard.name,
                        item.baseCard.price,
                        baseCardGame,
                        item.baseCard.description,
                        baseRarity
                    );

                    items.Add(new Skin(
                        baseCard,
                        item.texture ?? "",
                        item.id,
                        item.name,
                        item.price,
                        game,
                        item.description,
                        rarity
                    ));
                }
            }
            return items;
        }
        public class GameJson {
            public int id { get; set; }
            public string name { get; set; } = string.Empty;
            public string publisher { get; set; } = string.Empty;
            public DateTime publishedAt { get; set; }
            public double price { get; set; }
            public List<Item>? items { get; set; }
            public int totalPurchase { get; set; }
            public string category { get; set; } = string.Empty;
        }
        public class ItemJson {
            public string type { get; set; } = string.Empty;
            public int id { get; set; }
            public string name { get; set; } = string.Empty;
            public double price { get; set; }
            public int gameId { get; set; }
            public string description { get; set; } = string.Empty;
            public string rarity { get; set; } = string.Empty;
            public List<string>? icons { get; set; }
            public string? texture { get; set; }
            public CardJson? baseCard { get; set; }
        }

        public class CardJson {
            public string type { get; set; } = string.Empty;
            public int id { get; set; }
            public string name { get; set; } = string.Empty;
            public double price { get; set; }
            public int gameId { get; set; }
            public string description { get; set; } = string.Empty;
            public string rarity { get; set; } = string.Empty;
            public List<string>? icons { get; set; }
        }
    }
}