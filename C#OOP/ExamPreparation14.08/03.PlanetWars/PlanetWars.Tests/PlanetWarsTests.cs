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
            public void PlanetConstructorShouldWorkCorrectly()
            {
                Planet planet = new Planet("PL", 666.666);
                Assert.AreEqual("PL", planet.Name);
                Assert.AreEqual(666.666, planet.Budget);
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void PlanetNameShouldThrowExceptionWhenIncorrectName()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet1 = new Planet("", 666.666);
                    Planet planet2 = new Planet(null, 666.666);
                }, "Invalid planet Name");
            }
            [Test]
            public void PlanetBudgetShouldThrowExceptionWhenIncorrectName()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet1 = new Planet("PL1", 0);
                    Planet planet2 = new Planet("PL2", -666.666);
                }, "Budget cannot drop below Zero!");
            }
            [Test]
            public void WeaponsCollectionShouldWorkCorrectly()
            {
                Planet planet = new Planet("PL", 666.666);
                Weapon weapon = new Weapon("Bazooka", 66.6, 6);
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void MilitaryPowerRatio()
            {
                Planet planet = new Planet("PL", 666.666);
                Weapon weapon1 = new Weapon("Bazooka", 6.6, 6);
                Weapon weapon2 = new Weapon("BigBazooka", 66.6, 6);
                Weapon weapon3 = new Weapon("BIGBazooka", 166.6, 6);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.AddWeapon(weapon3);
                Assert.AreEqual(18, planet.MilitaryPowerRatio);
            }
            [Test]
            public void ProfitTest()
            {
                Planet planet = new Planet("PL", 666.666);
                planet.Profit(111.111);
                Assert.AreEqual(777.777, planet.Budget);
            }
            [Test]
            public void SpendTest()
            {
                Planet planet = new Planet("PL", 666.6);
                planet.SpendFunds(111.1);
                Assert.AreEqual(555.5, planet.Budget);
            }
            [Test]
            public void SpendTestShouldThrowException()
            {
                Planet planet = new Planet("PL", 666.6);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(1111.1);
                }, "Not enough funds to finalize the deal.");
            }
            [Test]
            public void AddWeaponShouldThrowExceptionIfSameName()
            {
                Planet planet = new Planet("PL", 666.666);
                Weapon weapon1 = new Weapon("Bazooka", 6.6, 6);
                Weapon weapon2 = new Weapon("Bazooka", 6.6, 6);
                planet.AddWeapon(weapon1);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon2);
                }, "There is already a Bazooka weapon.");
            }
            [Test]
            public void RemoveShouldWorkCorrectly()
            {
                Planet planet = new Planet("PL", 666.666);
                Weapon weapon1 = new Weapon("Bazooka", 66.6, 6);
                Weapon weapon2 = new Weapon("BIGBazooka", 166.6, 6);
                planet.AddWeapon(weapon1);
                planet.AddWeapon(weapon2);
                planet.RemoveWeapon("Bazooka");
                Assert.AreEqual(1, planet.Weapons.Count);
            }
            [Test]
            public void UpgradeShouldWorkCorrectly()
            {
                Planet planet = new Planet("PL", 666.666);
                Weapon weapon1 = new Weapon("Bazooka", 66.6, 6);
                planet.AddWeapon(weapon1);
                planet.UpgradeWeapon("Bazooka");
                Assert.AreEqual(7, weapon1.DestructionLevel);
            }
            [Test]
            public void UpgradeShouldThrowException()
            {
                Planet planet = new Planet("PL", 666.666);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Bazooka");
                }, "Bazooka does not exist in the weapon repository of PL");
            }
            [Test]
            public void DestructOpponentWorkCorrectly()
            {
                Planet planet1 = new Planet("PL1", 666.666);
                Planet planet2 = new Planet("PL2", 666.666);
                Weapon weapon1 = new Weapon("Bazooka1", 66.6, 6);
                Weapon weapon2 = new Weapon("Bazooka2", 66.6, 1);
                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);
                var expected = "PL2 is destructed!";
                var actual = planet1.DestructOpponent(planet2);
                Assert.AreEqual(expected, actual);
            }
            [Test]
            public void DestructOpponentNotSuccessTest()
            {
                Planet planet1 = new Planet("PL1", 66.666);
                Planet planet2 = new Planet("PL2", 333.3);
                Weapon weapon1 = new Weapon("Bazooka1", 66.6, 6);
                Weapon weapon2 = new Weapon("Bazooka2", 65.6, 6);
                planet1.AddWeapon(weapon1);
                planet2.AddWeapon(weapon2);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet1.DestructOpponent(planet2);
                }, "PL2 is too strong to declare war to!");
            }
            [Test]
            public void WeaponIsNuclearTest()
            {
                Weapon weapon = new Weapon("Bazooka", 150.55, 99);
                weapon.IncreaseDestructionLevel();
                var expectedAfter = weapon.IsNuclear;
                Assert.AreEqual(true, expectedAfter);
            }





            //[Test]
            //public void WeaponConstructorTest()
            //{
            //    Weapon weapon = new Weapon("Name", 150.55, 99);
            //    Assert.AreEqual("Name", weapon.Name);
            //    Assert.AreEqual(150.55, weapon.Price);
            //    Assert.AreEqual(99, weapon.DestructionLevel);
            //}
            //[TestCase(-9999999)]
            //[TestCase(-1.00)]
            //public void WeaponConstructorPriceShouldThrowExceprion(double price)
            //{
            //    Assert.Throws<ArgumentException>(() =>
            //    {
            //        Weapon weapon = new Weapon("Name", price, 99);
            //    }, "Price cannot be negative.");
            //}
            //[Test]
            //public void WeaponConstructorIncreaseTest()
            //{
            //    Weapon weapon = new Weapon("Name", 150.55, 9);
            //    weapon.IncreaseDestructionLevel();
            //    Assert.AreEqual(10, weapon.DestructionLevel);
            //}
            //[Test]
            //public void WeaponIsNuclearTest()
            //{
            //    Weapon weapon = new Weapon("Name", 150.55, 99);
            //    weapon.IncreaseDestructionLevel();
            //    var expectedAfter = weapon.IsNuclear;
            //    Assert.AreEqual(true, expectedAfter);
            //}
            //[Test]
            //public void PlanetConstructorTest()
            //{
            //    Planet planet = new Planet("Name", 666.666);
            //    Assert.AreEqual("Name", planet.Name);
            //    Assert.AreEqual(666.666, planet.Budget);
            //    Assert.AreEqual(0, planet.Weapons.Count);
            //}
            //[Test]
            //public void PlanetNameIsNullOrEmpryShouldThrowException()
            //{
            //    Assert.Throws<ArgumentException>(() =>
            //    {
            //        new Planet("", 666.666);
            //    }, "Invalid planet Name");
            //    Assert.Throws<ArgumentException>(() =>
            //    {
            //        new Planet(null, 666.666);
            //    }, "Invalid planet Name");
            //}
            //[Test]
            //public void PlanetBudgetNegativeShouldThrowException()
            //{
            //    Assert.Throws<ArgumentException>(() =>
            //    {
            //        new Planet("Name", -666.666);
            //    }, "Budget cannot drop below Zero!");
            //}
            //[Test]
            //public void AddWeaponTest()
            //{
            //    Planet planet = new Planet("Name", 666.666);
            //    Weapon weapon1 = new Weapon("Name1", 150.55, 99);
            //    Weapon weapon2 = new Weapon("Name2", 160.55, 88);
            //    planet.AddWeapon(weapon1);
            //    planet.AddWeapon(weapon2);
            //    Assert.AreEqual(2, planet.Weapons.Count);
            //}
            //[Test]
            //public void MilitaryPowerRatioTest()
            //{
            //    Planet planet = new Planet("Name", 666.666);
            //    Weapon weapon1 = new Weapon("Name1", 150.55, 99);
            //    Weapon weapon2 = new Weapon("Name2", 160.55, 88);
            //    planet.AddWeapon(weapon1);
            //    planet.AddWeapon(weapon2);
            //    var actual = planet.MilitaryPowerRatio;
            //    Assert.AreEqual(187.0, actual);
            //}
            //[Test]
            //public void PlanetProfitTest()
            //{
            //    Planet planet = new Planet("Name", 616.666);
            //    planet.Profit(50.00);
            //    Assert.AreEqual(666.666, planet.Budget);
            //}
            //[Test]
            //public void SpendFundTest()
            //{
            //    Planet planet = new Planet("Name", 777);
            //    planet.SpendFunds(111);
            //    Assert.AreEqual(666, planet.Budget);
            //}
            //[Test]
            //public void SpendFundsShouldThrowException()
            //{
            //    var planet = new Planet("Name", 111);
            //    Assert.Throws<InvalidOperationException>(() =>
            //    {
            //        planet.SpendFunds(666);
            //    }, "Not enough funds to finalize the deal.");
            //}
            //[Test]
            //public void IncreaseDestructionLevevShouldIncrese()
            //{
            //    Weapon weapon1 = new Weapon("Name1", 150.55, 9);
            //    Weapon weapon2 = new Weapon("Name2", 160.55, 8);
            //    weapon1.IncreaseDestructionLevel();
            //    weapon2.IncreaseDestructionLevel();
            //    Assert.AreEqual(10, weapon1.DestructionLevel);
            //    Assert.AreEqual(9, weapon2.DestructionLevel);
            //}
            //[Test]
            //public void IsNuclearShouldWorkCorrect()
            //{
            //    Weapon weapon1 = new Weapon("Name1", 150.55, 9);
            //    Weapon weapon2 = new Weapon("Name2", 160.55, 18);
            //    Assert.IsFalse(weapon1.IsNuclear);
            //    Assert.IsTrue(weapon2.IsNuclear);
            //}
            //[Test]
            //public void RemoveWeaponTest()
            //{
            //    Planet planet = new Planet("Name", 666.666);
            //    Weapon weapon1 = new Weapon("Name1", 150.55, 99);
            //    Weapon weapon2 = new Weapon("Name2", 160.55, 88);
            //    planet.AddWeapon(weapon1);
            //    planet.AddWeapon(weapon2);
            //    planet.RemoveWeapon("Name2");
            //    Assert.AreEqual(1, planet.Weapons.Count);
            //}
            //[Test]
            //public void UpgradeWeaponTest()
            //{
            //    Planet planet = new Planet("Name", 666.666);
            //    Weapon weapon1 = new Weapon("Name1", 150.55, 99);
            //    planet.AddWeapon(weapon1);
            //    planet.UpgradeWeapon("Name1");
            //    Assert.AreEqual(100, weapon1.DestructionLevel);
            //}
            //[Test]
            //public void UpgradeNonExistWeaponTest()
            //{
            //    Planet planet = new Planet("Name", 666.666);
            //    Assert.Throws<InvalidOperationException>(() =>
            //    {
            //        planet.UpgradeWeapon("Name1");
            //    }, "Name1 does not exist in the weapon repository of Name");
            //}
            //[Test]
            //public void DestructOpponentTest()
            //{
            //    Planet planet1 = new Planet("PL1", 666.666);
            //    Planet planet2 = new Planet("PL2", 3.3);
            //    Weapon weapon1 = new Weapon("W1", 1500.55, 99);
            //    Weapon weapon2 = new Weapon("W2", 15.55, 9);
            //    planet1.AddWeapon(weapon1);
            //    planet2.AddWeapon(weapon2);
            //    planet1.DestructOpponent(planet2);
            //    var actual = "PL2 is destructed!";
            //    var expected = planet1.DestructOpponent(planet2);
            //    Assert.AreEqual(expected, actual);
            //}
            //[Test]
            //public void DestructOpponentNotSuccesTest()
            //{
            //    Planet planet1 = new Planet("PL1", 66.666);
            //    Planet planet2 = new Planet("PL2", 333.3);
            //    Weapon weapon1 = new Weapon("W1", 150.55, 10);
            //    Weapon weapon2 = new Weapon("W2", 155.55, 10);
            //    planet1.AddWeapon(weapon1);
            //    planet2.AddWeapon(weapon2);
            //    Assert.Throws<InvalidOperationException>(() =>
            //    {
            //        planet1.DestructOpponent(planet2);
            //    }, "PL2 is too strong to declare war to!");
            //}
        }
    }
}