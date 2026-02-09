namespace GildedTros.App
{
    public class DefaultItem : BaseItem
    {
        public DefaultItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (item.Quality > GildedTros.MinItemQuality)
                item.Quality--;

            item.SellIn--;

            if (item.SellIn < 0)
                item.Quality--;
        }
    }
}
