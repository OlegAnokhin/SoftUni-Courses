﻿namespace P01.Stream_Progress
{
    using _01._Stream_Progress_Info;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Music : IStreamable
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }

        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
