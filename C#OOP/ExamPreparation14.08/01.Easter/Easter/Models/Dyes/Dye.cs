using Easter.Models.Dyes.Contracts;
using System;
using System.Text;
using System.Collections.Generic;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;
        public Dye(int power)
        {
            this.Power = power;
        }
        public int Power
        {
            get
            {
                return this.power;
            }
            set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                else
                {
                    this.power = value;
                }
            }
        }
        public void Use()
        {
            Power -= 10;
            if (Power < 0)
            {
                Power = 0;
            }            
        }
        public bool IsFinished()
        {
            if (Power <= 0)
            {
                return true;
            }
            return false;
        }
    }
}