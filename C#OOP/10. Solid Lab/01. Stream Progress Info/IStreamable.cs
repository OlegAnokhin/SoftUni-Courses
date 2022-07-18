namespace _01._Stream_Progress_Info
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStreamable
    {
        int Length { get; }
        int BytesSent { get; }
    }
}
