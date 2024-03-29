﻿using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private const decimal PriceMinValue = 0;
        private string name;
        private string species;
        private decimal price;
        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }
        public string Name
        {
            get { return this.name; }
        private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                this.name = value;
            }
        }
        public string Species
        {
            get { return this.species; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException(ExceptionMessages.InvalidFishSpecies);
                }
                this.species = value;
            }
        }
        public int Size { get; protected set; }
        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value <= PriceMinValue)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }
                this.price=value;
            }
        }
        public abstract void Eat();
    }
}