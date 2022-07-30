namespace Chainblock.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using NUnit.Framework;
    using Contracts;
    using Models;

    [TestFixture]
    public class ChainblockTests
    {
        private ITransaction defTransaction;
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            this.defTransaction = new Transaction(1, TransactionStatus.Successful, "Pesho", "Gosho", 50);
            this.chainblock = new Chainblock();
        }

        [Test]
        public void ChainblockShouldStoreTransactionsInPrivateCollection()
        {
            Type type = typeof(Chainblock);
            FieldInfo[] privateFields = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.IsPrivate)
                .ToArray();
            bool transactionsCollectionExists = privateFields
                .Any(fi => fi.FieldType == typeof(ICollection<ITransaction>));
            Assert.IsTrue(transactionsCollectionExists,
                "There must be private collection to store the transactions in the Chainblock!");
        }

        [Test]
        public void ConstructorShouldInitializeTheCollectionAndCountProperty()
        {
            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                                     f.FieldType == typeof(ICollection<ITransaction>));
            IChainblock chainblockTest = new Chainblock();
            object actualFieldValue = collectionField?.GetValue(chainblockTest);
            int actualCount = chainblockTest.Count;
            int expectedCount = 0;
            Assert.IsNotNull(actualFieldValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingTransactionShouldPhysicallyAddTheTransaction()
        {
            ITransaction transactionToAdd =
                new Transaction(1, TransactionStatus.Successful, "Pesho", "Gosho", 50);
            this.chainblock.Add(transactionToAdd);
            Type type = typeof(Chainblock);
            FieldInfo collectionField = type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.IsPrivate &&
                                     f.FieldType == typeof(ICollection<ITransaction>));
            ICollection<ITransaction> actualFieldValue = (ICollection<ITransaction>)
                collectionField?.GetValue(this.chainblock);
            bool addedTransactionExists = actualFieldValue.Contains(transactionToAdd);
            Assert.IsTrue(addedTransactionExists);
        }
    }
}
