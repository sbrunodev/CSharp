using System;
using System.Collections.Generic;
using System.Text;
using WS.Business.Interfaces;

namespace WS.Business.Models
{
    public class JobFile : IJob
    {
        public string PathDirectoryOrigin { get; set; }
        public string PathDirectoryDestiny { get; set; }
    }
}
