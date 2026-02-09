using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        private const string GoodWine = "Good Wine";
        private const string BackstagePassesHaxx = "Backstage passes for HAXX";
        private const string BackstagePassesRefactor = "Backstage passes for Re:factor";
        private const string Keychain = "B-DAWG Keychain";

        IList<Item> Items;

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                switch (item.Name)
                {
                    case GoodWine:
                        {
                            if (item.Quality < MaxItemQuality)
                                item.Quality++;

                            item.SellIn--;

                            if (item.SellIn < 0 && item.Quality < MaxItemQuality)
                                item.Quality++;
                        }
                        break;
                    case BackstagePassesHaxx:
                    case BackstagePassesRefactor:
                        {
                            if (item.Quality < MaxItemQuality)
                                item.Quality++;
                            if (item.SellIn < 11)
                                item.Quality++;
                            if (item.SellIn < 6)
                                item.Quality++;

                            item.SellIn--;

                            if (item.SellIn < 0)
                                item.Quality = MinQuality;
                        }
                        break;
                    case Keychain:
                        break;
                    default:
                        {
                            if (item.Quality > MinQuality)
                                item.Quality--;

                            item.SellIn--;

                            if (item.SellIn < 0)
                                item.Quality--;
                        }
                        break;
                }
            }
        }
    }
}
