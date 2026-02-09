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

        [Fact]
        public void DecreaseQualitySellInPassedEndOfDay()
        {
            // Given an item with SellIn of 0 and quality of 4
            IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 0, Quality = 4 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should be 2
            Assert.Equal(2, Items[0].Quality);
        }

        [Fact]
        public void DecreaseQualityNeverNegativeEndOfDay()
        {
            // Given an item with SellIn of 2 and quality of 0
            IList<Item> Items = new List<Item> { new() { Name = "foo", SellIn = 4, Quality = 0 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should still be 0
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void IncreaseQualityGoodWineEndOfDay()
        {
            // Given a good wine item with SellIn of 2 and quality of 2
            IList<Item> Items = new List<Item> { new() { Name = "Good Wine", SellIn = 2, Quality = 2 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should be 3 and SellIn should be 1
            Assert.Equal(1, Items[0].SellIn);
            Assert.Equal(3, Items[0].Quality);
        }

        [Fact]
        public void IncreaseQualityGoodWineEndOfDayRemainsQualityFifty()
        {
            // Given an item with SellIn of 5 and quality of 50
            IList<Item> Items = new List<Item> { new() { Name = "Good Wine", SellIn = 5, Quality = 50 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should still be 50
            Assert.Equal(50, Items[0].Quality);
        }
    }
}