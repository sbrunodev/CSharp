using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recursion
{
    public class DeviceService
    {
        public DeviceService()
        {

        }


        public List<Device> GetDevices()
        {
            /*
                Device 1
                    Porta 1
                    Porta 2
                    Porta 3
                Device 2
                    Porta 4
                Device 3
                    Porta 5
                Device 4
                Device 5
                    Porta 6
                        Chave 7
            */

            Device d1 = new Device() { Id = Guid.NewGuid(), Name = "Device 1" };
            Device p1 = new Device() { Id = Guid.NewGuid(), Name = "Porta 1", MasterDevice = d1.Id };
            Device p2 = new Device() { Id = Guid.NewGuid(), Name = "Porta 2", MasterDevice = d1.Id };
            Device p3 = new Device() { Id = Guid.NewGuid(), Name = "Porta 3", MasterDevice = d1.Id };

            Device d2 = new Device() { Id = Guid.NewGuid(), Name = "Device 2" };
            Device p4 = new Device() { Id = Guid.NewGuid(), Name = "Porta 4", MasterDevice = d2.Id };

            Device d3 = new Device() { Id = Guid.NewGuid(), Name = "Device 3" };
            Device p5 = new Device() { Id = Guid.NewGuid(), Name = "Porta 5", MasterDevice = d3.Id };

            Device d4 = new Device() { Id = Guid.NewGuid(), Name = "Device 4" };

            Device d5 = new Device() { Id = Guid.NewGuid(), Name = "Device 5" };
            Device p6 = new Device() { Id = Guid.NewGuid(), Name = "Porta 6", MasterDevice = d5.Id };
            Device c1 = new Device() { Id = Guid.NewGuid(), Name = "Chave 1", MasterDevice = p6.Id };

            List<Device> list = new List<Device>();

            list.Add(d1);
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);

            list.Add(d2);
            list.Add(p4);

            list.Add(d3);
            list.Add(p5);

            list.Add(d4);

            list.Add(d5);
            list.Add(p6);
            list.Add(c1);

            return list;
        }

        public List<Device> Ordenar()
        {
            var deviceList = GetDevices();

            for (int i = 0; i < deviceList.Count; i++)
            {
                var device = deviceList[i];

                if (device.MasterDevice != Guid.Empty)
                {
                    Device masterDevice = null;
                    GetDevice(0, deviceList, device.MasterDevice, ref masterDevice);
                    if(masterDevice != null)
                    {
                        if (masterDevice.Devices == null)
                            masterDevice.Devices = new List<IDevice>();

                        Console.WriteLine($"Dispositivo {device.Name} Adicionado em {masterDevice.Name}");

                        masterDevice.Devices.Add(device);
                    }
                }
            }
            return deviceList;
        }

        public void GetDevice(int index, List<Device> deviceList, Guid masterDeviceId, ref Device deviceAux)
        {
            while(index < deviceList.Count && deviceAux == null)
            {
                var device = deviceList[index];
                if (device.Id == masterDeviceId)                
                    deviceAux = device;                
                else
                {
                    index++;
                    if (device.Devices != null && deviceAux == null)
                        GetDevice(index, deviceList, masterDeviceId, ref deviceAux);
                }
            }
        }





    }
}
