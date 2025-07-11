using System;
using System.Collections.Generic;

namespace Staut;

public class staut {
    static void Main(string[] args) {
        
        // Creating user
        User user = new User(
            username: "sharkboy99",
            password: "senha123",
            name: "Henrique Schultz",
            email: "henrique@devmail.com",
            description: "Desenvolvedor focado em ser fullstack 🧠🔥",
            status: Status.Online
        );

        // Creating games
        var game1 = new Game(1, "CyberStrike", "Neon Games", new DateTime(2023, 5, 10), 59.99, 150_000,
            Category.Shooter, 500);
        var game2 = new Game(2, "Mystic Realms", "DreamForge", new DateTime(2021, 11, 2), 39.99, 95_000, Category.Rpg,
            300);
        var game3 = new Game(3, "Empire Architect", "BuildSoft", new DateTime(2020, 3, 15), 29.99, 120_000,
            Category.Simulation, 250);
        var game4 = new Game(4, "Shadow Protocol", "BlackBox Studio", new DateTime(2022, 10, 31), 49.99, 60_000,
            Category.Action, 400);
        var game5 = new Game(5, "Arena Champions", "GoalTech", new DateTime(2024, 2, 20), 39.99, 210_000,
            Category.Multiplayer, 600);
        var game6 = new Game(6, "Brain Master", "PuzzleLab", new DateTime(2019, 6, 5), 19.99, 40_000, Category.Puzzle,
            150);
        var game7 = new Game(7, "Total Tactics", "Tactics Corp", new DateTime(2023, 1, 10), 44.99, 130_000,
            Category.Strategy, 350);
        var game8 = new Game(8, "Jungle Journey", "NaturePlay", new DateTime(2022, 8, 12), 34.99, 78_000,
            Category.Adventure, 275);
        var game9 = new Game(9, "Dungeon Lords", "EpicForge", new DateTime(2020, 4, 1), 49.99, 99_000, Category.Rpg,
            450);
        var game10 = new Game(10, "FireTeam Zero", "Urban Motion", new DateTime(2024, 6, 15), 24.99, 45_000,
            Category.Shooter, 200);


        // Adding items to games
        game1.addContent(new Skin("Soldier", "cyber_red.png", 1, "Red Cyber Armor", 5.99, game1,
            "Limited edition armor", Rarity.Rare));
        game1.addContent(new Card(new List<string> { "icon1.png", "icon2.png" }, 2, "Hacker Card", 3.49, game1,
            "Enhances hacking skills", Rarity.Epic));

        game2.addContent(new Skin("Mage", "wizard_robes.png", 3, "Arcane Robes", 2.99, game2, "Worn by ancient wizards",
            Rarity.Uncommon));
        game2.addContent(new Card(new List<string> { "staff.png" }, 4, "Magic Staff Card", 1.99, game2,
            "Summons a fireball", Rarity.Rare));

        game3.addContent(new Card(new List<string> { "castle.png", "gate.png" }, 5, "Castle Pack", 4.99, game3,
            "Adds new castle parts", Rarity.Mythic));

        game4.addContent(new Skin("Assassin", "night_ops.png", 6, "Night Ops Suit", 6.66, game4, "Stealth skin",
            Rarity.Legendary));

        game5.addContent(new Skin("Champion", "champion_glow.png", 7, "Champion Aura", 2.50, game5,
            "Glows during match", Rarity.Rare));
        game5.addContent(new Card(new List<string> { "arena1.png" }, 8, "Arena Pass", 3.75, game5,
            "Unlocks exclusive arenas", Rarity.Mythic));

        game6.addContent(new Card(new List<string> { "hint.png" }, 9, "Hint Booster", 1.99, game6, "Gives extra hints",
            Rarity.Common));

        game7.addContent(new Skin("General", "commander_skin.png", 10, "Commander Outfit", 5.00, game7, "Boosts morale",
            Rarity.Epic));
        game7.addContent(new Card(new List<string> { "strategy1.png" }, 11, "Tactic Set", 2.50, game7,
            "New tactics available", Rarity.Uncommon));

        game8.addContent(new Skin("Explorer", "explorer_hat.png", 12, "Explorer Hat", 1.25, game8,
            "Increases vision range", Rarity.Common));

        game9.addContent(new Skin("Dark Knight", "dark_knight_base.png", 13, "Dark Knight", 3.33, game9, "Base skin",
            Rarity.Rare));
        game9.addContent(new Skin("Dark Knight", "flaming_knight.png", 14, "Flaming Knight", 4.44, game9,
            "Upgraded version", Rarity.Legendary));

        game10.addContent(new Card(new List<string> { "badge1.png", "badge2.png" }, 15, "Elite Badge Pack", 2.49,
            game10, "Adds prestige icons", Rarity.Uncommon));

        
        Console.WriteLine(
            "\t █████████████████████████████████████ \n" + 
            "\t █████████████████████████████████████ \n" +
            "\t ██████████████████████████████▀▀▀▀███ \n" +
            "\t ████████████████████████████▀─▄▀▀▄─▀█ \n" +
            "\t ██▀─▄▄─▀████████████████████─█────█─█ \n" +
            "\t █─▄▀──▀─▀███████████████████─▀▄──▄▀─█ \n" +
            "\t █─█───────▀█████████████████▄──▀▀───█ \n" +
            "\t █▄─▀▄▄▀─────▀███████████████▀─────▄██ \n" +
            "\t ███▄▄▄▄█▄─────▀████████████▀─────▄███ \n" +
            "\t ██████████▄─────▀█████████▀─────▄████ \n" +
            "\t ████████████▄─────▀██████▀─────▄█████ \n" +
            "\t ██████████████▄─────▀▀──▀─────▄██████ \n" +
            "\t ████████████████▄──────▀▀▄───▄███████ \n" +
            "\t ██████████████████▄───────█─▄████████ \n" +
            "\t ████████████████████▄─▄──▄▀─█████████ \n" +
            "\t █████████████████████▄─▀▀─▄██████████ \n" +
            "\t █████████████████████████████████████ \n" +
            "\t █████████████████████████████████████ \n");

        
        Console.WriteLine("\t ╔═══════════════════════════════════╗");
        Console.WriteLine("\t ║         WELCOME TO STAUT          ║");
        Console.WriteLine("\t ║═══════════════════════════════════║");
        Console.WriteLine("\t ║         1) User                   ║");
        Console.WriteLine("\t ╠═══════════════════════════════════╣");
        Console.WriteLine("\t ║         2) Library                ║");
        Console.WriteLine("\t ║═══════════════════════════════════║");
        Console.WriteLine("\t ║         3) Store                  ║");
        Console.WriteLine("\t ╠═══════════════════════════════════╣");
        Console.WriteLine("\t ║         4) Quit                   ║");
        Console.WriteLine("\t ╚═══════════════════════════════════╝");
        // user.checkCart.purchase();
    }
}