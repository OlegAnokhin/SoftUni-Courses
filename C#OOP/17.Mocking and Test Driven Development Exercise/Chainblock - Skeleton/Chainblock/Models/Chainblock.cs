namespace Chainblock.Models
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using Contracts;

    public class Chainblock : IChainblock
    {
        private readonly ICollection<ITransaction> transactions;
        public Chainblock()
        {
            this.transactions = new HashSet<ITransaction>();
        }
        public int Count 
            => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx))
            {
                throw new InvalidOperationException("You cannot add already existing transaction!");
            }
            this.transactions.Add(tx);
        }
        public bool Contains(ITransaction tx)
        {
            return this.transactions.Any(t => t.Id == tx.Id);
        }
        public bool Contains(int id)
        {
            return this.transactions.Any(t => t.Id == id);
        }
        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            ITransaction currentTransaction = this.transactions.FirstOrDefault(t => t.Id == id);
            if (currentTransaction == null)
            {
                throw new ArgumentException("You cannot change the status of non-existing transaction!");
            }
            currentTransaction.Status = newStatus;
        }
        public void RemoveTransactionById(int id)
        {
            ITransaction transactionToRemove = this.transactions.FirstOrDefault(t => t.Id == id);
            if (transactionToRemove == null)
            {
                throw new InvalidOperationException("You cannot delete a transaction that do not exist in our records!");
            }
            this.transactions.Remove(transactionToRemove);
        }
        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException("Transaction with the provided id does not exist in our records!");
            }
            return this.transactions.First(t => t.Id == id);
        }
        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            IEnumerable<ITransaction> transactionByStatus = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToArray();
            if (!transactionByStatus.Any())
            {
                throw new InvalidOperationException("There are no transaction in our records meeting your dasired transaction status!");
            }
            return transactionByStatus;
        }
        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> transactionSenders = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .Select(t => t.From)
                .ToArray();
            if (!transactionSenders.Any())
            {
                throw new InvalidOperationException("There are no transaction in our records meeting providet transaction status!");
            }
            return transactionSenders;
        }
        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            IEnumerable<string> transactionReceivers = this.transactions
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .Select(t => t.To)
                .ToArray();
            if (!transactionReceivers.Any())
            {
                throw new InvalidOperationException("There are no transaction in our records meeting providet transaction status!");
            }
            return transactionReceivers;
        }
        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToArray();
        }
        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            IEnumerable<ITransaction> senders = this.transactions
                .Where(n => n.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToArray();
            if (!senders.Any())
            {
                throw new InvalidOperationException("Transaction with the provided sender does not exist in our records!");
            }
            return senders;
        }
        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (ITransaction transaction in this.transactions)
            {
                yield return transaction;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
