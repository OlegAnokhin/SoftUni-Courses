////using System;
////using System.Collections.Generic;
////using System.Linq;

////namespace Associative_Arrays___Lab
////{
////    internal class Program
////    {
////        class Student
////        {
////            public Student(string name, int age, bool isActive)
////            {
////                Name = name;
////                Age = age;
////                IsActiv = isActive;
////            }

////            public string Name { get; set; }
////            public int Age { get; set; }
////            public bool IsActiv { get; set; }
////        }


////        static void Main(string[] args)
////        {
////            var firststudent = new Student("Ivan", 15, true);
////            var secondStudent = new Student("Stamat", 16, true);
////            var threeStudent = new Student("Mariq", 17, true);
////            var fourStudent = new Student("Mariq", 13, true);
////            var fiveStudent = new Student("Eli", 15, false);
////            List<Student> students = new List<Student>()
////        {
////            firststudent,
////            secondStudent,
////            threeStudent,
////            fourStudent,
////            fiveStudent
////        };

////            // studenst > 14
////            var above14Student = students.Where(student => student.Age > 14)
////                .Select(students => students.Name)
////                .ToArray();
////            Console.WriteLine(String.Join(" ", above14Student));

////            // active student
////            var allactiveStudents = students.Where(student => student.IsActiv)
////                .Select(students => students.Name)
////                .ToArray();
////            Console.WriteLine(String.Join(" ", allactiveStudents));

////            // inactive student
////            var allinActiveStudents = students.Where(student => !student.IsActiv)
////                .Select(students => students.Name)
////                .ToArray();
////            Console.WriteLine(String.Join(" ", allinActiveStudents));

////            // average age of all students.
////            var averageAge = students
////                .Average(student => student.Age);

////            Console.WriteLine(String.Join(" ", averageAge));

////            // Are there any inactive students?
////            bool inactiveExist = students
////                .Any(student => !student.IsActiv);
////            Console.WriteLine(String.Join(" ", inactiveExist));


////            int inactiveCount = students
////                .Count(students => !students.IsActiv);
////            Console.WriteLine(String.Join(" ", inactiveCount));


////        }
////    }
////}

//using System;
//using System.Linq;
//using System.Collections.Generic;

//namespace E_06._Vehicle_Catalogue
//{
//    internal class Program
//    {
//        class Catalog
//        {
//            public Catalog(string type, string model, string color, int horsePower)
//            {
//                this.Type = type;
//                this.Model = model;
//                this.Color = color;
//                this.HorsePower = horsePower;
//            }
//            public string Type { get; set; }
//            public string Model { get; set; }
//            public string Color { get; set; }
//            public int HorsePower { get; set; }

//            public override string ToString()
//            {
//                return $"Type: {Type} Model: {Model} Color: {Color} Horsepower: {HorsePower}";
//                //string vehicleStr = $"Type: {(this.Type == "car" ? "Car" : "Truck")}{Environment.NewLine}" +
//                //               $"Model: {this.Model}{Environment.NewLine}" +
//                //               $"Color: {this.Color}{Environment.NewLine}" +
//                //               $"Horsepower: {this.HorsePower}";

//                //return vehicleStr;
//            }
//        }
//        static void Main(string[] args)
//        {
//            List<Catalog> catalogOfVehicles = new List<Catalog>();

//            string command;
//            while ((command = Console.ReadLine()) != "End")
//            {
//                string[] vehicleArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//                string type = vehicleArg[0];
//                string model = vehicleArg[1];
//                string color = vehicleArg[2];
//                int horsePower = int.Parse(vehicleArg[3]);

//                Catalog currVehicl = new Catalog(type, model, color, horsePower);
//                catalogOfVehicles.Add(currVehicl);
//            }

//            string modelVehicle;
//            while ((modelVehicle = Console.ReadLine()) != "Close the Catalogue")
//            {
//                Console.WriteLine(catalogOfVehicles.Find(x => x.Model == modelVehicle));
//            }

//            var car = catalogOfVehicles.Where(x => x.Type == "car").ToList();
//            var truck = catalogOfVehicles.Where(x => x.Type == "truck").ToList();
//            double tuckPower = truck.Average(x => x.HorsePower);
//            double carPower = car.Average(x => x.HorsePower);

//            if (car.Count > 0 && truck.Count > 0)
//            {
//                Console.WriteLine($"Cars have average horsepower of: {carPower:f2}.");
//                Console.WriteLine($"Trucks have average horsepower of: {tuckPower:f2}.");
//            }

//            if (truck.Count == 0)
//            {
//                Console.WriteLine($"Cars have average horsepower of: {car:f2}.");
//                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
//            }
//            if (car.Count == 0)
//            {
//                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
//                Console.WriteLine($"Trucks have average horsepower of: {tuckPower:f2}.");
//            }
//        }
//    }
//}

using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    class Cars
    {
        public Cars(string typeOfVehicle, string model, string color, double horsePower)
        {
            TypeOfVehicle = typeOfVehicle;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string TypeOfVehicle { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            return $"Type: {TypeOfVehicle} Model: {Model} Color: {Color} Horsepower: {HorsePower}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cars> catalog = new List<Cars>();
            double counterCars = 0;
            double counterTrucks = 0;
            double powerCars = 0;
            double powerTrucks = 0;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }
                string typeOfVehicle = input[0];
                string model = input[1];
                string color = input[2];
                double horsePower = double.Parse(input[3]);

                if (typeOfVehicle == "car")
                {
                    typeOfVehicle = "Car";
                    counterCars++;
                    powerCars += horsePower;
                }
                if (typeOfVehicle == "truck")
                {
                    typeOfVehicle = "Truck";
                    counterTrucks++;
                    powerTrucks += horsePower;
                }
                Cars cars = new Cars(typeOfVehicle, model, color, horsePower);
                catalog.Add(cars);
            }
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Close the Catalogue")
                {
                    double averageCarPower = powerCars / counterCars;
                    double averageTrucksPower = powerTrucks / counterTrucks;

                    if (averageCarPower > 0 && averageTrucksPower > 0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {averageCarPower:f2}.");
                        Console.WriteLine($"Trucks have average horsepower of: {averageTrucksPower:f2}.");
                        break;
                    }
                    else if (counterCars == 0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
                        Console.WriteLine($"Trucks have average horsepower of: {averageTrucksPower:f2}.");
                        break;
                    }
                    else if (counterTrucks == 0)
                    {
                        Console.WriteLine($"Cars have average horsepower of: {averageCarPower:f2}.");
                        Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
                        break;
                    }
                }
                foreach (var car in catalog)
                {
                    if (car.Model == input)
                    {
                        Console.WriteLine($"Type: {car.TypeOfVehicle}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.HorsePower}");
                    }
                }
            }
        }
    }
}