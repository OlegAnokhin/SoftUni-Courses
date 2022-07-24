namespace _04.WildFarm.Models.Animals.Mammals
{
    using _04.WildFarm.Models.Foods;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        protected override IReadOnlyCollection<Type> PreferredFoods
            => new List<Type> { typeof(Meat) }.AsReadOnly();
        protected override double WeightMultiplier
            => TigerWeightMultiplier;
        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}