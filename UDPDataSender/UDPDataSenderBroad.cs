using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace UDPDataSender
{
    public class UDPDataSenderBroad
    {
        public static void Main(string[] args)
        {


            string jsonstring =
                $"{{\r\n     \"name\": \"TestRoom\",\r\n    \"active\": true,\r\n    \"status\": \"Motion Detected\",\r\n    \"timeOfDetection\": \"{DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss")}\"  }}";

            //Using remote endpoint needs UdpClient (0) for broadcasting
            UdpClient udpServer = new UdpClient(0);  //or empty
            udpServer.EnableBroadcast = true; //not necessary
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 7000);
            //IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 7000); in client

            Console.WriteLine("Broadcast started: Press Enter");
            Console.ReadLine();


            Byte[] sendBytes = Encoding.ASCII.GetBytes(jsonstring);
            try
            {
                udpServer.Send(sendBytes, sendBytes.Length, endPoint); //, endPoint

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Thread.Sleep(100);


        }
    }
}
