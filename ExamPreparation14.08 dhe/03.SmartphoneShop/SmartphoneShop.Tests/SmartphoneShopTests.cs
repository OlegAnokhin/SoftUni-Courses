using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(1000)]
        public void TestCapacityShouldReturnCorrectValue(int capacity)
        {
            Shop testShop = new Shop(capacity);
            Assert.That(testShop.Capacity, Is.EqualTo(capacity));
        }
        [TestCase(-1)]
        [TestCase(-1000)]
        public void TestCapacityShouldThrowExceptionWhenValueNotCorrect(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop testShop = new Shop(capacity);
            }, "Invalid capacity.");
        }
        [Test]
        public void TestCountShouldReturnCorrectValue()
        {
            Shop testShop = new Shop(10);
            Smartphone p1 = new Smartphone("PH1", 10);
            Smartphone p2 = new Smartphone("PH2", 20);
            Smartphone p3 = new Smartphone("PH3", 30);
            testShop.Add(p1);
            testShop.Add(p2);
            testShop.Add(p3);
            Assert.That(testShop.Count, Is.EqualTo(3));
        }
        [Test]
        public void TestAddMethodWhenNameExistInListShouldThrowException()
        {
            Shop testShop = new Shop(10);
            Smartphone p1 = new Smartphone("PH1", 10);
            testShop.Add(p1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.Add(p1);
            }, "The phone model PH1 already exist.");
        }
        [Test]
        public void TestAddMethodWhenListIsFullShouldThrowException()
        {
            Shop testShop = new Shop(1);
            Smartphone p1 = new Smartphone("PH1", 10);
            Smartphone p2 = new Smartphone("PH2", 20);
            testShop.Add(p1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.Add(p2);
            }, "The shop is full.");
        }
        [Test]
        public void TestRemoveMethodShouldReturnCorrectValue()
        {
            Shop testShop = new Shop(10);
            Smartphone p1 = new Smartphone("PH1", 10);
            Smartphone p2 = new Smartphone("PH2", 20);
            Smartphone p3 = new Smartphone("PH3", 30);
            testShop.Add(p1);
            testShop.Add(p2);
            testShop.Add(p3);
            testShop.Remove("PH3");

            Assert.That(testShop.Count, Is.EqualTo(2));
        }
        [Test]
        public void TestRemoveMethodWhenNonExistNameShouldThrowException()
        {
            Shop testShop = new Shop(1);
            Smartphone p1 = new Smartphone("PH1", 10);
            Smartphone p2 = new Smartphone("PH2", 20);
            testShop.Add(p1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.Remove("Apple");
            }, "The phone model Apple doesn't exist.");
        }
        [Test]
        public void TestPhoneMethodShouldReturnCorrectValue()
        {
            Shop testShop = new Shop(1);
            Smartphone p1 = new Smartphone("PH1", 10);
            testShop.Add(p1);
            testShop.TestPhone("PH1", 5);
            Assert.That(p1.CurrentBateryCharge, Is.EqualTo(5));
        }
        [Test]
        public void TestPhoneMethodWhenNonExistNameShouldThrowException()
        {
            Shop testShop = new Shop(1);
            Smartphone p1 = new Smartphone("PH1", 10);
            testShop.Add(p1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.TestPhone("Apple", 10);
            }, "The phone model Apple doesn't exist.");
        }
        [Test]
        public void TestPhoneMethodShouldThrowExceptionWhenCurrentBateryChargeSmallerOnBatteryUsage()
        {
            Shop testShop = new Shop(1);
            Smartphone p1 = new Smartphone("PH1", 10);
            testShop.Add(p1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.TestPhone("PH1", 100);
            }, "The phone model PH1 is low on batery.");
        }
        [Test]
        public void ChargePhoneMethodShouldReturnCorrectValue()
        {
            Shop testShop = new Shop(1);
            Smartphone p1 = new Smartphone("PH1", 100);
            testShop.Add(p1);
            testShop.TestPhone("PH1", 55);
            testShop.ChargePhone("PH1");
            Assert.That(p1.CurrentBateryCharge, Is.EqualTo(100));
        }
        [Test]
        public void ChargePhoneMethodWhenNonExistNameShouldThrowException()
        {
            Shop testShop = new Shop(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testShop.ChargePhone("Apple");
            }, "The phone model Apple doesn't exist.");
        }
    }
}