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
    class ServerSide
    {
        public void ServerConnect()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5400);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            
            Console.WriteLine("Waiting for client connections...");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");

            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                Console.WriteLine("Waiting for a number");
                string num = reader.ReadLine();
                Console.WriteLine(num);
                writer.Write(num);
                writer.Flush();
            }
            client.Close();
            listener.Stop();
        } //end of ServerConnect function
    }
}
