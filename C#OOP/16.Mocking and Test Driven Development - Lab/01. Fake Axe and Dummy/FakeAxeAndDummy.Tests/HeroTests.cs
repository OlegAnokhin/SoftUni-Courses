namespace FakeAxeAndDummy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void CreateHeroShouldReturnCorrectHero()
        {
            string expectedName = "Oleg";
            int expestedExperence = 0;
            Hero testHero = new Hero("Oleg");
            Assert.AreEqual(expectedName, testHero.Name);
            Assert.AreEqual(expestedExperence, testHero.Experience);
        }
        [Test]
        public void GainingXPShouldReturnCorrectValueIfAttackSuccessuful()
        {
            Hero testHero = new Hero("Oleg");
            Dummy testDummy = new Dummy(5, 5);
            int expestedExperence = 5;

            testHero.Attack(testDummy);
            int currenExperience = testHero.Experience;
            Assert.AreEqual(expestedExperence, currenExperience);
        }
    }
}
