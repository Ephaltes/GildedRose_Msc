using Bogus;
using FluentAssertions;
using GildedRose.Domain.Entity;
using GildedRose.Domain.Strategy;
using NUnit.Framework;

namespace GildedRoseTests;

public class SulfurasUpdateStrategyBehaviour
{
    private Faker _faker;
    private SulfurasUpdateStrategy _updateStrategy;

    [SetUp]
    public void Setup()
    {
        _updateStrategy = new SulfurasUpdateStrategy();
        _faker = new Faker();
    }

    [Test]
    public void Update_Should_NotChange_SellIn()
    {
        int sellIn = _faker.Random.Int();

        Item item = new Faker<Item>()
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.SellIn.Should().Be(sellIn);
    }

    [Test]
    public void Update_Should_NotChange_Quality()
    {
        int quality = _faker.Random.Int();

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(quality);
    }
}