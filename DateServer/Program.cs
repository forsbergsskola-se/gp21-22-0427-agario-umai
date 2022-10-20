using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

//Creating a listener, setting IP server address
var tcpListener = new TcpListener(IPAddress.Loopback, 14411);

//Start server/listener 
tcpListener.Start();
Console.WriteLine("Start Listener");

//Keep server running
while (true)
{
    //Accept the client request 
    var tcpClient = tcpListener.AcceptTcpClient();
    //Write the message to client 
    tcpClient.GetStream().Write(GetGreetingMessage());

    tcpClient.Close();
}

//Translating the string to bytes
static byte[] GetGreetingMessage()
    => Encoding.ASCII.GetBytes("The Current time is: " + DateTime.Now);