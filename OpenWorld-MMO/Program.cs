using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OpenWorld_MMO
{
    public static class Program{ 
        
        static string _phrase = "";
        
        public static void Main()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 44444);
            var udpClient = new UdpClient(ipEndPoint);
            Console.WriteLine("Server has started");

            while (true)
            {
                var sender = new IPEndPoint(IPAddress.Any, 0);
                var data = udpClient.Receive(ref sender);
                Console.WriteLine(udpClient + " connected");
                
                var word = FilterWord(data);
                data = ValidateWord(word);
                
                udpClient.Send(data, data.Length, sender); 
            }
        } 
        
        private static string FilterWord(byte[] data)
        {
            var temp = Encoding.ASCII.GetString(data, 0, data.Length);
            Console.WriteLine("Word received: " + temp);
            char whiteSpace = ' ';
            char backSlash = '\n';
            char questionMark = '?';
            string result = "";
            
            for (int i = 0; i < temp.Length; i++)
            {
                if(temp[i].CompareTo(whiteSpace) == 0 ||
                   temp[i].CompareTo(backSlash) == 0 ||
                   temp[i].CompareTo(questionMark) == 0) break;
                
                result += temp[i];
            }
            
            return result + " ";
        } 
        private static byte[] ValidateWord(string word)
        {
            if (word.Length > 21)
                return PreparePackageToSend("Invalid word\n"); 
            
            return PreparePackageToSend(_phrase += word);
        } 
        
        private static byte[] PreparePackageToSend(string quote) => Encoding.ASCII.GetBytes(quote + '\n');

    }
}