using System;
using Bogus;
using FakeItEasy;
using FluentAssertions;
using GildedRose.Domain.Entity;
using GildedRose.Domain.Factory;
using GildedRose.Domain.Strategy;
using NUnit.Framework;

namespace GildedRoseTests;

public class UpdateStrategyFactoryBehaviour
{
    private AgedBrieUpdateStrategy _agedBrieUpdateStrategy;
    private BackstagePassUpdateStrategy _backstagePassUpdateStrategy;
    private BaseUpdateStrategy _baseUpdateStrategy;
    private ConjuredUpdateStrategy _conjuredUpdateStrategy;
    private SulfurasUpdateStrategy _sulfurasUpdateStrategy;

    private UpdateStrategyFactory _updateStrategyFactory;

    [SetUp]
    public void Setup()
    {
        _agedBrieUpdateStrategy = A.Fake<AgedBrieUpdateStrategy>();
        _backstagePassUpdateStrategy = A.Fake<BackstagePassUpdateStrategy>();
        _baseUpdateStrategy = A.Fake<BaseUpdateStrategy>();
        _conjuredUpdateStrategy = A.Fake<ConjuredUpdateStrategy>();
        _sulfurasUpdateStrategy = A.Fake<SulfurasUpdateStrategy>();

        _updateStrategyFactory = new UpdateStrategyFactory(_agedBrieUpdateStrategy, _sulfurasUpdateStrategy,
            _backstagePassUpdateStrategy, _conjuredUpdateStrategy, _baseUpdateStrategy);
    }

    [Test]
    [TestCase("Aged Brie", typeof(AgedBrieUpdateStrategy))]
    [TestCase("Sulfuras, Hand of Ragnaros", typeof(SulfurasUpdateStrategy))]
    [TestCase("Backstage passes to a TAFKAL80ETC concert", typeof(BackstagePassUpdateStrategy))]
    [TestCase("Conjured Mana Cake", typeof(ConjuredUpdateStrategy))]
    [TestCase("Something else", typeof(BaseUpdateStrategy))]
    public void Create_Should_Return_RightStrategy(string itemName, Type type)
    {
        Item item = new Faker<Item>()
            .RuleFor(item => item.Name, itemName);

        IUpdateStrategy strategy = _updateStrategyFactory.Create(item);

        strategy.Should().BeAssignableTo(type);
    }

    [Test]
    [TestCase("Aged Brie", typeof(BaseUpdateStrategy))]
    public void Create_Strategy_Should_NotBeAssignable_ToWrongType(string itemName, Type type)
    {
        Item item = new Faker<Item>()
            .RuleFor(item => item.Name, itemName);

        IUpdateStrategy strategy = _updateStrategyFactory.Create(item);

        strategy.Should().NotBeAssignableTo(type);
    }
}