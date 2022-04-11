using System;

namespace _002ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int failedTimes = int.Parse(Console.ReadLine());
            double evaluationSum = 0;
            int evaluationCount = 0;
            string lastExercise = "";
            int failedCount = 0;

            string input = Console.ReadLine();
            int evaluation = 0;

            while (input != "Enough")
            {
                lastExercise = input;
                evaluation = int.Parse(Console.ReadLine());
                evaluationSum += evaluation;
                evaluationCount++;
                if (evaluation <= 4)
                {
                    failedCount ++;
                    if (failedTimes == failedCount)
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            if (input == "Enough")
            {
                Console.WriteLine($"Average score: {evaluationSum / evaluationCount:F2}");
                Console.WriteLine($"Number of problems: {evaluationCount}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }
            else
            {
                Console.WriteLine($"You need a break, {failedCount} poor grades.");
            }
        }
    }
}
