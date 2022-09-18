using GildedRose.Domain.Entity;
using GildedRose.Domain.Strategy;

namespace GildedRose.Domain.Factory;

public class UpdateStrategyFactory : IUpdateStrategyFactory
{
    private readonly AgedBrieUpdateStrategy _agedBrieUpdateStrategy;
    private readonly BackstagePassUpdateStrategy _backstagePassUpdateStrategy;
    private readonly BaseUpdateStrategy _baseUpdateStrategy;
    private readonly ConjuredUpdateStrategy _conjuredUpdateStrategy;
    private readonly SulfurasUpdateStrategy _sulfurasUpdateStrategy;

    public UpdateStrategyFactory(AgedBrieUpdateStrategy agedBrieUpdateStrategy,
        SulfurasUpdateStrategy sulfurasUpdateStrategy, BackstagePassUpdateStrategy backstagePassUpdateStrategy,
        ConjuredUpdateStrategy conjuredUpdateStrategy, BaseUpdateStrategy baseUpdateStrategy)
    {
        _agedBrieUpdateStrategy = agedBrieUpdateStrategy;
        _sulfurasUpdateStrategy = sulfurasUpdateStrategy;
        _backstagePassUpdateStrategy = backstagePassUpdateStrategy;
        _conjuredUpdateStrategy = conjuredUpdateStrategy;
        _baseUpdateStrategy = baseUpdateStrategy;
    }

    public IUpdateStrategy Create(Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => _agedBrieUpdateStrategy,
            "Sulfuras, Hand of Ragnaros" => _sulfurasUpdateStrategy,
            "Backstage passes to a TAFKAL80ETC concert" => _backstagePassUpdateStrategy,
            "Conjured Mana Cake" => _conjuredUpdateStrategy,
            _ => _baseUpdateStrategy
        };
    }
}