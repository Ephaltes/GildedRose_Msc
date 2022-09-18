using GildedRose.Domain.Entity;

namespace GildedRose.Domain.Strategy;

public class BaseUpdateStrategy : IUpdateStrategy
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality > 0)
            item.Quality--;

        if (item.SellIn < 0 && item.Quality > 0)
            item.Quality--;
    }
}