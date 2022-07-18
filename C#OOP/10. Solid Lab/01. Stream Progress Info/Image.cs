namespace _01._Stream_Progress_Info
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Image : IStreamable
    {
        public Image(int length, int bytesSent)
        {
           this.Length = length;
           this.BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent {get; set; }
    }
}
