namespace Staut {
    public class Skin : Item {
        public Item BaseItem { get; }
        public string Texture { get; }

        public Skin(
            Item baseItem,
            string texture,
            int id,
            string name,
            double price,
            Game game,
            string description,
            Rarity rarity
        ) : base(id, name, price, game, description, rarity)
        {
            BaseItem = baseItem;
            Texture = texture;
        }
    }
}