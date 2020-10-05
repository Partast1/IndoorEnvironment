using IndoorEnvironmentClassLibrary;
using IndoorEnvironmentDataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace IndoorEnvironment
{
    public class FindOnlineWebservers
    {
        bool pingable = false;
        Ping pinger = null;
        public bool PingDevices(string nameOrAddress)
        {
            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
            return pingable;
        }
        //Variables for AvailableWebServersThread()
        bool online = false;

        Database db = new Database();
        List<Device> devices = new List<Device>();
        List<Device> onlineDevices = new List<Device>();
        public List<Device> AvailableWebServers()
        {
            devices = db.ReadDevice();

            foreach (var item in devices)
            {
                online = PingDevices(item.IPAdresse);

                if (online == true)
                {
                    onlineDevices.Add(item);
                }
            }
            return onlineDevices;
        }
    }
}
