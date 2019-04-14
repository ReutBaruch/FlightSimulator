using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class ClientSide
    {
        public void ClientConnect()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5402);
            TcpClient client = new TcpClient();
            client.Connect(ep);
            Console.WriteLine("You are connected");

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                // Send data to server
               // Console.Write("Please enter a number: ");
                //int num = int.Parse(Console.ReadLine());
                //writer.Write(num);
                // Get result from server
                string result = "set controls/flight/rudder 1";
                result = result + "\n";
                Console.WriteLine(result);
                writer.WriteLine(result);
            }
            client.Close();
        }
    }
}
