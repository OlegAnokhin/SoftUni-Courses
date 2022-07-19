namespace SoftUniLogger.Appenders
{
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Formetters;
    using SoftUniLogger.Formetters.Interfaces;
    using SoftUniLogger.IO.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileAppender : IFileAppender
    {
        private readonly IFormatter formatter;
        public FileAppender()
        {
            this.Count = 0;
        }
        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
            this.formatter = new MessageFormatter(this.Layout);
        }

        public int Count { get; }
        public ILayout Layout { get; }
        public ILogFile LogFile { get; }
        public void Append(IMessage message)
        {
            string formatedMessage = this.formatter.FormatMessage(message);
            this.LogFile.Write(formatedMessage);
        }
        public void SaveLogFile(string filename)
        {
            this.LogFile.SaveAs(filename);
        }
    }
}