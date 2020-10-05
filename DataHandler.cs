using System;
using System.Collections.Generic;
using System.Text;
using IndoorEnvironmentClassLibrary;
using IndoorEnvironmentDataAccessLibrary;

namespace IndoorEnvironment
{
    public class DataHandler
    {
        float humid = 0;
        float temp = 0;
        //List<float> readings = new List<float>();
        Reading read;
        Database db = new Database();
        DeviceReader deviceReader = new DeviceReader();
        public void ReadFromWebServer(Device device)
        {
            read = deviceReader.Read(device);
            float humid = read.Humidity;
            float temp = read.Temperature;
            string ip = read.DeviceIp;

           //send readings over til DatabaseHandler
           //for (int i = 0; i < readings.Count; i++)
           //{
           //    if (i == 0)
           //    {
           //        temp = readings[i];
           //    }
           //    else
           //    {
           //        humid = readings[i];
           //    }
           //}
           WriteToDatabase(humid, temp, ip);
        }
        public void WriteToDatabase(float humid, float temp, string ip)
        {
            db.WriteReading(humid, temp, ip);
        }
    }
}
