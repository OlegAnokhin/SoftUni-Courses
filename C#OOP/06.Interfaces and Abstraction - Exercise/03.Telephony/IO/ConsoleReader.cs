namespace _03.Telephony.IO
{
    using System;
    using _03.Telephony.IO.Interfaces;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string text = Console.ReadLine();
            return text;
        }
    }
}
