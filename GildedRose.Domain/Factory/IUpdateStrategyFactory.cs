using GildedRose.Domain.Entity;
using GildedRose.Domain.Strategy;

namespace GildedRose.Domain.Factory;

public interface IUpdateStrategyFactory
{
    public IUpdateStrategy Create(Item item);
}