using Xunit;
using GildedRose;
using System.IO;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Fact]
        public void TestTheTruth()
        {
            Assert.True(true);
        }
        [Fact]
        public void Test_OpeningPrintStatement()
        {
        //Given
        var writer = new StringWriter();
        //var reader = new StringReader("1");

        System.Console.SetOut(writer);
        //System.Console.SetIn(reader);

        Program.Main(new string[0]);
        string actual = writer.GetStringBuilder().ToString().Trim();
        //When
        //Then
        Assert.Equal("OMGHAI!", actual);
        }

        [Fact]
        public void UpdateQuality_UpdateOnRagnoros_MakesNoChange()
        {
        //Given
        var app = new Program();
        var expected = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
        //When
        for (int i = 0; i < 10; i++){app.UpdateQuality();}
        Item handORagno = app.Items[3];
        //Then
        Assert.Equal(expected, handORagno);
        }
    }
}