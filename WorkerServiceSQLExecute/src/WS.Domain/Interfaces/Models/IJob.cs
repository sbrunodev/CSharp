using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Business.Interfaces
{
    public abstract class IJob
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Command { get; set; }
        public bool Executed { get; set; }

        // When the work will be determined ?
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Hour { get; set; }
        public int Minute { get; set; }

    }
}
