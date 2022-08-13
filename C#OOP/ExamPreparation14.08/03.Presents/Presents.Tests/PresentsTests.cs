namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void PresentConstructoShouldWorcCorrect()
        {
            Present present = new Present("present", 50);
            Assert.AreEqual("present", present.Name);
            Assert.AreEqual(50, present.Magic);
        }
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            Bag testBag = new Bag();
            Assert.IsNotNull(testBag);
        }
        [Test]
        public void CreateMethodWhenNameExistInListShouldThrowException()
        {
            Bag testBag = new Bag();
            Present p1 = new Present("PH1", 10);
            testBag.Create(p1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                testBag.Create(p1);
            }, "This present already exists!");
        }
        [Test]
        public void CreateMethodShoudReturnMessage()
        {
            Bag testBag = new Bag();
            Present p1 = new Present("PH1", 10);
            testBag.Create(p1);
            Assert.AreEqual(p1, testBag.GetPresent("PH1"), "Successfully added present PH1.");
        }
        [Test]
        public void CreateMethodWhenNameNonExistInListShouldThrowException()
        {
            Bag testBag = new Bag();
            Assert.Throws<ArgumentNullException>(() =>
            {
                testBag.Create(null);
            }, "Present is null");
        }
        [Test]
        public void RemoveMethodShouldReturnCorrectValue()
        {
            Bag testBag = new Bag();
            Present p1 = new Present("PH1", 10);
            Present p2 = new Present("PH2", 20);
            Present p3 = new Present("PH3", 30);
            testBag.Create(p1);
            testBag.Create(p2);
            testBag.Create(p3);
            testBag.Remove(p2);
            Assert.That(testBag.GetPresents().Count, Is.EqualTo(2));
        }
        [Test]
        public void RemoveShouldReturnTrueIfIsSucceseful()
        {
            Bag testBag = new Bag();
            Present p1 = new Present("PH1", 10);
            testBag.Create(p1);
            bool result = testBag.Remove(p1);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void RemoveShouldReturnFalseWhenNotInBag()
        {
            Bag testBag = new Bag();
            Present p1 = new Present("PH1", 10);
            bool result = testBag.Remove(p1);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void GetPresentWithLeastMagicMethodShouldReturnCorrectValue()
        {
            Bag testBag = new Bag();
            Present p1 = new Present("PH1", 10);
            testBag.Create(p1);
            testBag.GetPresentWithLeastMagic();
            Assert.AreEqual(1, testBag.GetPresents().Count);
        }
        [Test]
        public void GetPresentMethodShouldReturnCorrectValue()
        {
            Bag testBag = new Bag();
            Present p1 = new Present("PH1", 100);
            testBag.Create(p1);
            var actual = testBag.GetPresent("PH1");
            Assert.AreEqual(p1, actual);
        }
    }
}