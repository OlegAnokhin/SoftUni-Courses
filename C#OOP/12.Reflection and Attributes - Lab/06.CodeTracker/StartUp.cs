namespace AuthorProblem
{
    using System;
    using System.Reflection;

    [AuthorAttribute("Victor")]
    public class StartUp
    {
        [AuthorAttribute("George")]
        static void Main()
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
        [AuthorAttribute("Oleg")]
        public void CreateObj()
        {
        }
        [AuthorAttribute("Hasan")]
        public void GetMethod()
        {
        }
    }
}