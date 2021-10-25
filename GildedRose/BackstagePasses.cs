using System;

namespace GildedRose
{
    public class BackstagePasses : Item
    {
        public override void UpdateQuality()
        {
            switch (SellIn)
            {
                case < 0:
                    Quality = 0;
                    break;
                case <= 5:
                    Quality += 3;
                    break;
                case <= 10:
                    Quality += 2;
                    break;
                case > 10:
                    Quality += 1;
                    break;
            }
            SellIn--;

            capQuality();
        }
    }
}
