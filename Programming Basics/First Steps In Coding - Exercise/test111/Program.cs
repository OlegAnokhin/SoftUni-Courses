using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededProtectedNylon = double.Parse(Console.ReadLine());
            double neededPaint = double.Parse(Console.ReadLine());
            double paintThinner = double.Parse(Console.ReadLine());
            double hoursForWork = double.Parse(Console.ReadLine());

            double sumNylon = (neededProtectedNylon + 2) * 1.50;
            double sumPaint = (neededPaint + (neededPaint * 10 / 100)) * 14.50;
            double sumThinner = paintThinner * 5.00;
            double sumBags = 0.40;
            double sumAllMaterials = sumNylon + sumPaint + sumThinner + sumBags;
            double sumWorkers = (sumAllMaterials * 30 / 100) * hoursForWork;


            double finalSum = sumAllMaterials + sumWorkers;

            Console.WriteLine(finalSum);

        }
    }
}
