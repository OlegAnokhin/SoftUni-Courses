using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity = 100;
        private ICollection<Item> items;
        public Bag(int capacity)
        {
            this.Capacity = capacity;
            items = new List<Item>();
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                this.capacity = value;
            }
        }
        public int Load
        {
            get
            {
                return capacity;
            }
            set
            {
                items.Sum(w => w.Weight);
            }
        }
        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if (capacity < (item.Weight + items.Sum(w =>w.Weight)))
            {
                throw new InvalidOperationException
                    (ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }
        public Item GetItem(string name)
        {
            var itemToRemove = items.FirstOrDefault(n => n.GetType().Name == name);
            if (items.Count <= 0)
            {
                throw new InvalidOperationException
                    (ExceptionMessages.EmptyBag);
            }
            if (!items.Any(n => n.GetType().Name == name))
            {
                throw new ArgumentException
                    (string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }
            items.Remove(itemToRemove);
            return itemToRemove;
        }
    }
}