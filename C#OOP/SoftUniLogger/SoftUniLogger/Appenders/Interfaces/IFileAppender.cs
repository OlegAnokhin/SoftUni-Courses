namespace SoftUniLogger.Appenders.Interfaces
{
    using SoftUniLogger.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFileAppender : IAppender
    {
        ILogFile LogFile { get; }
        void SaveLogFile(string filename);
    }
}
