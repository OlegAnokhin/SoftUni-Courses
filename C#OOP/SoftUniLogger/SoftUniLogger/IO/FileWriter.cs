namespace SoftUniLogger.IO
{
    using SoftUniLogger.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileWriter : IFileWriter
    {
        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; set; }

        public void WriteContent(string content, string fileName)
        {
            if (!Directory.Exists(this.FilePath))
            {
                Directory.CreateDirectory(this.FilePath);
            }
            string outputPath = Path.Combine(this.FilePath, fileName);
            File.WriteAllText(outputPath, content, Encoding.UTF8);
        }
    }
}
