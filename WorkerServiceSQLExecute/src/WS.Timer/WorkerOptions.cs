using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Timer
{
    public class WorkerOptions
    {
        public string PathDirectory { get; set; }
        public int Seconds { get; set; }
        public string Type { get; set; }
        public SQLJobOptions sqlJobOptions { get; set; }
        public IEnumerable<FileJobOptions> fileJobOptions  {get;set;}
    }

    public class SQLJobOptions
    {
        public string Connection { get; set; }
    }

    public class FileJobOptions
    {
        public int Minute { get; set; }
        public string PathDirectoryOrigin { get; set; }
        public string PathDirectoryDestiny { get; set; }
    }
}
