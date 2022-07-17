namespace _02.VehiclesExtension.Model
{
    using _01.Vehicles.Model;
    public class Bus : Vehicle
    {
        private const double BusFuelConsumptionIncrementWithAC = 1.4;

        public Bus(double fuelQuantity, double fuelConsumpion, double tankCapacity)
            : base(fuelQuantity, fuelConsumpion, tankCapacity)
        {
        }
        public override double FuelConsumpion
        {
            get
            {
                return base.FuelConsumpion;
            }
            protected set
            {
                if (!ItsEmpty)
                {
                    base.FuelConsumpion = value;
                }
                else
                {
                    base.FuelConsumpion = value + BusFuelConsumptionIncrementWithAC;
                }
            }
        }
    }
}
