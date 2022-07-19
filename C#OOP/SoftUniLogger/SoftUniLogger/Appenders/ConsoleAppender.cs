namespace SoftUniLogger.Appenders
{
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Formetters;
    using SoftUniLogger.Formetters.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ConsoleAppender : IAppender
    {
        private readonly IFormatter formatter;
        private ConsoleAppender()
        {
            this.Count = 0;
        }
        public ConsoleAppender(ILayout layout)
            : this()
        {
            this.Layout = layout;
            this.formatter = new MessageFormatter(this.Layout);

        }
        public int Count { get; private set; }

        public ILayout Layout { get; }

        public void Append(IMessage message)
        {
            string formatedMessage = this.formatter.FormatMessage(message);
            Console.WriteLine(formatedMessage);
            this.Count++;
        }
    }
}
