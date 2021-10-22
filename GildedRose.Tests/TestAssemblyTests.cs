using Xunit;
using GildedRose;
using System.IO;
using System;
using System.Collections.Generic;
namespace GildedRose.Tests
{
    
    public class TestAssemblyTests
    {
        public Program setUp()
        {
            var app = new Program()
                          {
                              Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

                          };
            return app;
        }
    
        private  Program _app;
        public TestAssemblyTests()
        {
            _app = setUp();
        }

        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }
        [Fact]
        public void Test_OpeningPrintStatement()
        {
        //Given
        var newActual = actual.Split(Environment.NewLine);
        
        //When
        //Then
        Assert.Equal("OMGHAI!", newActual[0]);
        }

        [Fact]
        public void UpdateQuality_UpdateOnRagnoros_MakesNoChange()
        {
        //Given
        //using Program.Main(new string[0]);
        
        var hand = _app.Items.Count;
        Console.WriteLine(hand);
        var expected = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
        //When
        for (int i = 0; i < 10; i++){_app.UpdateQuality();}
        Item handORagno = _app.Items[3];
        
        //Then
        Assert.Equal(expected, handORagno);
        
        }
    }
}