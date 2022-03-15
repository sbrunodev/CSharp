using System;
using System.Collections.Generic;
using System.Text;
using WS.Business.Models;

namespace WS.Business.Interfaces
{
    public interface IJobService
    {
        public IEnumerable<IJob> JobsList { get; set; }
        public void GetJobs();
        public string Execute(IJob job);
    }
}
