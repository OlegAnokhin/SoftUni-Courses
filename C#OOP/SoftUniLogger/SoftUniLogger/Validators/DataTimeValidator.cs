namespace SoftUniLogger.Validators
{
    using SoftUniLogger.Validators.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DataTimeValidator : IValidator
    {
        public bool IsValid(object value)
             => DateTime.TryParse((string)value, out DateTime date);
    }
}
