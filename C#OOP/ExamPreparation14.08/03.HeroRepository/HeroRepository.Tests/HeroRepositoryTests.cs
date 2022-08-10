using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void TestCreateMethodShouldReturnCorrectValue()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Oleg", 99);
        repository.Create(hero);
        Assert.AreEqual("Oleg", hero.Name);
        Assert.AreEqual(99, hero.Level);
    }
    [Test]
    public void CreateMethodShouldThrowExceptionIfHeroNameIsNull()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Oleg", 99);
        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Create(null);
        }, nameof(hero), "Hero is null");
    }
    [Test]
    public void CreateMethodWhenNameExistShouldThrowException()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Oleg", 99);
        repository.Create(hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            repository.Create(hero);
        }, "Hero with name Oleg already exists");
    }
    [Test]
    public void RemoveMethodShouldReturnCorrectValue()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Oleg", 99);
        repository.Create(hero);
        repository.Remove("Oleg");
        Assert.AreEqual(0, repository.Heroes.Count);
    }
    [Test]
    public void RemoveMethodShouldThrowExceptionIfHeroNameIsNull()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero = new Hero("Oleg", 99);
        Assert.Throws<ArgumentNullException>(() =>
        {
            repository.Remove(null);
        }, nameof(hero), "Name cannot be null");
    }
    [Test]
    public void GetHeroWithHighestLevelShoudReturnCorrectValue()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero1 = new Hero("Oleg", 99);
        Hero hero2 = new Hero("Pesho", 59);
        Hero hero3 = new Hero("Gosho", 79);
        repository.Create(hero1);
        repository.Create(hero2);
        repository.Create(hero3);
        repository.GetHeroWithHighestLevel();
        var expected = hero1;
        var actual = repository.GetHeroWithHighestLevel();
        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void GetHeroMethodShouldReturnCorrectValue()
    {
        HeroRepository repository = new HeroRepository();
        Hero hero1 = new Hero("Oleg", 99);
        Hero hero2 = new Hero("Pesho", 59);
        Hero hero3 = new Hero("Gosho", 79);
        repository.Create(hero1);
        repository.Create(hero2);
        repository.Create(hero3);
        Assert.AreEqual(hero1, repository.GetHero("Oleg"));
    }
}