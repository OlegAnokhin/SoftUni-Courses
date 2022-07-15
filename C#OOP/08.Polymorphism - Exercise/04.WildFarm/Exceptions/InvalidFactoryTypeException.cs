namespace _04.WildFarm.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultMessage = "Invalid type!";
        public InvalidFactoryTypeException()
            : base(DefaultMessage)
        {

        }
        public InvalidFactoryTypeException(string message)
            : base(message)
        {

        }

    }
}
