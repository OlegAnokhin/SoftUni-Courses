namespace AuthorProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            MethodInfo[] methods = classType.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Static | 
                BindingFlags.Public);
            foreach (MethodInfo method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    object[] attrs = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in attrs)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}