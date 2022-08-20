using System;
using System.Text;
using System.Collections.Generic;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private int destructionLevel;
        private double price;
        protected Weapon(int destructionLevel, double price)
        {
            this.DestructionLevel = destructionLevel;
            this.Price = price;
        }

        public double Price { get;}
        public int DestructionLevel
        {
            get
            {
                return this.destructionLevel;
            }
            set
            {
                if (value <= 1)
                {
                    throw new ArgumentException
                        (ExceptionMessages.TooLowDestructionLevel);
                }
                else if (value > 10)
                {
                    throw new ArgumentException
                        (ExceptionMessages.TooHighDestructionLevel);
                }
                this.destructionLevel = value;
            }
        }
    }
}