namespace AuthorProblem
{
    using System;
    public class StartUp
    {
        [Author("Oleg")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
        [Author("Gosho")]
        public void TakeBeer()
        {
        }
        [Author("Pesho")]
        public static void DrinkBeer()
        {
        }
    }
}