namespace FakeAxeAndDummy
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using FakeAxeAndDummy.Interfaces;

    public class Axe : IWeapon
    {
        private int attackPoints;
        private int durabilityPoints;

        public Axe(int attack, int durability)
        {
            this.attackPoints = attack;
            this.durabilityPoints = durability;
        }
        public int AttackPoint 
        { 
            get
            {
                return this.attackPoints;
            }
        }
        public int DurabilityPoints
        {
            get
            {
                return this.durabilityPoints;
            }
        }
        public void Attack(Dummy target)
        {
            if (this.durabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is brocken.");
            }
            target.TakeAttack(this.attackPoints);
            this.durabilityPoints -= 1;
        }
    }
}