namespace SoftUniLogger.Layouts
{
    using SoftUniLogger.Layouts.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0] - {1} - {2}";
    }
}