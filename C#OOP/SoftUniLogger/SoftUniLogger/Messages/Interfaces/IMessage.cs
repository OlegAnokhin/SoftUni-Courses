namespace SoftUniLogger.Messages.Interfaces
{
    using SoftUniLogger.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessage
    {
        string LogTime { get; }
        string MessageText { get; }
        ReportLevel Level { get; }
    }
}
