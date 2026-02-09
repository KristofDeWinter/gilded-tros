using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        IList<Item> Items;

        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            ItemFactory factory = new();

            foreach (Item item in Items)
            {
                factory.CreateItem(item).Update();
            }
        }
    }
}
