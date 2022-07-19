namespace SoftUniLogger.IO
{
    using SoftUniLogger.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder sbContent;
        private readonly IFileWriter fileWriter;
        private LogFile()
        {
            this.sbContent = new StringBuilder();
        }
        public LogFile(IFileWriter fileWriter)
            :this()
        {
            this.fileWriter = fileWriter;
        }
        public int Size
            => this.sbContent.Length;

        public string Content 
            => this.sbContent.ToString();
        public void Write(string content)
        {
            this.sbContent.AppendLine(content);
        }
        public void SaveAs(string filename)
        {
            this.fileWriter.WriteContent(this.Content, filename);
        }
    }
}
