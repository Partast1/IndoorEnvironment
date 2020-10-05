using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using IndoorEnvironmentDataAccessLibrary;
using IndoorEnvironmentClassLibrary;

namespace IndoorEnvironment
{
    public class ThreadHandler
    {
        DataHandler dh = new DataHandler();
        public void DeviceThread(Device device)
        {
            while (true)
            {
                dh.ReadFromWebServer(device);
                Thread.Sleep(5000);
            }
        }
        ////Variables for AvailableWebServersThread()
        //bool online = false;
        //FindOnlineWebservers onlineWebservers = new FindOnlineWebservers();
        //Database db = new Database();
        //List<Device> devices = new List<Device>();
        //List<Device> onlineDevices = new List<Device>();
        //public void AvailableWebServersThread()
        //{
        //    while (true)
        //    {
        //        devices = db.ReadDevice();

        //        foreach (var item in devices)
        //        {
        //            if (online == true)
        //            {
        //                online = onlineWebservers.PingDevices(item.IPAdresse);
        //                onlineDevices.Add(item);
        //            }
        //        }
          
        //    }
        //}
    }
}
