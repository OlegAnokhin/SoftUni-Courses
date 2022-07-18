namespace P01.Stream_Progress
{
    using _01._Stream_Progress_Info;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StreamProgressInfo
    {
        private IStreamable streamable;

        public StreamProgressInfo(IStreamable streamResult)
        {
            this.streamable = streamResult;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamable.BytesSent * 100) / this.streamable.Length;
        }
    }
}
