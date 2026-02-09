namespace GildedTros.App
{
    public class SmellyItem : BaseItem
    {
        public SmellyItem(Item item) : base(item)
        {
        }

        public override void Update()
        {
            if (item.Quality > MinItemQuality)
                item.Quality -= 2;

            item.SellIn--;
        }
    }
}
