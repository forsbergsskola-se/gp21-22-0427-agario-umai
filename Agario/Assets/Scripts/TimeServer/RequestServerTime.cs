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
        int bytesReceived = tcpClient.GetStream().Read(buffer);
        var intToByte = BitConverter.GetBytes(bytesReceived);
        timeText.text = Encoding.UTF8.GetString(buffer.AsSpan(0, bytesReceived));
        Debug.Log(bytesReceived);
        
        
        tcpClient.Close();
    }

   

}

