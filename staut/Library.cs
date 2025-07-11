using System;
using System.Collections.Generic;

namespace Staut {
    public class Library {
        private List<Game> _gameList = [];
        private List<Item> _itemList = [];
        
        public List<Game> GameList
        {
            get => _gameList;
            set => _gameList = value ?? throw new ArgumentNullException(nameof(value));
        }

        public List<Item> ItemList
        {
            get => _itemList;
            set => _itemList = value ?? throw new ArgumentNullException(nameof(value));
        }
        protected Library(List<Game> gameList, List<Item> itemList)
        {
            GameList = gameList;
            ItemList = itemList;
        }
        
    }
}