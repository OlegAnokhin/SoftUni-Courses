namespace FakeAxeAndDummy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        private const int attackPoints = 2;
        private const int durabilityPoints = 2;
        private const int dummyHealth = 6;
        private const int dummyExpirience = 5;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(attackPoints, durabilityPoints);
            this.dummy = new Dummy(dummyHealth, dummyExpirience);
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
            int damageTaken = 6;
            dummy.TakeAttack(damageTaken);

            Assert.That(() => dummy.TakeAttack(damageTaken), 
                Throws.InvalidOperationException.With.Message
                .EqualTo("Dummy is dead."), "Inappropriate message");
        }
        [Test]
        public void DeadDummyCanGiveExperience()
        {
            dummy.TakeAttack(dummy.Health);
            Assert.That(dummy.GiveExperience(), Is
                .EqualTo(dummyExpirience), 
                "Dead dummy doesn't give correct amount of expirence");
        }
        [Test]
        public void AliveDummyCantGiveExperience()
        {
            int dummyHealth = 20;
            dummy = new Dummy(dummyHealth, dummyExpirience);
            Assert.That(() => dummy.GiveExperience(), Throws
                .InvalidOperationException, "Alive dummy changes experience");
        }
    }
}