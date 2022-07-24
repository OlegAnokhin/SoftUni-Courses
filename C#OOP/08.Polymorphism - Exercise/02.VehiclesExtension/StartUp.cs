namespace _02.VehiclesExtension
{
    using System;

    public class Startup
    {
        private static Car car;
        private static Truck truck;
        private static Bus bus;

        public static void Main()
        {
            ParseInput();
            int numberOfCommands = int.Parse(Console.ReadLine());
            ParseCommand(numberOfCommands);
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ParseInput()
        {
            string[] carData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] truckData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] busData = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


            car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
            truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
            bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));
        }

        private static void ParseCommand(int numberOfCommands)
        {
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandParts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = commandParts[0];
                switch (command)
                {
                    case "Drive":
                        DriveCommand(commandParts);
                        break;
                    case "Refuel":
                        RefuelCommand(commandParts);
                        break;
                    case "DriveEmpty":
                        bus.DriveEmpty(double.Parse(commandParts[2]));
                        break;
                }
            }
        }

        private static void RefuelCommand(string[] commandParts)
        {
            string vehicle = commandParts[1];
            switch (vehicle)
            {
                case "Car":
                    car.Refuel(double.Parse(commandParts[2]));
                    break;
                case "Truck":
                    truck.Refuel(double.Parse(commandParts[2]));
                    break;
                case "Bus":
                    bus.Refuel(double.Parse(commandParts[2]));
                    break;
            }
        }

        private static void DriveCommand(string[] commandParts)
        {
            string vehicle = commandParts[1];
            switch (vehicle)
            {
                case "Car":
                    car.Drive(double.Parse(commandParts[2]));
                    break;
                case "Truck":
                    truck.Drive(double.Parse(commandParts[2]));
                    break;
                case "Bus":
                    bus.Drive(double.Parse(commandParts[2]));
                    break;
            }
        }
    }
}

//Car 30 0.04 70
//Truck 100 0.5 300
//Bus 40 0.3 150
//8
//Refuel Car -10
//Refuel Truck 0
//Refuel Car 10
//Refuel Car 300
//Drive Bus 10
//Refuel Bus 1000
//DriveEmpty Bus 100
//Refuel Truck 1000