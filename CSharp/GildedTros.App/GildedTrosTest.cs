using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void DecreaseSellInByOneEndOfDay()
        {
            // Given an item with SellIn of 2
            IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 2, Quality = 2 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then SellIn should be 1
            Assert.Equal(1, Items[0].SellIn);
        }

        [Fact]
        public void DecreaseQualityByOneEndOfDay()
        {
            // Given an item with Quality of 2
            IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 2, Quality = 2 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should be 1
            Assert.Equal(1, Items[0].Quality);
        }
    }
}