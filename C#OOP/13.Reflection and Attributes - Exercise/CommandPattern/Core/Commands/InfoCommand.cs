namespace CommandPattern.Core.Commands
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InfoCommand : ICommand
    {
       public string Execute(string[] args)
        {
            return $"My name is {args[0]} and I am {args[1]} years old!";
        }
    }
}
