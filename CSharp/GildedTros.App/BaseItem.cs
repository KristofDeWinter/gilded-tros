namespace GildedTros.App
{
    public abstract class BaseItem
    {
        protected Item item;

        public BaseItem(Item item)
        {
            this.item = item;
        }

        public abstract void Update();
    }
}
