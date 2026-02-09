using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        private const int MinQuality = 0;
        private const int MaxItemQuality = 50;

        IList<Item> Items;

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name != "Good Wine" 
                    && item.Name != "Backstage passes for Re:factor"
                    && item.Name != "Backstage passes for HAXX")
                {
                    if (item.Quality > MinQuality)
                    {
                        if (item.Name != "B-DAWG Keychain")
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < MaxItemQuality)
                    {
                        item.Quality++;

                        if (item.Name == "Backstage passes for Re:factor"
                        || item.Name == "Backstage passes for HAXX")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < MaxItemQuality)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < MaxItemQuality)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "B-DAWG Keychain")
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Good Wine")
                    {
                        if (item.Name != "Backstage passes for Re:factor"
                            && item.Name != "Backstage passes for HAXX")
                        {
                            if (item.Quality > MinQuality)
                            {
                                if (item.Name != "B-DAWG Keychain")
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = MinQuality;
                        }
                    }
                    else
                    {
                        if (item.Quality < MaxItemQuality)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}
