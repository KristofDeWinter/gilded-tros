namespace GildedTros.App
{
    public class BackstagePassesItem : BaseItem
    {
        public BackstagePassesItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (item.Quality < MaxItemQuality)
                item.Quality++;
            if (item.Quality < MaxItemQuality && item.SellIn < 11)
                item.Quality++;
            if (item.Quality < MaxItemQuality && item.SellIn < 6)
                item.Quality++;

            item.SellIn--;

            if (item.SellIn < 0)
                item.Quality = MinItemQuality;
        }
    }
}
