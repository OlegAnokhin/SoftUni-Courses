namespace _03.Telephony
{
    using _03.Telephony.Core;
    using _03.Telephony.IO;
    using _03.Telephony.IO.Interfaces;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
