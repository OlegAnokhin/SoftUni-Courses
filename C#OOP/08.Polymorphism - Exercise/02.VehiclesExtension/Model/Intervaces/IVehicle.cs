namespace _01.Vehicles.Model.Intervaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumpion { get; }
        string Drive(double distance);
        void Refuel(double liters);

    }
}