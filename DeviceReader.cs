using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using IndoorEnvironmentClassLibrary;
using IndoorEnvironmentDataAccessLibrary;

namespace IndoorEnvironment
{
    public class DeviceReader
    {
        WebServer webserver = new WebServer();
        DataFactory df = new DataFactory();
        public Reading Read(Device device)
        {
            //List<float> readings = new List<float>();
            Reading read;
            //Opening TcpClient
            using (TcpClient Client = df.CreateTcpClient())
            {
                //Connection method from library
                webserver.Connect(Client, device.IPAdresse);
                //Starting network stream
                using (NetworkStream netStream = Client.GetStream())
                {
                    //BinaryWriter wries /n to webserver
                    webserver.Write(netStream);
                    //Reads the webserver and returns a list<float>
                    read = webserver.Read(netStream);
                    return read;
                }
            }
        }
    }
}
