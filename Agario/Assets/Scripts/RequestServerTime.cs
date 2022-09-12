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
    public Text timeText;

    public void SendRequest()
   {
      var tcpClient = new TcpClient("127.0.0.1", 14411);

      var stream = tcpClient.GetStream();
      byte[] bytes = new byte [tcpClient.ReceiveBufferSize];
      stream.Read(bytes, 0, bytes.Length);

      var text = Encoding.ASCII.GetString(bytes);
      timeText.text = text;


   }

  


}

