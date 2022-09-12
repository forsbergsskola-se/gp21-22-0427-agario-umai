using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TimeServer
{
    public static class Program {
        public static void Main()
        {
            var tcpListener = new TcpListener(IPAddress.Loopback, 14411);
            
            tcpListener.Start();
            Console.WriteLine("Start Listener");
            
            while (true)
            {
                var tcpClient = tcpListener.AcceptTcpClient();
                tcpClient.GetStream().Write(GetGreetingMessage());
                tcpClient.Close();
            }
        }
        
        private static byte[] GetGreetingMessage() 
            => Encoding.ASCII.GetBytes("The Current time is: " + DateTime.Now);
    }
}