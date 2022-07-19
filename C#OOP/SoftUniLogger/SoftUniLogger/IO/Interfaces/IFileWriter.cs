namespace SoftUniLogger.IO.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFileWriter
    {
        string FilePath { get; set; }

        void WriteContent(string content, string fileName);
    }
}
