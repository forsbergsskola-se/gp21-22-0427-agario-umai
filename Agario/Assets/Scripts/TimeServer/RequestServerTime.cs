using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEditor.PackageManager;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RequestServerTime : MonoBehaviour
{
    [SerializeField] private Text timeText;

    public void SendRequest()
    {   
        // Creating server endpoint
        var serverEndPoint = new IPEndPoint(IPAddress.Loopback, 14411);
        // Creating client endpoint
        var clientEndPoint = new IPEndPoint(IPAddress.Loopback, 44441);
        //Create the client
        var tcpClient = new TcpClient(clientEndPoint);
        //Passing package 
        var buffer = new byte[100];
            
        //Creating connection between client and server 
        tcpClient.Connect(serverEndPoint);
        //Getting package from server
        tcpClient.GetStream().Read(buffer, 0, buffer.Length);
        //Translating the bytes to string
        timeText.text = Encoding.ASCII.GetString(buffer);
        tcpClient.Close();
    }

   

}

