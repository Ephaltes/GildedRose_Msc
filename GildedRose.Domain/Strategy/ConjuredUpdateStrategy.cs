using GildedRose.Domain.Entity;

namespace GildedRose.Domain.Strategy;

public class ConjuredUpdateStrategy : IUpdateStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality > 0)
            item.Quality -= 2;

        if (item.SellIn < 0 && item.Quality > 0)
            item.Quality -= 2;

        if (item.Quality < 0)
            item.Quality = 0;
    }
}