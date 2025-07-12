using System;
using System.Collections.Generic;

namespace Staut {
    public class Library {
        private readonly List<Game> _gameList = [];
        private readonly List<Item> _itemList = [];
        
        public List<Game> GameList
        {
            get => _gameList;
            private init => _gameList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<Item> ItemList
        {
            get => _itemList;
            private init => _itemList = value ?? throw new ArgumentNullException(nameof(value));
        }
        public Library(List<Game> gameList, List<Item> itemList)
        {
            GameList = gameList;
            ItemList = itemList;
        }
        
    }
}