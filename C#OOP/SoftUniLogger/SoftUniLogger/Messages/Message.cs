namespace SoftUniLogger.Messages
{
    using SoftUniLogger.Enums;
    using SoftUniLogger.Exceptions;
    using SoftUniLogger.Messages.Interfaces;
    using SoftUniLogger.Validators;
    using SoftUniLogger.Validators.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Message : IMessage
    {
        private const string EmptyArgumenMessage = "Argument cannot be null or empty string!";
        private string logTime;
        private string messageText;
        private readonly IValidator dateTimeValidator;
        public Message()
        {
            this.dateTimeValidator = new DataTimeValidator();
        }

        public Message(string logTime, string messageText, ReportLevel level)
            :this()
        {
            this.LogTime = logTime;
            this.MessageText = messageText;
            this.Level = level;
        }
        public string LogTime
        {
            get
            {
                return this.logTime;
            }
            private set
            {
                if (!this.dateTimeValidator.IsValid(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.LogTime), EmptyArgumenMessage);
                }
                this.LogTime = value;
            }
        }
        public string MessageText 
        {
            get
            {
                return this.messageText;
            } 
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.MessageText), EmptyArgumenMessage);
                }
                this.messageText = value;
            }
        }
        public ReportLevel Level { get; }
    }
}