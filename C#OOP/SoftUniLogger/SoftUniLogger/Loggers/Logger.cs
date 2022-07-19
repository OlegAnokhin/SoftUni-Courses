namespace SoftUniLogger.Loggers
{
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Loggers.Interfaces;
    using Enums;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SoftUniLogger.Common;
    using SoftUniLogger.Messages.Interfaces;
    using SoftUniLogger.Messages;

    public class Logger : IAppenderCollection, ILogger
    {
        private readonly ICollection<IAppender> appenders;
        private Logger()
        {
            this.appenders = new List<IAppender>();
        }
        public Logger(params IAppender[] appenders)
            : this()
        {
            this.appenders.AddRange(appenders);
        }
        public IReadOnlyCollection<IAppender> Appenders
            => this.appenders.AsReadOnly();
        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }
        public bool RemoveAppender(IAppender appender)
        {
            return this.appenders.Remove(appender);
        }
        public void Clear()
        {
            this.appenders.Clear();
        }
        public void Info(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Info);
        }
        public void Warning(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Warning);
        }
        public void Error(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Error);
        }
        public void Critical(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Critical);
        }
        public void Fatal(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Fatal);
        }
        private void LogMessage(string logTime, string messageText, ReportLevel level)
        {
            IMessage message = new Message(logTime, messageText, level);
            foreach (IAppender appender in this.Appenders)
            {
                appender.Append(message);
            }
        }
        public void SaveLogs(string fileName)
        {
            int counter = 1;
            foreach (IAppender appender in this.Appenders)
            {
                if (appender is IFileAppender fileAppender)
                {
                    ((IFileAppender)appender).SaveLogFile($"{fileName}_{counter++}.txt");
                }
            }
        }
    }
}
