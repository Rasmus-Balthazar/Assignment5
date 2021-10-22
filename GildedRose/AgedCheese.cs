using System;

namespace GildedRose
{
    public class AgedCheese : Item
    {
        public override void UpdateQuality()
        {
            SellIn--;
            if(SellIn >= 0) Quality++;
            else Quality += 2;
            capQuality();
        }
    }
}
