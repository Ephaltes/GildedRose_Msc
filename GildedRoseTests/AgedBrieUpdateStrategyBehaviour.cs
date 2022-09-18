using Bogus;
using FluentAssertions;
using GildedRose.Domain.Entity;
using GildedRose.Domain.Strategy;
using NUnit.Framework;

namespace GildedRoseTests;

public class AgedBrieUpdateStrategyBehaviour
{
    private Faker _faker;
    private AgedBrieUpdateStrategy _updateStrategy;

    [SetUp]
    public void Setup()
    {
        _updateStrategy = new AgedBrieUpdateStrategy();
        _faker = new Faker();
    }

    [Test]
    public void Update_Should_Reduce_SellIn()
    {
        int sellIn = _faker.Random.Int();
        int expectedSellIn = sellIn - 1;

        Item item = new Faker<Item>()
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.SellIn.Should().Be(expectedSellIn);
    }

    [Test]
    public void Update_Should_IncreaseQuality()
    {
        int quality = _faker.Random.Int(0, 49);
        int expectedQuality = quality + 1;
        int sellIn = _faker.Random.Int(0);

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality)
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(expectedQuality);
    }

    [Test]
    public void Update_QualityShould_NotExceed_50()
    {
        const int quality = 50;
        const int sellIn = -5;

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality)
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(quality);
    }

    [Test]
    public void Update_Should_IncreaseQuality_Double_When_SellInSmallerZero()
    {
        int quality = _faker.Random.Int(0, 48);
        int expectedQuality = quality + 2;
        const int sellIn = -5;

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality)
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(expectedQuality);
    }
}