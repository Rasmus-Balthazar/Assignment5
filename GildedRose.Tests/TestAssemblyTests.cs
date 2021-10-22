using Xunit;
using GildedRose;
using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace GildedRose.Tests
{
    
    public class TestAssemblyTests
    {
    
        private  Program _app;
        public TestAssemblyTests()
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
            _app = app;
        }
        
        [Fact]
        public void Test_OpeningPrintStatement()
        {
            //Given
            var writer = new StringWriter();

            Console.SetOut(writer);

            Program.Main(Array.Empty<string>());
            var actual = writer.GetStringBuilder().ToString().Trim();
            var final = actual.Split(Environment.NewLine);
            //When
            //Then
            Assert.Equal("OMGHAI!", final[0]);
        }

        [Fact]
        public void UpdateQuality_Quality_Is_Never_More_Than_50()
        {
        //Given
        var qualityFiftyOne = new Item{Name = "FiftyOne", SellIn = 30, Quality = 51};
        _app.Items.Add(qualityFiftyOne);

        //When
        
        var actual = _app.Items.Select(i => i).Where(i => i.Name == "FiftyOne").FirstOrDefault();
        var expectedQuality = 50;
        _app.UpdateQuality();

        //Then
        Assert.Equal(expectedQuality, actual.Quality);
        }

        [Fact]
        public void UpdateQuality_quality_Cant_Be_A_Negative_Quality()
        {
        //Given
        for(int i = 0; i < 7; i++){_app.UpdateQuality();}
        var expected = 0;
        var actual = _app.Items.Select(i => i).Where(i => i.Name == "Elixir of the Mongoose").FirstOrDefault();
        //When
        
        //Then
        Assert.Equal(expected,actual.Quality);
        }
        
        [Fact]
        public void updateQuality_given_SellIn_passed_quality_degrade_twice_as_fast()
        {

        //Given
        var expected = 6;
        var passedQuality = new Item{Name = "Elder Wand", SellIn = 0, Quality = 10};
        _app.Items.Add(passedQuality);
        _app.UpdateQuality();
        _app.UpdateQuality();

        //When
        
        var elderWand = _app.Items.Select(i => i).Where(i => i.Name == "Elder Wand").FirstOrDefault();
        var actual = elderWand.Quality;

        //Then
        Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void Brie_IncreasenInQualityAfterUpdate()
        {
            //Given
            var expected = new Item{Name = "Aged Brie", SellIn = 1, Quality = 1};
            //When
            _app.UpdateQuality();
            var actual = _app.Items.Select(i => i).Where(i => i.Name.Equals("Aged Brie")).FirstOrDefault();
            //Then
            Assert.Equal(expected.Quality, actual.Quality);
        }
        
        [Fact]
        public void UpdateQuality_UpdateOnRagnaros_MakesNoChange()
        {
        //Given
        var expected = new List<Item>
        {
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}
        };
        
        //When
        for (var i = 0; i < 10; i++){_app.UpdateQuality();}
        var legendaryList = _app.Items.Where(i => i.Name == "Sulfuras, Hand of Ragnaros").Select(i => i).ToList();
        
        //Then
        Assert.Equal(expected[0].Name, legendaryList[0].Name);
        Assert.Equal(expected[0].SellIn, legendaryList[0].SellIn);
        Assert.Equal(expected[0].Quality, legendaryList[0].Quality);
        Assert.Equal(expected[1].Name, legendaryList[1].Name);
        Assert.Equal(expected[1].SellIn, legendaryList[1].SellIn);
        Assert.Equal(expected[1].Quality, legendaryList[1].Quality);
        }
        
        [Fact]
        public void Backstage_Passes_increases_in_Quality_as_sellIn_approaches_0()
        {
            var before = _app.Items.FirstOrDefault(i => i.Name.Contains("Backstage passes")).Quality;
            for (var i = 0; i < 10; i++){_app.UpdateQuality();}
            var after = _app.Items.FirstOrDefault(i => i.Name.Contains("Backstage passes")).Quality;
            Assert.True(after > before);
        }
        
        [Fact]
        public void Backstage_Passes_Quality_increases_by_2_as_sellIn_lessThan_10()
        {
            var before = _app.Items.FirstOrDefault(i => i.Name.Contains("Backstage passes")).Quality;
            var expected = before + (1*5)  + (2 * 5);
            for (var i = 0; i < 10; i++){_app.UpdateQuality();}
            var after = _app.Items.FirstOrDefault(i => i.Name.Contains("Backstage passes")).Quality;
            Assert.Equal(expected,  after);
        }
        
        [Fact]
        public void Backstage_Passes_Quality_increases_by_3_as_sellIn_lessThan_5()
        {
            var before = _app.Items.FirstOrDefault(i => i.Name.Contains("Backstage passes")).Quality;
            var expected = before + (1*5)  + (2 * 5) + (3*5);
            for (var i = 0; i < 15; i++){_app.UpdateQuality();}
            var after = _app.Items.FirstOrDefault(i => i.Name.Contains("Backstage passes")).Quality;
            Assert.Equal(expected,  after);
        }
        
        [Fact]
        public void Brie_IncreasDoubleInQuality_WhenSellInIsNegative()
        {
        //Given
        var expected = new Item{Name = "Aged Brie", SellIn = -3, Quality = 8};
        //When
        for (int i = 0; i < 5; i++)
        {
            _app.UpdateQuality();
        }
        var actual = _app.Items.Select(i => i).Where(i => i.Name.Equals("Aged Brie")).FirstOrDefault();
        //Then
        Assert.Equal(expected.Quality, actual.Quality);
        }
    }
}
