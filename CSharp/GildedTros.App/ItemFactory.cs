namespace GildedTros.App
{
    public class ItemFactory
    {
        private const string GoodWine = "Good Wine";
        private const string BackstagePassesHaxx = "Backstage passes for HAXX";
        private const string BackstagePassesRefactor = "Backstage passes for Re:factor";
        private const string Keychain = "B-DAWG Keychain";
        private const string SmellyItemDuplicateCode = "Duplicate Code";
        private const string SmellyItemLongMethods = "Long Methods";
        private const string SmellyItemUglyVariableNames = "Ugly Variable Names";

        public BaseItem CreateItem(Item item)
        {
            return item.Name switch
            {
                GoodWine => new GoodWineItem(item),
                BackstagePassesHaxx => new BackstagePassesItem(item),
                BackstagePassesRefactor => new BackstagePassesItem(item),
                Keychain => new KeychainItem(item),
                SmellyItemDuplicateCode => new SmellyItem(item),
                SmellyItemLongMethods => new SmellyItem(item),
                SmellyItemUglyVariableNames => new SmellyItem(item),
                _ => new DefaultItem(item)
            };
        }
    }
}
