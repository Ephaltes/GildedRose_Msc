using GildedRose.Domain.Factory;
using Lamar;

namespace GildedRose.Configuration;

public class GildedRoseConfiguration
{
    private readonly Container _container;

    public GildedRoseConfiguration()
    {
        _container = GenerateContainer();
    }

    public T Get<T>()
    {
        return _container.GetInstance<T>();
    }

    private Container GenerateContainer()
    {
        return new Container(container =>
        {
            container.For<IUpdateStrategyFactory>()
                .Use<UpdateStrategyFactory>();
        });
    }
}