namespace GildedTros.App
{
    public class ItemFactory
    {
        private const string GoodWine = "Good Wine";
        private const string BackstagePassesHaxx = "Backstage passes for HAXX";
        private const string BackstagePassesRefactor = "Backstage passes for Re:factor";
        private const string Keychain = "B-DAWG Keychain";

        public BaseItem CreateItem(Item item)
        {
            return item.Name switch
            {
                GoodWine => new GoodWineItem(item),
                BackstagePassesHaxx => new BackstagePassesItem(item),
                BackstagePassesRefactor => new BackstagePassesItem(item),
                Keychain => new KeychainItem(item),
                _ => new DefaultItem(item)
            };
        }
    }
}
