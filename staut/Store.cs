using System;
using System.Collections.Generic;

namespace Staut {
    public class Store : Library {
        private List<Game> _salesGame = [];
        private List<Item> _salesItem = [];

        public List<Game> SalesGame
        {
            get => _salesGame;
            set => _salesGame = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<Item> SalesItem
        {
            get => _salesItem;
            set => _salesItem = value ?? throw new ArgumentNullException(nameof(value));
        }
        public Store(List<Game> gameList, List<Item> itemList, List<Game> salesGame, List<Item> salesItem) : base(gameList, itemList)
        {
            SalesGame = salesGame;
            SalesItem = salesItem;
        }
    }
}