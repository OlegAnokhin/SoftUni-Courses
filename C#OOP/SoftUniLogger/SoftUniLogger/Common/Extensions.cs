namespace SoftUniLogger.Common
{
    using SoftUniLogger.Appenders.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Extensions
    {
        public static void AddRange<T>(this ICollection<T> appenders, IEnumerable<T> appendersToAdd)
        {
            foreach (T appender in appendersToAdd)
            {
                appenders.Add(appender);
            }
        }
        public static IReadOnlyCollection<IAppender> AsReadOnly(this ICollection<IAppender> appenders)
            => (IReadOnlyCollection<IAppender>)appenders;
    }
}
