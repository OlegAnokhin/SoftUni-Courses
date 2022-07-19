namespace SoftUniLogger.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage = "Provided DateTime was not in correct format!";
        public InvalidDateTimeFormatException()
            : base(DefaultMessage)
        {

        }
    }
}
