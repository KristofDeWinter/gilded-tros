namespace GildedTros.App
{
    public class GoodWineItem : BaseItem
    {
        public GoodWineItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (item.Quality < MaxItemQuality)
                item.Quality++;

            item.SellIn--;

            if (item.SellIn < 0 && item.Quality < MaxItemQuality)
                item.Quality++;
        }
    }
}
