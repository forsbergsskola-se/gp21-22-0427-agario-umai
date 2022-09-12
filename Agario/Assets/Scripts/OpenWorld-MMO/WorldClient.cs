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
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            var client = new UdpClient();
        
            client.Connect(endPoint);
            SendWord(client);
            textDisplay.text = ReceiveMessage(client, endPoint);
        }

        private void SendWord(UdpClient client)
        {
            var data = Encoding.ASCII.GetBytes(textInput.text);
            client.Send(data, data.Length);
        }

        private string ReceiveMessage(UdpClient client, IPEndPoint endPoint) 
            => Encoding.ASCII.GetString(client.Receive(ref endPoint));
    }
}
