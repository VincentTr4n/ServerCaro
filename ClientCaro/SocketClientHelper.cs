using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientCaro
{
    public class SocketClientHelper
    {
        public Socket socket { get; set; }
        public IPEndPoint endPoint { get; set; }
        public string userName { get; set; }

        public SocketClientHelper(string name,int port): 
            this(name,new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp),new IPEndPoint(IPAddress.Loopback, port)) { }
        public SocketClientHelper(string name,Socket sk,IPEndPoint ipe)
        {
            userName = name;
            socket = sk;
            endPoint = ipe;
        }
        public void Connect()
        {
            socket.BeginConnect(endPoint, new AsyncCallback(ConnectCallBack), socket);
        }

        public void SendData(string data)
        {
            if (socket.Connected)
            {
                var dataBuffer = Encoding.ASCII.GetBytes(data);
                socket.Send(dataBuffer,dataBuffer.Length,SocketFlags.None);
            }
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            socket.EndConnect(ar);
            string request = "connect:"+userName;
            SendData(request);
        }
    }
}
