namespace SoftUniLogger.Formetters.Interfaces
{
    using SoftUniLogger.Layouts.Interfaces;
    using SoftUniLogger.Messages.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal interface IFormatter
    {
        ILayout Layout { get; }
        string FormatMessage(IMessage message);
    }
}