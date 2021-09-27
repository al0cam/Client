using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace Client
{
    class Networking
    {
        private static TcpClient client;
        private static int portNum = 5005;
        private static string Ip = "127.0.0.1";
        private static NetworkStream networkStream;
        private static byte[] message;
        public static void Init()
        {
            client = new TcpClient(Ip, portNum);
            networkStream = client.GetStream();
        }
        public static void Send(string sendMessage)
        {
            message = Encoding.ASCII.GetBytes(sendMessage);
            networkStream.Write(message, 0, message.Length);
        }
        public static string Read()
        {
            networkStream.Read(message, 0, message.Length);
            string readString = Encoding.ASCII.GetString(message, 0, message.Length);
            return readString;
        }
        public static void CloseStream()
        {
            client.Close();
        }
    }
}
