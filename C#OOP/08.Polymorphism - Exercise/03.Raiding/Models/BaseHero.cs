namespace _03.Raiding
{
    using _03.Raiding.Contracts;
    public abstract class BaseHero : ICastAbilitys
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; set; }
        public int Power { get; set; }
        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {this.Power}";
        }
    }
}