namespace GildedTros.App
{
    public abstract class BaseItem
    {
        protected const int MinItemQuality = 0;
        protected const int MaxItemQuality = 50;

        protected Item item;

        public BaseItem(Item item)
        {
            this.item = item;
        }

        public abstract void Update();
    }
}
