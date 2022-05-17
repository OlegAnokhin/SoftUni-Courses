using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<Pump> pumpsQueue = new Queue<Pump>();
            for (int i = 0; i < pumps - 1; i++)
            {
                string data = Console.ReadLine();
                int amount = int.Parse(data.Split()[0]);
                int distance = int.Parse(data.Split()[1]);
                Pump pump = new Pump(i, amount, distance);
                pumpsQueue.Enqueue(pump);
            }
            int totalDistance = pumpsQueue.Sum(pump => pump.distance);
            int truckDistance = 0;
          //  int truckFuel = 0;
            while (true)
            {
                //Pump  currentPump = pumpsQueue.Peek();
                //truckFuel += currentPump.amount;
                //truckDistance += currentPump.distance;
                //pumpsQueue.Dequeue();
                int truckFuel = 0;
                foreach (Pump pump in pumpsQueue)
                {
                    truckFuel += pump.amount;

                }
            }

        }
    }
    class Pump
    {
        public int number;
        public int amount;
        public int distance;

        public Pump(int number, int amount, int distance)
        {
            this.number = number;
            this.amount = amount;
            this.distance = distance;
        }
    }
}
