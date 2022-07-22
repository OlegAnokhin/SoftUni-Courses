namespace Stealer
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}