﻿using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;
        protected Weapon(double price, int destructionLevel)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }

        public double Price { get; }

        public int DestructionLevel
        {
            get
            {
                return this.destructionLevel;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException
                        (ExceptionMessages.TooLowDestructionLevel);
                }
                if (value > 10)
                {
                    throw new ArgumentException
                        (ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
}