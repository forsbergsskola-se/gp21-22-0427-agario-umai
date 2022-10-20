using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OpenWorld_MMO
{
    public class WorldClient : MonoBehaviour
    {
        [SerializeField] private string ipAddress;
        [SerializeField] private int port;

        [SerializeField] private TextMeshProUGUI textInput;
        [SerializeField] private TextMeshProUGUI textDisplay;

        public void ConnectToServer()
        {   
            // Set the server address
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            // Creating the client
            var client = new UdpClient();
            
            //Client connects to server
            client.Connect(endPoint);
            SendWord(client);
            textDisplay.text = ReceiveMessage(client, endPoint);
        }
        
        private void SendWord(UdpClient client)
        {
            //Converts string into bytes
            var data = Encoding.ASCII.GetBytes(textInput.text);
            //Sends data to the server
            client.Send(data, data.Length);
        }
        
        //Getting the message and converts back to string
        private string ReceiveMessage(UdpClient client, IPEndPoint endPoint) 
            => Encoding.ASCII.GetString(client.Receive(ref endPoint));
    }
}
