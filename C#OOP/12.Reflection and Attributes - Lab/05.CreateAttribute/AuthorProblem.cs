namespace AuthorProblem
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorProblem : Attribute
    {
        public string Name { get; set; }
        public AuthorProblem(string name)
        {
            this.Name = name;
        }
    }
}