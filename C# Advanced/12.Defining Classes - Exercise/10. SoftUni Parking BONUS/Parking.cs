using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public List<Car> Cars { get { return cars; } set { cars = value; } }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return Cars.Count; } }

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }
        public string AddCar(Car addedCar)
        {
            bool canAddCar = true;
            foreach (Car car in Cars)
            {
                if (car.RegistrationNumber == addedCar.RegistrationNumber)
                {
                    canAddCar = false;
                    return "Car with that registration number, already exists!";
                }
            }
            if (Cars.Count + 1 > Capacity)
            {
                canAddCar = false;
                return "Parking is full!";
            }
            if (canAddCar)
            {
                Cars.Add(addedCar);
                return $"Successfully added new car {addedCar.Make} {addedCar.RegistrationNumber}";
            }
            return "";
        }
        public string RemoveCar (string registrationNumber)
        {
            bool isAvailable = false;
            foreach (Car car in Cars)
            {
                if (car.RegistrationNumber == registrationNumber)
                {
                    isAvailable = true;
                }
            }
            if (!isAvailable)
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = Cars.First(car => car.RegistrationNumber == registrationNumber);
                Cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar (string registrationNumber)
        {
            return Cars.First(car => car.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber (List<string> RegistrationNumbers)
        {
            foreach (string registrationNumber in RegistrationNumbers)
            {
                RemoveCar(registrationNumber);
            }
        }
    }
}

