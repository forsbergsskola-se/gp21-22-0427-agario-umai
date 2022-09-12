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
        var serverEndPoint = new IPEndPoint(IPAddress.Loopback, 14411);
        var clientEndPoint = new IPEndPoint(IPAddress.Loopback, 44441);
        var tcpClient = new TcpClient(clientEndPoint);
        var buffer = new byte[100];
            
        tcpClient.Connect(serverEndPoint);
        tcpClient.GetStream().Read(buffer, 0, buffer.Length);
        timeText.text = Encoding.ASCII.GetString(buffer);
        tcpClient.Close();
    }

   

}

