using System;
using System.Collections.Generic;

namespace Staut;

public class App {
    private static readonly List<User> Users = new List<User>();
    private static User? _currentUser = null;
    private static Store? _store;

    public static void Main(string[] args) {
        InitializeData();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(
            "\t\t ████████████████████████████████▀▀▀▀████████████████████████████████████████████ \n" +
            "\t\t ██████████████████████████████▀─▄▀▀▄─▀██████████████████████████████████████████ \n" +
            "\t\t ████▀─▄▄─▀████████████████████─█────█─██████████████████████████████████████████ \n" +
            "\t\t ███─▄▀──▀─▀███████████████████─▀▄──▄▀─██████████████████████████████████████████ \n" +
            "\t\t ███─█───────▀█████████████████▄──▀▀───██████████████████████████████████████████ \n" +
            "\t\t ███▄─▀▄▄▀─────▀███████████████▀─────▄██████░░░░░█░░░░░░█░░░███░░███░░█░░░░░░████ \n" +
            "\t\t █████▄▄▄▄█▄─────▀████████████▀─────▄███████░░██████░░███░░░███░░███░░███░░██████ \n" +
            "\t\t ████████████▄─────▀█████████▀─────▄████████░░░░░███░░██░░█░░██░░███░░███░░██████ \n" +
            "\t\t ██████████████▄─────▀██████▀─────▄████████████░░███░░██░░░░░██░░███░░███░░██████ \n" +
            "\t\t ████████████████▄─────▀▀──▀─────▄██████████░░░░░███░░█░░░█░░░██░░░░░████░░██████ \n" +
            "\t\t ██████████████████▄──────▀▀▄───▄████████████████████████████████████████████████ \n" +
            "\t\t ████████████████████▄───────█─▄█████████████████████████████████████████████████ \n" +
            "\t\t ██████████████████████▄─▄──▄▀─██████████████████████████████████████████████████ \n" +
            "\t\t ███████████████████████▄─▀▀─▄███████████████████████████████████████████████████ \n" +
            "\t\t ████████████████████████████████████████████████████████████████████████████████ \n" );
        Console.ResetColor();
        Console.ReadKey();
        
        
        while (_currentUser == null) {
            bool login = Login();

            if (login) {
                ShowWelcomeScreen();
                MainLoop();
            }
        }
    }

