using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        private const int MinQuality = 0;
        private const int MaxItemQuality = 50;

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
                if (item.Name == Keychain)
                {
                    continue;
                }

                if (item.Name != GoodWine && item.Name != BackstagePassesRefactor && item.Name != BackstagePassesHaxx)
                {
                    if (item.Quality > MinQuality)
                    {
                        item.Quality--;
                    }
                }
                else if (item.Quality < MaxItemQuality)
                {
                    item.Quality++;

                    if (item.Name == BackstagePassesRefactor || item.Name == BackstagePassesHaxx)
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality++;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality++;
                        }
                    }
                }

                item.SellIn--;

                if (item.SellIn >= 0)
                {
                    continue;
                }

                if (item.Name == GoodWine && item.Quality < MaxItemQuality)
                {
                    item.Quality++;
                }
                else if (item.Name == BackstagePassesRefactor || item.Name == BackstagePassesHaxx)
                {
                    item.Quality = MinQuality;
                }
                else if (item.Quality > MinQuality)
                {
                    item.Quality--;
                }
            }
        }
    }
}
