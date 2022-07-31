namespace FakeAxeAndDummy.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void CreateDummyShouldReturnCorrectDummy()
        {
            Dummy testDummy = new Dummy(0, 5);

            int expectedHealt = 0;
            int expectedExpiriece = 5;

            Assert.AreEqual(expectedHealt, testDummy.Health);
            Assert.AreEqual(expectedExpiriece, testDummy.GiveExperience());
        }
    }
}
