﻿namespace CommandPattern.Core.Commands
{
    using CommandPattern.Core.Contracts;
    using System;

    public class ExitCommand : ICommand
    {
        private const int SuccessExitCode = 0;
        public string Execute(string[] args)
        {
            Environment.Exit(SuccessExitCode);
            return null;
        }
    }
}
