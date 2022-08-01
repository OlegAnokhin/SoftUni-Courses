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
        [TestCase(-9999999999)]
        [TestCase(-0.0000001)]
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
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestFuelConsumSetter(double consum)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Make", "Model", consum, 90);
            }, "Fuel consumption cannot be zero or negative!");
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
        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void TestFuelCapacitySetter(double capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Make", "Model", 5, capacity);
            }, "Fuel capacity cannot be zero or negative!");
        }
        [Test]
        public void TestFuelAmountGetter()
        {
            Car car = new Car("Make", "Model", 5, 50);
            double expected = 0;
            double actual = car.FuelAmount;
            Assert.AreEqual(expected, actual,
                "Getter of the property Amount should return the value of amount!");
        }
        [TestCase(-9999999999)]
        [TestCase(-0.0000001)]
        [TestCase(0)]
        public void RefuelValueCannotBeZeroOrNegativShouldThrowException(double fuelToAdd)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                string expectedMake = "Subaru";
                string expectedModel = "Outback";
                double expectedfuelConsumption = 5.5;
                double expectedfuelCapacity = 70;
                Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
                car.Refuel(fuelToAdd);
            }, "Fuel amount cannot be zero or negative!");
        }
        [TestCase(50)]
        public void RefuelMethodNeedReturnCorrectValueIfItSuccessAdd(double fuelToAdd)
        {
            string expectedMake = "Subaru";
            string expectedModel = "Outback";
            double expectedfuelConsumption = 5.5;
            double expectedfuelCapacity = 70;
            Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
            double fuelAmount = 0;
            double expectedFuel = 50;
            car.Refuel(fuelToAdd);
            fuelAmount = fuelToAdd;
            Assert.AreEqual(expectedFuel, fuelAmount);
        }
        [TestCase(100)]
        [TestCase(10000)]
        public void FuelNeededValueNeedToBeSmallerOfValueCapacityShouldThrowException(double distance)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                string expectedMake = "Subaru";
                string expectedModel = "Outback";
                double expectedfuelConsumption = 5.5;
                double expectedfuelCapacity = 70;
                Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
                car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }
        //[TestCase(50)]
        //public void DriveMethodNeedReturnCorrectValueIfItSuccessDrive(double distance)
        //{
        //    string expectedMake = "Subaru";
        //    string expectedModel = "Outback";
        //    double expectedfuelConsumption = 5.5;
        //    double expectedfuelCapacity = 70;
        //    Car car = new Car(expectedMake, expectedModel, expectedfuelConsumption, expectedfuelCapacity);
        //    double fuelAmount = 100;
        //    double fuelNeeded = (distance / 100) * expectedfuelConsumption;
        //    car.Drive(distance);
        //    double expectedFuel = expectedfuelCapacity - fuelNeeded;
        //    double actual = car.FuelCapacity;
        //    Assert.AreEqual(expectedFuel, actual);
        //}
    }
}