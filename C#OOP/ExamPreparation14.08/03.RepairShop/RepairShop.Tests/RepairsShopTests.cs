using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void GarageNameShouldThrouException()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(null, 10);
                }, "Invalid garage name.");
                Assert.Throws<ArgumentNullException>(() =>
                {
                    var garage = new Garage(string.Empty, 10);
                }, "Invalid garage name.");
            }
            [Test]
            public void GarageNamePropertyShouldWorkCarrect()
            {
                const string garageName = "Name";
                var garage = new Garage(garageName, 10);
                Assert.AreEqual(garageName, garage.Name);
            }
            [Test]
            public void GarageMechanicsShouldThrowException()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Name", 0);
                }, "At least one mechanic must work in the garage.");
                Assert.Throws<ArgumentException>(() =>
                {
                    var garage = new Garage("Name", -5);
                }, "At least one mechanic must work in the garage.");
            }
            [Test]
            public void GarageMechanicsPropertyShouldWorkCorrect()
            {
                const int mechanics = 10;
                var garage = new Garage("Name", mechanics);
                Assert.AreEqual(mechanics, garage.MechanicsAvailable);
            }
            [Test]
            public void GarageAddCarShouldThrowExceptinWithNoMechanics()
            {
                var garage = new Garage("Name", 1);
                var firstCar = new Car("first", 10);
                var secondCar = new Car("second", 15);
                garage.AddCar(firstCar);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(secondCar);
                }, "No mechanic available.");
            }
            [Test]
            public void GarageAddCarShouldAddcorrectCar()
            {
                var garage = new Garage("Name", 3);
                var firstCar = new Car("first", 10);
                var secondCar = new Car("second", 15);
                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                Assert.AreEqual(2, garage.CarsInGarage);
            }
            [Test]
            public void GarageFixCarShouldThrowExceptionIfCarMissing()
            {
                var model = "Opel";
                var garage = new Garage("Name", 3);
                var firstCar = new Car("first", 10);
                var secondCar = new Car("second", 15);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar(model);
                }, $"The car {model} doesn't exist.");
            }
            [Test]
            public void GarageFixCarShouldReturnVixedCad()
            {
                var model = "Opel";
                var garage = new Garage("Name", 3);
                var firstCar = new Car("first", 10);
                var secondCar = new Car(model, 15);
                garage.AddCar(secondCar);
                var fixedCar = garage.FixCar(model);
                Assert.That(fixedCar.IsFixed, Is.True);
                Assert.That(fixedCar.CarModel, Is.EqualTo(model));
                Assert.That(fixedCar.NumberOfIssues, Is.EqualTo(0));
            }
            [Test]
            public void GarageRemoveFixetCarShouldThrowExceprionIfNoFixedCarsIsAvailable()
            {
                var model = "Opel";
                var garage = new Garage("Name", 3);
                var firstCar = new Car("first", 10);
                var secondCar = new Car(model, 15);
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }
            [Test]
            public void GarageRemoveFixedCarShouldRemoveFixedCars()
            {
                var model = "Opel";
                var garage = new Garage("Name", 3);
                var firstCar = new Car("first", 10);
                var secondCar = new Car(model, 15);
                var thirdCar = new Car("Reno", 30);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(model);
                var fixedCar = garage.RemoveFixedCar();
                Assert.That(fixedCar, Is.EqualTo(1));
                Assert.That(garage.CarsInGarage, Is.EqualTo(2));
            }
            [Test]
            public void GarageReportShouldWorkCerrect()
            {
                var model = "Opel";
                var garage = new Garage("Name", 3);
                var firstCar = new Car("first", 10);
                var secondCar = new Car(model, 15);
                var thirdCar = new Car("Reno", 30);

                garage.AddCar(firstCar);
                garage.AddCar(secondCar);
                garage.AddCar(thirdCar);
                garage.FixCar(model);
                var report = garage.Report();
                Assert.That(report, Is.EqualTo($"There are 2 which are not fixed: first, Reno."));
            }
        }
    }
}