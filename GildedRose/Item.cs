using System;

namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
        
        public virtual void UpdateQuality()
        {
            SellIn--;
            if(SellIn >= 0) Quality -= 1;
            else Quality -= 2;

            capQuality();
        }

        public void capQuality()
        {
            if(Quality > 50) Quality = 50;
            if(Quality < 0) Quality = 0;
        }
    }
}
