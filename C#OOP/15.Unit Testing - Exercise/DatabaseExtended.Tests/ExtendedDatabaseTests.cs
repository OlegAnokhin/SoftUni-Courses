namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person[] data;
        private Person Oleg;
        private Person Dani;

        [SetUp]
        public void SetUp()
        {
            this.database = new Database();
            this.data = new Person[17];
            Oleg = new Person(240486, "Oleg");
            Dani = new Person(080104, "Dani");
        }

        //[Test]
        //public void ConstructorShouldInitilizeCorrectCollection()
        //{
        //    Person[] expected = new Person[] { Oleg, Dani };
        //    Database database = new Database(expected);
        //    var actual = database.Take
        //    Assert.That(actual, Is.EqualTo(expected));
        //}  //  this.persons.Take(count).ToArray();
        [Test]
        public void TestNameGetter()
        {
            long expectedId = 240486;
            string expectedName = "Oleg";
            Person person = new Person(expectedId, expectedName);
            string actualName = person.UserName;
            Assert.AreEqual(expectedName, actualName,
                "Getter of the property Name should return the value of name!");
        }
        [Test]
        public void TestIdGetter()
        {
            long expectedId = 240486;
            string expectedName = "Oleg";
            Person person = new Person(expectedId, expectedName);
            long actualId = person.Id;
            Assert.AreEqual(expectedId, actualId,
                "Getter og the property Damage should retur the value of damage!");
        }
        [Test]
        public void AddMethodShouldAddValidPerson()
        {
            Person[] persons = new Person[] { Oleg, Dani };
            Database database = new Database(persons);
            Person newPerson = new Person(200287, "Petya");
            database.Add(newPerson);
            var actuall = database.Count;
            var expectedd = database.Count;
            Assert.AreEqual(expectedd, actuall);
        }
        [Test]
        public void AddRangeShouldAddData()
        {
            Person[] persons = new Person[] { Oleg, Dani };
            Database database = new Database(persons);
            long count = 1;
            for (long i = count + 1; i < 16; i++)
            {
                Person newPerson = new Person(212121 + count, "Petya" + count);
                database.Add(newPerson);
                count++;
            }
            var expected = database.Count;
            var actual = 16;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AddRangeShouldThrowAnExceprionWhenCountMore16()
        {
            int expectedLenght = 17;
            int actualLenght = this.data.Length;
            Assert.AreEqual(expectedLenght, actualLenght
            , "Provided data length should be in range [0..16]!");
        }
        [Test]
        public void AddSameUsernameShouldThrowAnException()
        {
            Person[] persons = new Person[] { Oleg, Dani };
            Database database = new Database(persons);
            Person newPerson = new Person(787878, "Oleg");
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(newPerson);
            }, "There is already user with this username!");
        }
        [Test]
        public void AddSameIdShouldThrowAnException()
        {
            Person[] persons = new Person[] { Oleg, Dani };
            Database database = new Database(persons);
            Person newPerson = new Person(240486, "Oleggg");
            Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(newPerson);
            }, "There is already user with this Id!");
        }
        //[Test]
        //public void RemoveShouldPhysicalyRemoveThePerson()
        //{
        //    Person[] persons = new Person[] { Oleg, Dani };
        //    Database database = new Database(persons);
        //    database.Remove();
        //    Person[] actual = database.Fetch();
        //    Person[] expected = new Person[] { Oleg };
        //    Assert.AreEqual(expected, actual);
        //}
        [Test]
        public void RemoveWithNoPersonInCollectionShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            }, "The collection in empty!");
        }
        [Test]
        public void FindByUsernameExistingPersonShouldReturnCorrectPerson()
        {
            Person[] persons = new Person[] { Oleg, Dani };
            Database database = new Database(persons);
            Person actual = database.FindByUsername("Oleg");
            Person expected = Oleg;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindByUsernameNonExistingPersonShouldShouldThrowExceprtion()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername("Gosho");
            }, "No user is present by this username!");
        }
        [Test]
        public void FindByUsernameWhenIsNullShouldThrowExceprtion()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(null);
            }, "Username parameter is null!");
        }
        [Test]
        public void FindByUsernameCaseSensitive()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername("OLEG");
            }, "The username it's a case sensitive!");
        }
        [Test]
        public void FindByIdExsistingPersonShouldReturnCorrectPerson()
        {
            Person[] persons = new Person[] { Oleg, Dani };
            Database database = new Database(persons);
            Person actual = database.FindById(240486);
            Person expected = Oleg;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindByIdNonExistingPersonShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(654565);
            }, "No user is present by this ID!");
        }
        [TestCase(-99999)]
        [TestCase(-1)]
        public void FindByIdWithNegativeNumberShouldThrowAnException(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(id);
            }, "Id should be a positive number!");
        }
        [Test]
        public void CountMutsReturnZeroWhenNoElements()
        {
            int actualCount = this.database.Count;
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, actualCount,
                "Count should be zero when there are no elements");
        }
    }
}