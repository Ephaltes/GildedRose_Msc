using GildedRose.Domain.Entity;

namespace GildedRose.Domain.Strategy;

public interface IUpdateStrategy
{
    public void Update(Item item);
}