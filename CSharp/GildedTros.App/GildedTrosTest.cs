using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        // At the end of each day our system lowers both values for every item
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
        // At the end of each day our system lowers both values for every item
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
        // Once the sell by date has passed, Quality degrades twice as fast
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
        // The Quality of an item is never negative
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
        // "Good Wine" actually increases in Quality the older it gets
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
        // The Quality of an item is never more than 50
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

        [Fact]
        // "B-DAWG Keychain", being a legendary item, never has to be sold or decreases in Quality
        public void IncreaseQualityKeychainEndOfDayRemainsQualityTwenty()
        {
            // Given a b-dawg keychain item with SellIn of 2 and Quality of 20
            IList<Item> Items = new List<Item> { new() { Name = "B-DAWG Keychain", SellIn = 2, Quality = 20 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should still be 20
            Assert.Equal(20, Items[0].Quality);
        }

        [Fact]
        // "B-DAWG Keychain", being a legendary item, never has to be sold or decreases in Quality
        public void IncreaseSellInKeychainEndOfDayRemainsSellInTen()
        {
            // Given a b-dawg keychain item with SellIn of 10 and Quality of 20
            IList<Item> Items = new List<Item> { new() { Name = "B-DAWG Keychain", SellIn = 10, Quality = 20 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the SellIn should still be 10
            Assert.Equal(10, Items[0].SellIn);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches
        public void IncreaseQualityBackstagePassesEndOfDayGreaterThanTen()
        {
            // Given a backstage passes item with SellIn greater than 10 and Quality of 20
            IList<Item> Items = new List<Item> { new() { Name = "Backstage passes for Re:factor", SellIn = 15, Quality = 20 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 21
            Assert.Equal(21, Items[0].Quality);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches;
        // Quality increases by 2 when there are 10 days or less
        public void IncreaseQualityBackstagePassesEndOfDaySellInBetweenFiveAndTen()
        {
            // Given a backstage passes item with SellIn between 5 and ten and Quality of 20
            IList<Item> Items = new List<Item> { new() { Name = "Backstage passes for Re:factor", SellIn = 7, Quality = 20 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 22
            Assert.Equal(22, Items[0].Quality);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches;
        // Quality increases by 3 when there are 5 days or less
        public void IncreaseQualityBackstagePassesEndOfDaySellInLessThanFive()
        {
            // Given a backstage passes item with SellIn less than 5 and Quality of 20
            IList<Item> Items = new List<Item> { new() { Name = "Backstage passes for Re:factor", SellIn = 3, Quality = 20 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 23
            Assert.Equal(23, Items[0].Quality);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches;
        // Quality drops to 0 after the conference
        public void DecreaseQualityBackstagePassesEndOfDaySellInZero()
        {
            // Given a backstage passes item with SellIn of zero and Quality of 20
            IList<Item> Items = new List<Item> { new() { Name = "Backstage passes for Re:factor", SellIn = 0, Quality = 20 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 0
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        // Legendary items always have Quality 80
        public void IncreaseQualityKeychainEndOfDayRemainsQualityEighty()
        {
            // Given a b-dawg keychain item with SellIn of 10 and Quality of 80
            IList<Item> Items = new List<Item> { new() { Name = "B-DAWG Keychain", SellIn = 10, Quality = 80 } };
            GildedTros app = new(Items);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the SellIn should still be 80
            Assert.Equal(80, Items[0].Quality);
        }
    }
}