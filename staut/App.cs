using System;
using System.Collections.Generic;
using System.IO;

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

        string filePath = AppContext.BaseDirectory;

        for (int i = 0; i < 4; i++)
        {
            filePath = Path.GetDirectoryName(filePath);
        }


        string jsonFilePath = Path.Combine(filePath, "data", "games.json");
        var sampleGames = FileReader.CreateGamesFromJson(jsonFilePath);

        // Mockup Items

        jsonFilePath = Path.GetDirectoryName(jsonFilePath);
        jsonFilePath = Path.Combine(jsonFilePath, "items.json");
        var sampleItems = FileReader.CreateItemsFromJson(jsonFilePath, sampleGames);

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
                
                Console.WriteLine($"{i + 1}. {game.Name} - ${game.Price:F2}{saleIndicator}{inCartIndicator}{ownedIndicator}");
                Console.WriteLine($"   Publisher: {game.Publisher} | Category: {game.Category}");
                Console.WriteLine();
            }
            
            Console.WriteLine("Options:");
            Console.WriteLine("Enter game number to add to cart");
            Console.WriteLine("'back' to return to main menu");
            Console.Write("Your choice: ");
            
            var input = Console.ReadLine();
            
            if (input?.ToLower() == "back") {
                inStore = false;
            } else if (int.TryParse(input, out int gameIndex) && gameIndex > 0 && gameIndex <= _store.GameList.Count) {
                var selectedGame = _store.GameList[gameIndex - 1];
                
                
                if (_currentUser!.CheckGames().Contains(selectedGame)) {
                    Console.WriteLine($"\nYou already own '{selectedGame.Name}'!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                
                else if (_currentUser.Cart.Games.Contains(selectedGame)) {
                    Console.WriteLine($"\n'{selectedGame.Name}' is already in your cart!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else {
                    _currentUser.Cart.AddGame(selectedGame);
                    Console.WriteLine($"\n'{selectedGame.Name}' added to cart!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            } else {
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
        Console.WriteLine();
        Console.WriteLine("Press any key to return to main menu...");
        Console.ReadKey();
    }
}