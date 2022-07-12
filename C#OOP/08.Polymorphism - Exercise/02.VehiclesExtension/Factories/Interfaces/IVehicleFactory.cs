using _01.Vehicles.Model;

namespace _01.Vehicles.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption);
    }
}
