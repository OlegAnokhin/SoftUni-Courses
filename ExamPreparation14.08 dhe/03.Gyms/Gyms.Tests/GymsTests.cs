namespace Gyms.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class GymsTests
    {
        // Implement unit tests here
        [Test]
        [TestCase("Oleg")]
        [TestCase("Gosho")]
        public void TestConstructorShouldSetName(string fullName)
        {
            Athlete athlete = new Athlete(fullName);
            Assert.AreEqual(athlete.FullName, fullName);
        }
        [Test]
        public void TestIfConstructorSetAvailibleCorrect()
        {
            Athlete athlete = new Athlete("Oleg");
            athlete.IsInjured = true;
            Assert.IsTrue(athlete.IsInjured);
        }
        [TestCase("Gym", 1)]
        [TestCase("Gym", 10)]
        [TestCase("Gym", 999)]
        public void TestGypConstroctorWorksCorrect(string name, int capacity)
        {
            Gym Gym = new Gym(name, capacity);
            Assert.AreEqual(name, Gym.Name);
            Assert.AreEqual(capacity, Gym.Capacity);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void TestWithInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym Gym = new Gym(name, 1);
            }, "Invalid gym name.");
        }
        [TestCase(-1)]
        [TestCase(-11111)]
        [TestCase(-99999999)]
        public void TestWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym Gym = new Gym("Gym", capacity);
            }, "Invalid gym capacity.");
        }
        [Test]
        public void TestCountShouldReturnCorrectValue()
        {
            Gym gym = new Gym("Gym", 10);
            Athlete athlete1 = new Athlete("Oleg");
            Athlete athlete2 = new Athlete("Gosho");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            Assert.AreEqual(2, gym.Count);
        }
        [Test]
        public void AddAthleteMethodShouldThrowExceptionWhenGymIsFull()
        {
            Gym gym = new Gym("Gym", 1);
            Athlete athlete1 = new Athlete("Oleg");
            Athlete athlete2 = new Athlete("Gosho");
            gym.AddAthlete(athlete1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete2);
            }, "The gym is full.");
        }
        [Test]
        public void RemoveAthleteShouldPhisicalyRemove()
        {
            Gym gym = new Gym("Gym", 1);
            Athlete athlete1 = new Athlete("Oleg");
            gym.AddAthlete(athlete1);
            gym.RemoveAthlete("Oleg");
            Assert.AreEqual(0, gym.Count);
        }
        [Test]
        public void RmoveMethodShouldThrowExceptionWhenNemaNonExist()
        {
            Gym gym = new Gym("Gym", 1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Simo");
            }, "The athlete Simo doesn't exist.");
        }
        [Test]
        public void InjureAthleteShouldReturnAthleteInjured()
        {
            Gym gym = new Gym("Gym", 3);
            Athlete athlete = new Athlete("Oleg");
            gym.AddAthlete(athlete);
            var injuredAthlete = gym.InjureAthlete("Oleg");
            Assert.IsNotNull(injuredAthlete);
            Assert.AreEqual(true, injuredAthlete.IsInjured);
        }
        [Test]
        public void ReporTestShouldReturnCorrectly()
        {
            Gym gym = new Gym("Gym", 3);
            Athlete athlete1 = new Athlete("Oleg");
            Athlete athlete2 = new Athlete("Pesho");
            Athlete athlete3 = new Athlete("Gosho");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            var expected = "Active athletes at Gym: Oleg, Pesho, Gosho";
            Assert.AreEqual(expected, gym.Report());
        }
        [Test]
        public void ReporTestShouldReturnCorrectlyAfterIsInjured()
        {
            Gym gym = new Gym("Gym", 3);
            Athlete athlete1 = new Athlete("Oleg");
            Athlete athlete2 = new Athlete("Pesho");
            Athlete athlete3 = new Athlete("Gosho");
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.AddAthlete(athlete3);
            athlete1.IsInjured = true;
            athlete2.IsInjured = true;
            var expected = "Active athletes at Gym: Gosho";
            Assert.AreEqual(expected, gym.Report());
        }
    }
}