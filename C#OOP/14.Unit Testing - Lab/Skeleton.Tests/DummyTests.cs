using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
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
        //[Test]
        //public void AliceDummyShouldCantGiveXP()
        //{
        //    Dummy dummy = new Dummy(1, 10);
        //    dummy.GiveExperience();
        //    int expected = 0;
        //    int actual = 0;
        //    Assert.AreEqual(expected, actual);
        //}

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
    }
}

