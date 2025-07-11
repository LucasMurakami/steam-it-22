using System;

namespace Staut {
    public abstract class Item {
        int id;
        String name;
        double price;
        DateTime obtainedDate;
        Game game;
        String description;
        Rarity rarity;
    }

    enum Rarity {
        COMMON,
        UNCOMMON,
        RARE,
        EPIC,
        MYTHIC,
        LEGENDARY
    }
}