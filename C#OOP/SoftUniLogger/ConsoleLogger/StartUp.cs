namespace ConsoleLogger
{
    using System;

    using SoftUniLogger;
    using SoftUniLogger.Appenders;
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Enums;
    using SoftUniLogger.IO;
    using SoftUniLogger.IO.Interfaces;
    using SoftUniLogger.Layouts;
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Loggers;
    using SoftUniLogger.Messages;
    using SoftUniLogger.Messages.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);

            IFileWriter fw = new FileWriter("../../../Logs/");
            var file = new LogFile(fw);
            var fileAppender = new FileAppender(simpleLayout, file);
            var logger = new Logger(consoleAppender, fileAppender);
            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
            logger.SaveLogs("log");
        }
    }
}