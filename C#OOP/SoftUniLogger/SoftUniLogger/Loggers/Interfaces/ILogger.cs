namespace SoftUniLogger.Loggers.Interfaces
{
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ILogger
    {
        void Info(string logTime, string message);
        void Warning(string logTime, string message);
        void Error(string logTime, string message);
        void Critical(string logTime, string message);
        void Fatal(string logTime, string message);
        void SaveLogs(string fileName);
    }
}
