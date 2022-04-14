using System;
using System.Linq;

namespace EXE03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // not good solution 

            //string[] file = Console.ReadLine()
            //    .Split(':','\\')
            //    .ToArray();

            //string lastmove = file[file.Length-1];
            //string[] fileAndExtensioin = lastmove.Split('.');

            //string fileName = fileAndExtensioin[0];
            //string fileExtension = fileAndExtensioin[1];

            //Console.WriteLine($"File name: {fileName}");
            //Console.WriteLine($"File extension: {fileExtension}");

            // best string solution

            string filePath = Console.ReadLine();

            string fileInfo = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            int dotIndex = fileInfo.LastIndexOf('.');
            string fileName = fileInfo.Substring(0, dotIndex);
            string fileExt = fileInfo.Substring(dotIndex + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExt}");

            // Array solution

            //string filePath = Console.ReadLine();
            //string [] fileInfo = filePath.Split('\\').Last()
            //    .Split('.').ToArray();
            //string fileName = string.Join(".", fileInfo.Take(fileInfo.Length - 1));
            //string fileExt = fileInfo.Last();
            //Console.WriteLine($"File name: {fileName}");
            //Console.WriteLine($"File extension: {fileExt}");

        }
    }
}
