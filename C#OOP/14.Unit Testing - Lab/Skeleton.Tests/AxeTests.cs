namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AddAxeShouldPhysiclyAddAxe()
        {
            Axe newAxe = new Axe(10, 10);
            Axe expected = new Axe(10, 10);
            Assert.AreEqual(expected.AttackPoints, newAxe.AttackPoints);
            Assert.AreEqual(expected.DurabilityPoints, newAxe.DurabilityPoints);
        }
        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change");
        }
        [Test]
        public void TestAxeWhenDurabilytiNegativShoudThrowException()
        {
            Axe axe = new Axe(1, 1);
            Dummy dummy = new Dummy(10, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
                axe.Attack(dummy);
            }, "Axe is broken.");
        }
    }
}