    static bool Login() {
        Console.WriteLine("Enter your username: ");
        var username = Console.ReadLine();
        Console.WriteLine("Enter your password: ");
        var password = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password)) {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║       Empty username or password       ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine("Press any key to try again...");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            return false;
        }

        foreach (var u in Users) {
            if (u.Login(password, username)) {
                _currentUser = u;
                return true;
            }
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║      Invalid username or password      ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine("Press any key to try again...");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();

        return false;
    }

    private static void InitializeData() {
        Users.Add(new User(
            username: "sharkboy99",
            pas: "senha123",
            fullName: "Henrique Schultz",
            email: "henrique@devmail.com",
            description: "Fullstack-focused developer 🧠🔥",
            status: Status.Online
        ));

        // Currency For Test
        Users[0].AddBalance(100.0);
        Users[0].AddGems(50);

        // Mockup Games
        var sampleGames = new List<Game> {
            new Game(1, "Cyberpunk 2077", "CD Projekt Red", DateTime.Now.AddYears(-2), 59.99, new List<Item>(), 1000000,
                Category.Rpg),
            new Game(2, "Counter-Strike 2", "Valve", DateTime.Now.AddYears(-1), 0.0, new List<Item>(), 50000000,
                Category.Shooter),
            new Game(3, "The Witcher 3", "CD Projekt Red", DateTime.Now.AddYears(-8), 39.99, new List<Item>(), 5000000,
                Category.Rpg),
            new Game(4, "Portal 2", "Valve", DateTime.Now.AddYears(-12), 9.99, new List<Item>(), 2000000,
                Category.Puzzle),
            new Game(5, "Civilization VI", "Firaxis Games", DateTime.Now.AddYears(-7), 59.99, new List<Item>(), 1500000,
                Category.Strategy)
        };

        // Mockup Items
        var sampleItems = new List<Item> {
            new Card(new List<string> { "icon1.png", "icon2.png" }, 1, "Cyberpunk Badge", 2.99, sampleGames[0],
                "Rare badge from Night City", Rarity.Rare),
            new Skin(new Card(new List<string>(), 2, "Base Weapon", 0, sampleGames[1], "", Rarity.Common),
                "gold_texture.png", 3, "Golden AK-47", 15.99, sampleGames[1], "Shiny golden weapon skin", Rarity.Epic)
        };

        // Mockup Store com Sales
        var salesGames = new List<Game> { sampleGames[2], sampleGames[3] }; // Witcher 3 and Portal 2 on sale
        var salesItems = new List<Item> { sampleItems[0] }; // Cyberpunk badge on sale

        _store = new Store(sampleGames, sampleItems, salesGames, salesItems);
    }

    private static void ShowWelcomeScreen() {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║              WELCOME TO STAUT          ║");
        Console.WriteLine("║            Your Gaming Platform        ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine($"Welcome back, {_currentUser?.FullName}!");
        Console.WriteLine($"Balance: ${_currentUser?.Balance:F2} | Gems: {_currentUser?.Gems}");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void MainLoop() {
        bool running = true;
        
        while (running) {
            Console.Clear();
            ShowMainMenu();
            
            var choice = Console.ReadLine();
            
            switch (choice) {
                case "1":
                    ShowStore();
                    break;
                case "2":
                    ShowLibrary();
                    break;
                case "3":
                    ShowCart();
                    break;
                case "4":
                    ShowProfile();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        
        Console.WriteLine("Thanks for using Staut! Goodbye!");
    }

    private static void ShowMainMenu() {
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║                STAUT MENU              ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine("1. Store");
        Console.WriteLine("2. Library");
        Console.WriteLine("3. Cart");
        Console.WriteLine("4. Profile");
        Console.WriteLine("5. Exit");
        Console.WriteLine();
        Console.Write("Choose an option: ");
    }

    private static void ShowStore() {
        bool inStore = true;
        
        while (inStore) {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║                 STORE                  ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            Console.WriteLine();
            
            
            Console.WriteLine("FEATURED GAMES:");
            for (int i = 0; i < _store!.GameList.Count; i++) {
                var game = _store.GameList[i];
                var saleIndicator = _store.SalesGame.Contains(game) ? " [ON SALE!]" : "";
                var inCartIndicator = _currentUser!.Cart.Games.Contains(game) ? " [IN CART]" : "";
                var ownedIndicator = _currentUser.CheckGames().Contains(game) ? " [OWNED]" : "";

                Console.WriteLine($"G{i + 1}. {game.Name} - ${game.Price:F2}{saleIndicator}{inCartIndicator}{ownedIndicator}");
                Console.WriteLine($"   Publisher: {game.Publisher} | Category: {game.Category}");
                Console.WriteLine();
            }

            Console.WriteLine("FEATURED ITEMS:");
            for (int i = 0; i < _store.ItemList.Count; i++) {
                var item = _store.ItemList[i];
                string itemType = item.GetType().Name;

                var saleIndicator = _store.SalesItem.Contains(item) ? " [ON SALE!]" : "";
                var inCartIndicator = _currentUser!.Cart.Items.Contains(item) ? " [IN CART]" : "";
                var ownedIndicator = _currentUser.CheckItems().Contains(item) ? " [OWNED]" : "";

                Console.WriteLine($"I{i + 1}. {item.Name} - {item.Price:F2} GEMS | {saleIndicator}{inCartIndicator}{ownedIndicator}");
                Console.WriteLine($"   Type: {itemType}");
                Console.WriteLine();
            }

            Console.WriteLine("Options:");
            Console.WriteLine("Enter G# to add a game (e.g., G2)");
            Console.WriteLine("Enter I# to add an item (e.g., I1)");
            Console.WriteLine("'back' to return to main menu");
            Console.Write("Your choice: ");

            var input = Console.ReadLine()?.ToUpper();

            if (input == "BACK") {
                inStore = false;
            }
            else if (input!.StartsWith("G") && int.TryParse(input.Substring(1), out int gIndex) &&
                     gIndex > 0 && gIndex <= _store.GameList.Count) {
                var selectedGame = _store.GameList[gIndex - 1];
    
                if (_currentUser!.CheckGames().Contains(selectedGame)) {
                    Console.WriteLine($"\nYou already own '{selectedGame.Name}'!");
                } else if (_currentUser.Cart.Games.Contains(selectedGame)) {
                    Console.WriteLine($"\n'{selectedGame.Name}' is already in your cart!");
                } else {
                    _currentUser.Cart.AddGame(selectedGame);
                    Console.WriteLine($"\n'{selectedGame.Name}' added to cart!");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (input.StartsWith("I") && int.TryParse(input.Substring(1), out int iIndex) &&
                     iIndex > 0 && iIndex <= _store.ItemList.Count) {
                var selectedItem = _store.ItemList[iIndex - 1];

                if (_currentUser!.CheckItems().Contains(selectedItem)) {
                    Console.WriteLine($"\nYou already own '{selectedItem.Name}'!");
                } else if (_currentUser.Cart.Items.Contains(selectedItem)) {
                    Console.WriteLine($"\n'{selectedItem.Name}' is already in your cart!");
                } else {
                    _currentUser.Cart.AddItem(selectedItem);
                    Console.WriteLine($"\n'{selectedItem.Name}' added to cart!");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else {
                Console.WriteLine("Invalid selection. Press any key to continue...");
                Console.ReadKey();
            }

        }
    }

    private static void ShowLibrary() {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║               MY LIBRARY               ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine();
        
        var userGames = _currentUser!.CheckGames();
        
        if (userGames.Count == 0) {
            Console.WriteLine("Your library is empty. Visit the store to buy games!");
        } else {
            Console.WriteLine("Your Games:");
            foreach (var game in userGames) {
                Console.WriteLine($"• {game.Name} ({game.Category})");
            }
        }
        
        Console.WriteLine();
        Console.WriteLine("Press any key to return to main menu...");
        Console.ReadKey();
    }

    private static void ShowCart() {
        var inCart = true;
        while (inCart) {
            Console.Clear();
            _currentUser!.Cart.ShowCart();
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine("Type BUY to purchase all items.");
            Console.WriteLine("Type the number of the game to remove it from the cart");
            Console.WriteLine("Or type BACK to move to the main menu");
            Console.Write("Your choice: ");
            var choice = Console.ReadLine();

            if (choice?.ToLower() == "buy") {
                var success = _currentUser.Cart.Purchase();
                if (success) {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else {
                    Console.WriteLine("Error occurred. Press any key to continue...");
                    Console.ReadKey();
                }
                continue;
            }
            if (choice?.ToLower() == "back") {
                inCart = false;
                continue;
            }

            if (int.TryParse(choice, out var number) && number > 0 && number <= _currentUser.Cart.Games.Count) {
                var selectedGame = _currentUser.Cart.Games[number - 1];
                var success = _currentUser.Cart.RemoveGame(selectedGame); 
                
                Console.WriteLine(success
                    ? $"Game {selectedGame.Name} removed from cart!"
                    : "Error occurred. Unable to remove game from cart.");
                Console.ReadKey();
            }
            else {
                Console.WriteLine("Invalid input. Please try again.");
                Console.ReadKey();
            }
        }
    }

    private static void ShowProfile() {
        Console.Clear();
        Console.WriteLine("╔════════════════════════════════════════╗");
        Console.WriteLine("║               MY PROFILE               ║");
        Console.WriteLine("╚════════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine($"Full Name: {_currentUser?.FullName}");
        Console.WriteLine($"Email: {_currentUser?.Email}");
        Console.WriteLine($"Description: {_currentUser?.Description}");
        Console.WriteLine($"Status: {_currentUser?.Status}");
        Console.WriteLine($"Balance: ${_currentUser?.Balance:F2}");
        Console.WriteLine($"Gems: {_currentUser?.Gems}");
        Console.WriteLine($"Games Owned: {_currentUser?.CheckGames().Count}");
        Console.WriteLine($"Items Owned: {_currentUser?.CheckItems().Count}");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("Type BALANCE to add money in the account.");
        Console.WriteLine("Type GEMS to add gems in the account.");
        Console.WriteLine("Or type BACK to move to the main menu");
        Console.WriteLine();
        Console.Write("Your choice: ");
        var choice = Console.ReadLine();
        
        if (choice?.ToLower() == "balance") {
            Console.Clear();
            Console.WriteLine("Enter amount of money to add to the account.");
            var amountInput = Console.ReadLine();
            if (int.TryParse(amountInput, out var amount)) {
                var sucess =_currentUser.AddBalance(amount);
                if (sucess) {
                    Console.WriteLine($"You added ${amount} to your account.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        else if (choice?.ToLower() == "gems") {
            Console.Clear();
            Console.WriteLine("Enter amount of gems to add to the account.");
            var amountInput = Console.ReadLine();
            if (int.TryParse(amountInput, out var amount)) {
                var sucess = _currentUser.AddGems(amount);
                if (sucess) {
                    Console.WriteLine($"You added {amount} gems to your account.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}