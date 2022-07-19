namespace SoftUniLogger.Appenders.Interfaces
{
    using SoftUniLogger.Enums;
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAppender
    {
        int Count { get; }
        ILayout Layout { get; }
       // ReportLevel Level { get;}
        void Append(IMessage message);
    }
}
