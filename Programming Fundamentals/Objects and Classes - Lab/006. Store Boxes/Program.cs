using System;
using System.Collections.Generic;
using System.Linq;

namespace _006._Store_Boxes
{
    public class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public decimal Quantity { get; set; }
        public decimal PriceBox { get; set; }
        public decimal TotalPrice { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] splitParams = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string serialNumber = splitParams[0];
                string itemName = splitParams[1];
                decimal itemQuantity = decimal.Parse(splitParams[2]);
                decimal itemPrice = decimal.Parse(splitParams[3]);

                Box newBox = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = itemName,
                    Quantity = itemQuantity,
                    PriceBox = itemPrice,
                    TotalPrice = itemQuantity * itemPrice
                };

                boxes.Add(newBox);

                command = Console.ReadLine();
            }
            List<Box> sortedPrint = boxes.OrderByDescending(boxes => boxes
            .TotalPrice).ToList();

            foreach (Box box in sortedPrint)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item} - ${box.PriceBox:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.TotalPrice:f2}");
            }
        }
    }
}
