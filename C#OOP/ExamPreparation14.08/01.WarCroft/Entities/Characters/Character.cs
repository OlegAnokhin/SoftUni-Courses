using System;
using System.Collections.Generic;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
		private double baseHealth;
		private double health;
		private double baseArmor;
		private double armor;
		private double abilityPoints;
		private Bag bag;
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = BaseHealth;
            this.BaseArmor = armor;
            this.Armor = BaseArmor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }
        public string Name
        {
			get
            {
				return name;
            }
			set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException
						(ExceptionMessages.CharacterNameInvalid);
                }
				name = value;
            }
        }
        public double BaseHealth
        {
            get
            {
                return baseHealth;
            }
            set
            {
                this.baseHealth = value;
            }
        }
        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (baseHealth < value)
                {
                    value = baseHealth;
                }
                health = value;
            }
        }
        public double BaseArmor
        {
            get
            {
                return baseArmor;
            }
            set
            {
                baseArmor = value;
            }
        }
        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (baseArmor < value)
                {
                    value = baseArmor;
                }
                armor = value;
            }
        }
        public double AbilityPoints {get; set; }
        public Bag Bag { get; set; }
        public bool IsAlive { get; set; } = true;
		protected internal void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double remainingPoints = 0;
            if (Armor - hitPoints < 0)
            {
                remainingPoints = Armor - hitPoints;
            }
                Armor -= hitPoints;
                Health -= Math.Abs(remainingPoints);
            if (Health <= 0)
            {
                IsAlive = false;
            }
        }
        public void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }
    }
}