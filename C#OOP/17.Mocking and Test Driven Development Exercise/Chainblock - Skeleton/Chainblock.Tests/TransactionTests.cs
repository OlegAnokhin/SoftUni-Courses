namespace Chainblock.Tests
{
    using System;
    using Models;
    using Contracts;
    using NUnit.Framework;
    [TestFixture]
    public class TransactionTests
    {
        [Test]
        public void ConstructorShouldInitializeTransactionCorrectly()
        {
            int expectedId = 1;
            TransactionStatus expectedStatus = TransactionStatus.Successful;
            string expectedFrom = "Pesho";
            string expectedTo = "Gosho";
            decimal expectedAmount = 50;
            ITransaction transaction = 
                new Transaction(expectedId, expectedStatus, expectedFrom, expectedTo, expectedAmount);
            Assert.AreEqual(expectedId, transaction.Id);
            Assert.AreEqual(expectedStatus, transaction.Status);
            Assert.AreEqual(expectedFrom, transaction.From);
            Assert.AreEqual(expectedTo, transaction.To);
            Assert.AreEqual(expectedAmount, transaction.Amount);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void CreatingTransactionWithEmptySenderShouldThrouwAnException(string sender)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction =
                new Transaction(5, TransactionStatus.Aborted, sender, "Pesho",  50);
            }, "Sender name cannot be null or whitespace!");
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase("     ")]
        public void CreatingTransactionWithEmptyReceiverShouldThrouwAnException(string receiver)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction =
                new Transaction(5, TransactionStatus.Aborted, "Pesho", receiver, 50);
            }, "Receiver name cannot be null or whitespace!");
        }
        [TestCase(-1000)]
        [TestCase(-1)]
        [TestCase(-0.0000000001)]
        [TestCase(0)]
        public void CreatingTransactionWhitZeroOrNegativeAmmountShouldThrowAnException(decimal amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ITransaction transaction =
                new Transaction(5, TransactionStatus.Aborted, "Pesho", "Gosho", amount);
            }, "Transaction amount must be a positive number!");
        }
    }
}
