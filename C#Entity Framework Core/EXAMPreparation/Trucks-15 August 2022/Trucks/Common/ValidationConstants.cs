namespace Trucks.Common
{
    public  static class ValidationConstants
    {
        //Truck
        public const int RegistrationNumberLength = 8;
        public const int VinNumberMaxLength = 17;
        public const string TruckRegistrationRegex = @"[A-Z]{2}\d{4}[A-Z]{2}";

        //Client
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 40;
        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;

        //Despatcher
        public const int DespatcherNameMinLength = 2;
        public const int DespatcherNameMaxLength = 40;

        //Tank
        public const int TankCapacityMinValue = 950;
        public const int TankCapacityMaxValue = 1420;

        //Cargo
        public const int CargoCapacityMinValue = 5000;
        public const int CargoCapacityMaxValue = 29000;


    }
}