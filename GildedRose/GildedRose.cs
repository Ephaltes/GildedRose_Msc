using System.Collections.Generic;
using GildedRose.Domain.Entity;
using GildedRose.Domain.Factory;
using GildedRose.Domain.Strategy;

namespace GildedRose;

public class GildedRose
{
    private readonly IReadOnlyCollection<Item> _items;
    private readonly IUpdateStrategyFactory _updateStrategyFactory;

    public GildedRose(IReadOnlyCollection<Item> items, IUpdateStrategyFactory updateStrategyFactory)
    {
        _items = items;
        _updateStrategyFactory = updateStrategyFactory;
    }

    public void UpdateQuality()
    {
        foreach (Item item in _items)
        {
            IUpdateStrategy updateStrategy = _updateStrategyFactory.Create(item);
            updateStrategy.Update(item);
        }
    }
}