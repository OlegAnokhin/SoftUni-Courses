namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main(string[] args)
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            var firstReader = new StreamReader(firstInputFilePath);
            using (firstReader)
            {
                var secondReader = new StreamReader(secondInputFilePath);
                using (secondReader)
                {
                    var writer = new StreamWriter(outputFilePath);
                    using (writer)
                    {
                        string firstLine = firstReader.ReadLine();
                        string secondLine = secondReader.ReadLine();
                        while (firstLine != null && secondLine != null)
                        {
                            writer.WriteLine(firstLine);
                            writer.WriteLine(secondLine);
                            if (firstLine == null)
                            {
                                writer.WriteLine(secondLine);
                            }
                            if (secondLine == null)
                            {
                                writer.WriteLine(firstLine);
                            }
                            firstLine = firstReader.ReadLine();
                            secondLine = secondReader.ReadLine();
                        }
                    }
                }
            }
        }
    }
}