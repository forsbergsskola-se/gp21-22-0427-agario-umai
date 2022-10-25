using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

//Creating a listener, setting IP server address

List<int> ports = new(){14411,3002,3003,5521,3004};
TcpListener tcpListener = null;

for (int i = 0; i < ports.Count; i++)
{
    try
    {
        tcpListener = new TcpListener(IPAddress.Loopback, ports[i]);
        tcpListener.Start();
        Console.WriteLine("Start Listener on port " + ports[i]);
        break;
    }
    catch (SocketException e)
    {
        Console.WriteLine("Port " + ports[i] + " is already running" );
        
    }
}

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