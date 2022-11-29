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
            //Setup the listener 
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 44444);
            var udpClient = new UdpClient(ipEndPoint);
            Console.WriteLine("Server has started");
            
            //Keep server running
            while (true)
            {   
                //Open to any connection
                var sender = new IPEndPoint(IPAddress.Any, 0);
                //Anyone who connects with server will send data
                var data = udpClient.Receive(ref sender);
                Console.WriteLine(udpClient + " connected");
                
                //Storing the first word
                var word = FilterWord(data);
                //Check if word lenght is valid
                data = ValidateWord(word);
                //Send whole package to client
                udpClient.Send(data, data.Length, sender); 
            }
        } 
        
        private static string FilterWord(byte[] data)
        {
            //Convert data to string
            var temp = Encoding.ASCII.GetString(data, 0, data.Length);
            Console.WriteLine("Word received: " + temp);
            //List of characters that breaks loop
            char whiteSpace = ' ';
            char backSlash = '\n';
            char questionMark = '?';
            //Return result
            string result = "";
            
            //Looking for characters
            for (int i = 0; i < temp.Length; i++)
            {
                //Keeps adding characters until the very end of the string or one of the characters
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
        //Convert strings to byte
        private static byte[] PreparePackageToSend(string quote) => Encoding.ASCII.GetBytes(quote + '\n');

    }
}