using System;
using System.Collections.Generic;

namespace Staut {
    public class Game {
        int id;
        String name;
        String publisher;
        DateTime publishedAt;
        double price;
        List<Item> content;
        int totalPurchase;
        Category category;
    }

    public enum Category {
        Action,
        Adventure,
        RPG,
        Strategy,
        Shooter,
        Simulation,
        Puzzle,
        Multiplayer
    }
}