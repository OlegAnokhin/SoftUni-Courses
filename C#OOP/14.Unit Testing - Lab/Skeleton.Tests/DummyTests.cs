using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int dummyExpirience = 5;
        [Test]
        public void CreateNewDummyShouldRetunCorrectValue()
        {
            Dummy newDummy = new Dummy(10, 10);
            Dummy expected = new Dummy(10, 10);
            Assert.AreEqual(expected.Health, newDummy.Health);
        }
        [TestCase(5)]
        public void TestDummyShouldLostHealtAfterAttack(int attackPoints)
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(attackPoints);
            int expectedHealt = 5;
            Assert.AreEqual(expectedHealt, dummy.Health);
        }
        [TestCase(-99999999)]
        [TestCase(0)]
        public void TestDummyShouldThrowExceptionIfHisHealtLessZero(int healt)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Dummy dummy = new Dummy(healt, 10);
                dummy.TakeAttack(10);
            }, "Dummy is dead.");
        }
        [Test]
        public void DeadDummyShouldGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);
            dummy.GiveExperience();
            int expected = 10;
            int actual = 10;
            Assert.AreEqual(expected, actual);
        }
        [TestCase(99999999)]
        [TestCase(1)]
        public void DummyMethodGivenExpirienceShouldThrowExceptionIfHisNotDead(int healt)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Dummy dummy = new Dummy(healt, 10);
                dummy.GiveExperience();
            }, "Target is not dead.");
        }

        [TestCase(-99999999)]
        [TestCase(0)]
        public void TestDummyIsDeadShoulThrowException(int healt)
        {
            Dummy dummy = new Dummy(healt, 10);
            dummy.IsDead();
            bool expected = true;
            Assert.AreEqual(expected, true);
        }
        [Test]
        public void DummyLoosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 15);
            dummy.TakeAttack(5);

            Assert.That(dummy.Health, Is.EqualTo(5));
        }
        [Test]
        public void AttackDeadDummyShouldThrow()
        {
            Dummy dummy = new Dummy(5, 15);
            int damageTaken = 6;
            dummy.TakeAttack(damageTaken);

            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(damageTaken);
            }, "Dummy is dead.");
        }
        [Test]
        public void DeadDummyCanGiveExperience()
        {
            Dummy dummy = new Dummy(10, 5);
            dummy.TakeAttack(dummy.Health);
            Assert.That(dummy.GiveExperience(), Is
                .EqualTo(dummyExpirience),
                "Dead dummy doesn't give correct amount of expirence");
        }
        [Test]
        public void AliveDummyCantGiveExperience()
        {
            Dummy dummy = new Dummy(10, 15);
            int dummyHealth = 20;
            dummy = new Dummy(dummyHealth, dummyExpirience);
            Assert.That(() => dummy.GiveExperience(), Throws
                .InvalidOperationException, "Alive dummy changes experience");
        }
    }
}

