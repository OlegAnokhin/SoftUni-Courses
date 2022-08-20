namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        [TestCase("Riba1", 1)]
        [TestCase("Riba2", 10)]
        [TestCase("Riba3", 999)]
        public void TestConstroctorWorksCorrect(string name, int capacity)
        {
            Aquarium aquarium = new Aquarium(name, capacity);
            Assert.AreEqual(name, aquarium.Name);
            Assert.AreEqual(capacity, aquarium.Capacity);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestWithInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name, 1);
            }, "Invalid aquarium name!");
        }
        [Test]
        [TestCase(-1)]
        [TestCase(-11111)]
        [TestCase(-99999999)]
        public void TestWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("riba", capacity);
            }, "Invalid aquarium capacity!");
        }
        [Test]
        [TestCase(1)]
        [TestCase(5)]
        public void TestAddingFish(int capacity)
        {
            var aquarium = new Aquarium("Riba", capacity);
            Fish fish = new Fish("Ribok");
            aquarium.Add(fish);
            int expCount = 1;
            int actCount = aquarium.Count;
            Assert.AreEqual(expCount, actCount);
        }
        [Test]
        public void TestAddingFishWhenAquaIsFull()
        {
            Aquarium aquarium = new Aquarium("ribi", 2);
            Fish f1 = new Fish("R1");
            Fish f2 = new Fish("R2");
            aquarium.Add(f1);
            aquarium.Add(f2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(f2);
            }, "Aquarium is full!");
        }
        [Test]
        public void TestToRemoveFish()
        {
            string name = "riba1";
            Aquarium aquarium = new Aquarium("ribi", 3);
            Fish f1 = new Fish(name);
            Fish f2 = new Fish("R2");
            aquarium.Add(f1);
            aquarium.Add(f2);
            aquarium.RemoveFish(name);
            int expected = 1;
            int actual = aquarium.Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestRemovingWhenNonExistingFish()
        {
            string fish = "NonExisting";
            Aquarium aquarium = new Aquarium("ribi", 2);
            Fish f1 = new Fish("R1");
            Fish f2 = new Fish("R2");
            aquarium.Add(f1);
            aquarium.Add(f2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish(fish);
            }, $"Fish with the name {fish} doesn't exist!");
        }
        [Test]
        public void TestSellingFish()
        {
            string name = "riba1";
            Aquarium aquarium = new Aquarium("ribi", 3);
            Fish f1 = new Fish(name);
            Fish f2 = new Fish("R2");
            aquarium.Add(f1);
            aquarium.Add(f2);
            Fish fish = aquarium.SellFish(name);
            Assert.IsFalse(fish.Available);
        }
        [Test]
        public void TestSellingNonExistingFish()
        {
            string fish = "NonExisting";
            Aquarium aquarium = new Aquarium("ribi", 2);
            Fish f1 = new Fish("R1");
            Fish f2 = new Fish("R2");
            aquarium.Add(f1);
            aquarium.Add(f2);
            Assert.Throws<InvalidOperationException>(() =>
            {
                Fish fh = aquarium.SellFish(fish);
            }, $"Fish with the name {fish} doesn't exist!");
        }
        [Test]
        public void TestReportWithManyLines()
        {
            Aquarium aquarium = new Aquarium("ribi", 2);
            Fish f1 = new Fish("R1");
            Fish f2 = new Fish("R2");
            aquarium.Add(f1);
            aquarium.Add(f2);
            string actual = aquarium.Report();
            string expected = $"Fish available at ribi: R1, R2";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestReportWithOneFish()
        {
            Aquarium aquarium = new Aquarium("ribi", 2);
            Fish f1 = new Fish("R1");
            aquarium.Add(f1);
            string actual = aquarium.Report();
            string expected = $"Fish available at ribi: R1";
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestReportWithEmptyAquarium()
        {
            Aquarium aquarium = new Aquarium("ribi", 2);
            string actual = aquarium.Report();
            string expected = $"Fish available at ribi: ";
            Assert.AreEqual(expected, actual);

        }
    }
}
