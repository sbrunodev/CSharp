using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Business.Models
{

    public class JobSettings : IJobSettings
    {
        public string JobCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IJobSettings
    {
        string JobCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
