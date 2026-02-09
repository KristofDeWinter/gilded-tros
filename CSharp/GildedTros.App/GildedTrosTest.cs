using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        // At the end of each day our system lowers both values for every item
        public void UpdateQuality_Should_Decrease_Item_SellIn_By_1()
        {
            // Given an item with SellIn of 2
            var item = CreateItem("Item", 2, 2);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then SellIn should be 1
            Assert.Equal(1, item.SellIn);
        }

        [Fact]
        // At the end of each day our system lowers both values for every item
        public void UpdateQuality_Should_Decrease_Item_Quality_By_1()
        {
            // Given an item with Quality of 2
            var item = CreateItem("Item", 2, 2);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should be 1
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        // Once the sell by date has passed, Quality degrades twice as fast
        public void UpdateQuality_Should_Decrease_Item_Quality_By_2_When_Expired()
        {
            // Given an item with SellIn of 0 and quality of 4
            var item = CreateItem("Item", 0, 4);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should be 2
            Assert.Equal(2, item.Quality);
        }

        [Fact]
        // The Quality of an item is never negative
        public void UpdateQuality_Should_Not_Decrease_Item_Quality_When_0()
        {
            // Given an item with SellIn of 2 and quality of 0
            var item = CreateItem("Item", 4, 0);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should still be 0
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        // "Good Wine" actually increases in Quality the older it gets
        public void UpdateQuality_Should_Increase_Good_Wine_Quality_By_1()
        {
            // Given a "Good Wine" item with SellIn of 2 and quality of 2
            var item = CreateItem("Good Wine", 2, 2);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should be 3
            Assert.Equal(3, item.Quality);
        }

        [Fact]
        // The Quality of an item is never more than 50
        public void UpdateQuality_Should_Not_Increase_Quality_When_50()
        {
            // Given an item with SellIn of 5 and quality of 50
            var item = CreateItem("Good Wine", 5, 50);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then Quality should still be 50
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        // "B-DAWG Keychain", being a legendary item, never has to be sold or decreases in Quality
        public void UpdateQuality_Should_Not_Decrease_Keychain_Quality()
        {
            // Given a "B-DAWG Keychain" item with SellIn of 2 and Quality of 20
            var item = CreateItem("B-DAWG Keychain", 2, 20);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should still be 20
            Assert.Equal(20, item.Quality);
        }

        [Fact]
        // "B-DAWG Keychain", being a legendary item, never has to be sold or decreases in Quality
        public void UpdateQuality_Should_Not_Decrease_Keychain_SellIn()
        {
            // Given a "B-DAWG Keychain" item with SellIn of 10 and Quality of 20
            var item = CreateItem("B-DAWG Keychain", 10, 20);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the SellIn should still be 10
            Assert.Equal(10, item.SellIn);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches
        public void UpdateQuality_Should_Increase_Backstage_Passes_Quality_By_1_When_SellIn_Greater_Than_10()
        {
            // Given a "Backstage passes" item with SellIn greater than 10 and Quality of 20
            var item = CreateItem("Backstage passes for Re:factor", 15, 20);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 21
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches;
        // Quality increases by 2 when there are 10 days or less
        public void UpdateQuality_Should_Increase_Backstage_Passes_Quality_By_2_When_SellIn_Greater_Than_5_And_Less_Than_11()
        {
            // Given a "Backstage passes" item with SellIn between 5 and ten and Quality of 20
            var item = CreateItem("Backstage passes for Re:factor", 7, 20);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 22
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches;
        // Quality increases by 3 when there are 5 days or less
        public void UpdateQuality_Should_Increase_Backstage_Passes_Quality_By_3_When_SellIn_Less_Than_6()
        {
            // Given a "Backstage passes" item with SellIn less than 5 and Quality of 20
            var item = CreateItem("Backstage passes for Re:factor", 3, 20);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 23
            Assert.Equal(23, item.Quality);
        }

        [Fact]
        // "Backstage passes" for very interesting conferences increases in Quality as its SellIn value approaches;
        // Quality drops to 0 after the conference
        public void UpdateQuality_Should_Decrease_Backstage_Passes_Quality_To_0_When_SellIn_0()
        {
            // Given a "Backstage passes" item with SellIn of zero and Quality of 20
            var item = CreateItem("Backstage passes for Re:factor", 0, 20);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should be 0
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        // Legendary items always have Quality 80
        public void UpdateQuality_Should_Not_Increase_Keychain_Quality_When_80()
        {
            // Given a "B-DAWG Keychain" item with SellIn of 10 and Quality of 80
            var item = CreateItem("B-DAWG Keychain", 10, 80);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should still be 80
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        // Smelly items ("Duplicate Code", "Long Methods", "Ugly Variable Names") degrade in Quality twice as fast as normal items
        public void UpdateQuality_Should_Decrease_Smelly_Item_Quality_By_2()
        {
            // Given a "Duplicate Code" item with SellIn of 10 and Quality of 30
            var item = CreateItem("Duplicate Code", 10, 30);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should still be 80
            Assert.Equal(28, item.Quality);
        }

        [Fact]
        // Smelly items ("Duplicate Code", "Long Methods", "Ugly Variable Names") lower SellIn by 1 each day
        public void UpdateQuality_Should_Decrease_Smelly_Item_SellIn_By_1()
        {
            // Given a "Duplicate Code" item with SellIn of 10 and Quality of 30
            var item = CreateItem("Duplicate Code", 10, 30);
            var app = CreateGildedTros(item);

            // When the quality update is processed end of day
            app.UpdateQuality();

            // Then the Quality should still be 80
            Assert.Equal(9, item.SellIn);
        }

        private static Item CreateItem(string name, int sellIn, int quality)
        {
            return new Item()
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };
        }

        private static GildedTros CreateGildedTros(Item item)
        {
            return new GildedTros(new List<Item> { item });
        }
    }
}