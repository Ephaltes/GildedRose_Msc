using GildedRose.Domain.Entity;

namespace GildedRose.Domain.Strategy;

public class AgedBrieUpdateStrategy : IUpdateStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality < 50)
            item.Quality++;

        if (item.SellIn < 0 && item.Quality < 50)
            item.Quality++;
    }
}