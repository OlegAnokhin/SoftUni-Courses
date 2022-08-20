using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void WeaponConstructorTest()
            {
                Weapon weapon = new Weapon("Name", 150.55, 99);
                Assert.AreEqual("Name", weapon.Name);
                Assert.AreEqual(150.55, weapon.Price);
                Assert.AreEqual(99, weapon.DestructionLevel);
            }
            [TestCase(-9999999)]
            [TestCase(-1.00)]
            public void WeaponConstructorPriceShouldThrowExceprion(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Name", price, 99);
                }, "Price cannot be negative.");
            }
            [Test]
            public void WeaponConstructorIncreaseTest()
            {
                Weapon weapon = new Weapon("Name", 150.55, 9);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(10, weapon.DestructionLevel);
            }
            [Test]
            public void WeaponIsNuclearTest()
            {
                Weapon weapon = new Weapon("Name", 150.55, 99);
                weapon.IncreaseDestructionLevel();
                var expectedAfter = weapon.IsNuclear;
                Assert.AreEqual(true, expectedAfter);
            }
            [Test]
            public void PlanetConstructorTest()
            {
                Planet planet = new Planet("Name", 666.666);
                Assert.AreEqual("Name", planet.Name);
                Assert.AreEqual(666.666, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void PlanetNameIsNullOrEmpryShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    new Planet("", 666.666);
                }, "Invalid planet Name");
                Assert.Throws<ArgumentException>(() =>
                {
                    new Planet(null, 666.666);
                }, "Invalid planet Name");
            }
            [Test]
            public void PlanetBudgetNegativeShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    new Planet("Name", -666.666);
                }, "Budget cannot drop below Zero!");
            }
            [Test]
            public void AddWeaponTest()
            {
                Planet planet = new Planet("Name", 666.666);
                Weapon weapon1 = new Weapon("Name1", 150.55, 99);
                Weapon weapon2 = new Weapon("Name2", 160.55, 88);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                Assert.AreEqual(2, planet.Weapons.Count);
            }
            [Test]
            public void MilitaryPowerRatioTest()
            {
                Planet planet = new Planet("Name", 666.666);
                Weapon weapon1 = new Weapon("Name1", 150.55, 99);
                Weapon weapon2 = new Weapon("Name2", 160.55, 88);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                var actual = planet.MilitaryPowerRatio;
                Assert.AreEqual(187.0, actual);
            }
            [Test]
            public void PlanetProfitTest()
            {
                Planet planet = new Planet("Name", 616.666);
                planet.Profit(50.00);
                Assert.AreEqual(666.666, planet.Budget);
            }
            [Test]
            public void SpendFundTest()
            {
                Planet planet = new Planet("Name", 777);
                planet.SpendFunds(111);
                Assert.AreEqual(666, planet.Budget);
            }
            [Test]
            public void SpendFundsShouldThrowException()
            {
                var planet = new Planet("Name", 111);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(666);
                }, "Not enough funds to finalize the deal.");
            }
            [Test]
            public void IncreaseDestructionLevevShouldIncrese()
            {
                Weapon weapon1 = new Weapon("Name1", 150.55, 9);
                Weapon weapon2 = new Weapon("Name2", 160.55, 8);
                weapon1.IncreaseDestructionLevel();
                weapon2.IncreaseDestructionLevel();
                Assert.AreEqual(10, weapon1.DestructionLevel);
                Assert.AreEqual(9, weapon2.DestructionLevel);
            }
            [Test]
            public void IsNuclearShouldWorkCorrect()
            {
                Weapon weapon1 = new Weapon("Name1", 150.55, 9);
                Weapon weapon2 = new Weapon("Name2", 160.55, 18);
                Assert.IsFalse(weapon1.IsNuclear);
                Assert.IsTrue(weapon2.IsNuclear);
            }
            [Test]
            public void RemoveWeaponTest()
            {
                Planet planet = new Planet("Name", 666.666);
                Weapon weapon1 = new Weapon("Name1", 150.55, 99);
                Weapon weapon2 = new Weapon("Name2", 160.55, 88);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon("Name2");
                Assert.AreEqual(1, planet.Weapons.Count);
            }
            [Test]
            public void UpgradeWeaponTest()
            {
                Planet planet = new Planet("Name", 666.666);
                Weapon weapon1 = new Weapon("Name1", 150.55, 99);
                planet.AddWeapon(weapon1);
                planet.UpgradeWeapon("Name1");
                Assert.AreEqual(100, weapon1.DestructionLevel);
            }
            [Test]
            public void UpgradeNonExistWeaponTest()
            {
                Planet planet = new Planet("Name", 666.666);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Name1");
                }, "Name1 does not exist in the weapon repository of Name");
            }
            [Test]
            public void DestructOpponentTest()
            {
                Planet planet1 = new Planet("PL1", 666.666);
                Planet planet2 = new Planet("PL2", 3.3);
                Weapon weapon1 = new Weapon("W1", 1500.55, 99);
                Weapon weapon2 = new Weapon("W2", 15.55, 9);
                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);
                planet1.DestructOpponent(planet2);
                var actual = "PL2 is destructed!";
                var expected = planet1.DestructOpponent(planet2);
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void DestructOpponentNotSuccesTest()
            {
                Planet planet1 = new Planet("PL1", 66.666);
                Planet planet2 = new Planet("PL2", 333.3);
                Weapon weapon1 = new Weapon("W1", 150.55, 10);
                Weapon weapon2 = new Weapon("W2", 155.55, 10);
                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet1.DestructOpponent(planet2);
                }, "PL2 is too strong to declare war to!");
            }
        }
    }
}