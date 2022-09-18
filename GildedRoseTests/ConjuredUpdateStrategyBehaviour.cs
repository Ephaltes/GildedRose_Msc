using Bogus;
using FluentAssertions;
using GildedRose.Domain.Entity;
using GildedRose.Domain.Strategy;
using NUnit.Framework;

namespace GildedRoseTests;

public class ConjuredUpdateStrategyBehaviour
{
    private Faker _faker;
    private ConjuredUpdateStrategy _updateStrategy;

    [SetUp]
    public void Setup()
    {
        _updateStrategy = new ConjuredUpdateStrategy();
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
    public void Update_Should_DecreaseQuality()
    {
        int quality = _faker.Random.Int(2, 50);
        int expectedQuality = quality - 2;
        int sellIn = _faker.Random.Int(0);

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality)
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(expectedQuality);
    }

    [Test]
    public void Update_QualityShould_NotBeNegative()
    {
        const int quality = 0;
        int sellIn = _faker.Random.Int(0);

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality)
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(quality);
    }

    [Test]
    public void Update_Should_DecreaseQuality_Double_When_SellInReached()
    {
        int quality = _faker.Random.Int(4, 48);
        int expectedQuality = quality - 4;
        int sellIn = _faker.Random.Int(-10, 0);

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality)
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(expectedQuality);
    }

    [Test]
    public void Update_Should_Set_QualityToZero_When_Negative()
    {
        int quality = _faker.Random.Int(-10, 0);
        const int expectedQuality = 0;
        int sellIn = _faker.Random.Int(-10, 0);

        Item item = new Faker<Item>()
            .RuleFor(item => item.Quality, quality)
            .RuleFor(item => item.SellIn, sellIn);

        _updateStrategy.Update(item);

        item.Quality.Should().Be(expectedQuality);
    }
}