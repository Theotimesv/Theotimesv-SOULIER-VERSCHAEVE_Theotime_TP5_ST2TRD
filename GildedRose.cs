using System.Collections.Generic;
using System.Diagnostics;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var item_index = 0; item_index < Items.Count; item_index++)
            {
                Item item = Items[item_index];

                bool conjured = item.Name.Contains("Conjured");

                switch (item.Name)
                {
                    case "Aged Brie":
                        update_aged_brie_quality(item, conjured);
                        item.SellIn--;
                        break;
                    
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    
                    case "Backstage passes to a TAFKAL80ETC concert":
                        update_Backstage_passes_quality(item, conjured);
                        item.SellIn--;
                        break;
                    
                    default:
                        update_classical_item_quality(item, conjured);
                        item.SellIn--;
                        break;
                }
            }
        }
        
        public static void update_aged_brie_quality(Item item, bool conjured)
        {
            if (item.SellIn <= 0)
            {
                item.Quality += 2 * (conjured ? 2 : 1);
            }
            else
            {
                item.Quality += 1 * (conjured ? 2 : 1);
            }
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }

        public static void update_Backstage_passes_quality(Item item, bool conjured)
        {
            item.Quality += 1 * (conjured ? 2 : 1);
            if (item.SellIn < 11)
            {
                item.Quality += 1 * (conjured ? 2 : 1);
                if (item.SellIn < 6)
                {
                    item.Quality += 1 * (conjured ? 2 : 1);
                }
            }
            if (item.Quality > 50)
            {
                item.SellIn = 50;
            }
            else if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
        }

        public static void update_classical_item_quality(Item item, bool conjured)
        {
            item.Quality -= 1 * (conjured ? 2 : 1);
            if (item.SellIn <= 0)
            {
                item.Quality -= 1 * (conjured ? 2 : 1);;
            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
