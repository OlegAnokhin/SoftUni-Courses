namespace FakeAxeAndDummy.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void CreateAxeShouldReturnCorrectAxe()
        {
            Axe testAxe = new Axe(10, 10);

            int expectedAttackPoints = 10;
            int expestedDurabilityPoints = 10;

            Assert.AreEqual(expectedAttackPoints, testAxe.AttackPoint);
            Assert.AreEqual(expestedDurabilityPoints, testAxe.DurabilityPoints);
        }
    }

}
