﻿using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        private int damage;
        protected Weapon(string name, int durability)
        {
            this.Name = name;
            this.Durability = durability;
        }
        public Weapon(string name, int durability, int damage) 
            : this(name, durability)
        {
            this.Name = name;
            this.Durability = durability;
            this.damage = damage;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public int Durability
        {
            get
            {
                return this.durability;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                this.durability = value;
            }
        }
        //private int Damage
        //{
        //    get
        //    {
        //        return this.damage;
        //    }
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException("Damage cannot be below 0");
        //        }
        //        this.damage = value;
        //    }
        //}
        public int DoDamage()
        {
            if (this.Durability == 0)
            {
                return 0;
            }
            this.Durability--;
            return this.damage;
        }
    }
}