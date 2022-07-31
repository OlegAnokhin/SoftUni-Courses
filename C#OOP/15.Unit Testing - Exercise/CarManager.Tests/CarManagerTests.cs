namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;
    using System.Reflection;
    using System.Linq;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string expectedMake = "Subaru";
            string expectedModel = "Outback";
            double expectedfuelConsumption = 5.5;
            double expectedfuelCapacity = 70;
            Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedfuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedfuelCapacity, car.FuelCapacity);
        }
        [TestCase(null)]
        [TestCase("")]
        public void MakeCannotBeNullOrEmptyShouldThrowException(string expectedMake)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(expectedMake, "model", 5, 20);
            }, "Make cannot be null or empty!");
        }
        [Test]
        public void TestMakeGetter()
        {
            string expectedMake = "Subaru";
            string expectedModel = "Outback";
            double expectedfuelConsumption = 5.5;
            double expectedfuelCapacity = 70;
            Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
            string actualMake = car.Make;
            Assert.AreEqual(expectedMake, actualMake,
                "Getter of the property Make should return the value of make!");
        }
        [TestCase(null)]
        [TestCase("")]
        public void ModelCannotBeNullOrEmptyShouldThrowException(string expectedModel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Make", expectedModel, 5, 20);
            }, "Model cannot be null or empty!");
        }
        [Test]
        public void TestModelGetter()
        {
            string expectedMake = "Subaru";
            string expectedModel = "Outback";
            double expectedfuelConsumption = 5.5;
            double expectedfuelCapacity = 70;
            Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
            string actualModel = car.Model;
            Assert.AreEqual(expectedModel, actualModel,
                "Getter of the property Model should return the value of model!");
        }
        [TestCase(- 9999999999)]
        [TestCase(- 0.0000001)]
        [TestCase(0)]
        public void FuelConsumptionCannotBeZeroOrNegativValue(double fuelCons)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Make", "Model", fuelCons, 20);
            }, "Fuel consumption cannot be zero or negative!");
        }
        [Test]
        public void TestFuelConsumptionGetter()
        {
            string expectedMake = "Subaru";
            string expectedModel = "Outback";
            double expectedfuelConsumption = 5.5;
            double expectedfuelCapacity = 70;
            Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
            double actualFCons = car.FuelConsumption;
            Assert.AreEqual(expectedfuelConsumption, actualFCons,
                "Getter of the property Consumption should return the value of consumption!");
        }
        [TestCase(-9999999999)]
        [TestCase(-0.0000001)]
        [TestCase(0)]
        public void FuelCapacityCannotBeZeroOrNegativValue(double fuelCap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Make", "Model", 5, fuelCap);
            }, "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void TestFuelCapacityGetter()
        {
            string expectedMake = "Subaru";
            string expectedModel = "Outback";
            double expectedfuelConsumption = 5.5;
            double expectedfuelCapacity = 70;
            Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
            double actualFCap = car.FuelCapacity;
            Assert.AreEqual(expectedfuelCapacity, actualFCap,
                "Getter of the property Capacity should return the value of capacity!");
        }

    }
}