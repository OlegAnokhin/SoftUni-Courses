using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Aquariums.Tests
{
    [TestFixture]
    public class FishTests
    {
        [Test]
        [TestCase("Nemo")]
        [TestCase("Riba1")]
        [TestCase("Riba2")]
        public void TestConstructorShouldSetName(string name)
        {
            Fish fish = new Fish(name);
            Assert.AreEqual(fish.Name, name);
        }
        [Test]
        public void TestIfConstructorSetAvailibleCorrect()
        {
            string expName = "Riba123";
            Fish fish = new Fish(expName);
            Assert.AreEqual(fish.Name, expName);
            Assert.IsTrue(fish.Available);            
        }
    }
}
