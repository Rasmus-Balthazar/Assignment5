using System;

namespace GildedRose
{
    public class BackstagePasses : Item
    {
        public override void UpdateQuality()
        {
            SellIn--;
            if(SellIn < 0) Quality = 0;
            else 
            {
                if(SellIn > 10) Quality += 1;
                else if (SellIn < 6) Quality += 3;
                else if(SellIn <= 10) Quality += 2;
            }
            
            capQuality();
        }
    }
}
