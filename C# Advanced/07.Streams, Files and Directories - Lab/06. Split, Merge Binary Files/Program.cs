namespace SplitMergeBinaryFile
{
    using System.IO;

    public class SplitMergeBinaryFile
    {
        static void Main(string[] args)
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            int lineCount = 0;
            using (FileStream reader = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (FileStream partOneWriter = new FileStream(partOneFilePath, FileMode.Create))
                {
                    using (FileStream partTwoWriter = new FileStream(partTwoFilePath, FileMode.Create))
                    {
                        while (true)
                        {
                            byte[] buffer = new byte[1];
                            int count = reader.Read(buffer, 0, buffer.Length);
                            if (count == 0)
                            {
                                break;
                            }
                            if (lineCount % 2 == 0)
                            {
                                partOneWriter.Write(buffer, 0, count);
                                lineCount++;
                            }
                            else
                            {
                                partTwoWriter.Write(buffer, 0, count);
                                lineCount++;
                            }
                        }
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream partOneReader = new FileStream(partOneFilePath, FileMode.Open))
            {
                using (FileStream partTwoReader = new FileStream(partTwoFilePath, FileMode.Open))
                {
                    using (FileStream Writer = new FileStream(joinedFilePath, FileMode.Create))
                    {
                        while (true)
                        {
                            byte[] bufferOne = new byte[1];
                            byte[] bufferTwo = new byte[1];
                            int partOneCount = partOneReader.Read(bufferOne, 0, bufferOne.Length);
                            int partTwoCount = partTwoReader.Read(bufferTwo, 0, bufferTwo.Length);
                            if (partOneCount == 0 && partTwoCount == 0)
                            {
                                break;
                            }
                            Writer.Write(bufferOne, 0, partOneCount);
                            Writer.Write(bufferTwo, 0, partTwoCount);
                        }
                    }
                }
            }
        }
    }
}