using System;
using System.Collections.Generic;

namespace Staut {
    public class Library {
        private List<Game> _gameList = [];
        private List<Item> _itemList = [];
        
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
        
        public void AddGame(Game game)
        {
            if (game == null)
                throw new ArgumentNullException(nameof(game));
                
            if (!_gameList.Contains(game))
            {
                _gameList.Add(game);
            }
        }

        public void AddItem(Item item) 
        {
            if (item == null) {
                throw new ArgumentNullException(nameof(item));
            }
            
            if (!_itemList.Contains(item))
            {
                _itemList.Add(item);
            }
        }
        
        public Library(List<Game> gameList, List<Item> itemList)
        {
            GameList = gameList;
            ItemList = itemList;
        }
        
    }
}