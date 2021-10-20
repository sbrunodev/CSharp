using System;
using System.Collections.Generic;
using System.Text;

namespace Recursion
{
    public class Device : IDevice
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MasterDevice { get; set; }
        public List<IDevice> Devices { get; set; }

        public Device()
        {

        }
    }
}
