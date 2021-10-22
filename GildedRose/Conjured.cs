using System;

namespace GildedRose
{
    public class Conjured : Item
    {
        public override void UpdateQuality()
        {
            SellIn--;
            if(SellIn >= 0) Quality -= 2;
            else Quality -= 4;
            
            capQuality();
        }
    }
}
