using System;
using System.Collections.Generic;
using System.Threading;
using IndoorEnvironmentClassLibrary;
using IndoorEnvironmentDataAccessLibrary;

namespace IndoorEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadHandler th = new ThreadHandler();

            FindOnlineWebservers webServers = new FindOnlineWebservers();
            List<Device> onlineDevices = new List<Device>();
            onlineDevices = webServers.AvailableWebServers();


            for (int i = 0; i < onlineDevices.Count; i++)
            {
                Device device = onlineDevices[i];
                Console.WriteLine("Online device is found {0}", device.IPAdresse);


                Thread deviceThread = new Thread(() => th.DeviceThread(device));
                deviceThread.Start();
                

            }
            Console.ReadLine();
        }
    }
}
