using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ServerCaro
{
    public partial class Form1 : Form
    {
        // Network component
        public Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static byte[] buffer = new byte[1 << 12];

        // List user online
        List<Player> mlist;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            mlist = new List<Player>();


            this.FormClosing += (e, v) =>
            {
                System.IO.File.WriteAllText("mydata.txt",JsonConvert.SerializeObject(mlist));
            };
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupServer();
        }
        private void SetupServer()
        {
            txIPHost.Text = IPAddress.Any.ToString();
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, int.Parse(txPort.Text));

            server.Bind(ipe);
            server.Listen(10);

            server.BeginAccept(new AsyncCallback(AcceptCallBack), null);

        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            var client = server.EndAccept(ar);
            mlist.Add(new Player() { Name = "", socket = client, Source = 0, other = null });

            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            Socket client = (Socket)ar.AsyncState;
            if (client.Connected)
            {
                int recevied = 0;
                try
                {
                    recevied = client.EndReceive(ar);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                    return;
                }
                if (recevied != 0)
                {
                    string text = Encoding.ASCII.GetString(buffer, 0, recevied);
                    var tmp = text.Split(':');

                    if (tmp[0] == "connect")
                    {
                        listUser.Items.Add(tmp[1]);
                        foreach (var item in mlist)
                        {
                            if (item.socket.RemoteEndPoint.ToString().Equals(client.RemoteEndPoint.ToString()))
                            {
                                item.Name = tmp[1];
                            }
                        }
                        StringBuilder builder = new StringBuilder();
                        foreach (var item in mlist)
                        {
                            builder.AppendLine(item.Name + " | win - " + (item.Source));
                        }
                        SendAll("list:" + builder.ToString());
                    }
                    else if (tmp[0] == "make_pair")
                    {
                        Player current = new Player();
                        foreach (var item in mlist)
                        {
                            if (item.socket.RemoteEndPoint.ToString().Equals(client.RemoteEndPoint.ToString())) current = item;
                        }
                        foreach (var item in mlist)
                        {
                            if (tmp[1].Trim().Equals(item.Name))
                            {
                                if(item.other==null)
                                {
                                    SendData(item.socket, "request:" + current.Name.Trim());
                                    // update
                                    current.other = item;
                                    item.other = current;

                                }
                                else
                                {
                                    SendData(client, "error:He is playing with other player");
                                }
                                break;
                            }
                        }
                    }
                    else if (tmp[0] == "accept")
                    {
                        Player current = new Player();
                        foreach (var item in mlist)
                        {
                            if (item.socket.RemoteEndPoint.ToString().Equals(client.RemoteEndPoint.ToString())) current = item;
                        }
                        foreach (var item in mlist)
                        {
                            if (item.Name.Equals(tmp[1].Trim()))
                            {
                                SendData(item.socket, "accept:" + current.Name);
                                break;
                            }
                        }
                    }
                    else if (tmp[0] == "play")
                    {
                        Player current = new Player();
                        foreach (var item in mlist)
                        {
                            if (item.socket.RemoteEndPoint.ToString().Equals(client.RemoteEndPoint.ToString())) current = item;
                        }
                        SendData(current.other.socket, tmp[0] + ":" + tmp[1] + ":" + tmp[2] + ":" + current.Name);
                    } 
                    else if (tmp[0] == "winner")
                    {
                        Player p1 = new Player();
                        Player p2 = new Player();
                        if (tmp[1].Contains("list")) tmp[1] = tmp[1].Substring(0, tmp[1].Length - 4);
                        foreach (var item in mlist)
                        {
                            if (item.Name.Equals(tmp[1].Trim())) p1 = item;
                            if (item.Name.Equals(tmp[2].Trim())) p2 = item;
                        }
                        p1.Source++;
                        MessageBox.Show("winner is "+tmp[1] + "--" + tmp[2]);
                        SendData(p1.socket, "result:" + p1.Name);
                        SendData(p2.socket, "result:" + p1.Name);

                        p1.other = null;
                        p2.other = null;

                        StringBuilder builder = new StringBuilder();
                        foreach (var item in mlist)
                        {
                            builder.AppendLine(item.Name + " | win - " + (item.Source));
                        }
                        SendAll("list:" + builder.ToString());
                    }
                    
                }

            }
            //buffer = new byte[1 << 12];
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client);
        }

        private void SendData(Socket socket,string content)
        {
            var bufferData = Encoding.ASCII.GetBytes(content);
            socket.BeginSend(bufferData, 0, bufferData.Length, SocketFlags.None, new AsyncCallback(SendCallBack),socket);
            server.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }

        private void SendCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }
        private void SendAll(string content)
        {
            foreach (var item in mlist)
            {
                SendData(item.socket, content);
            }
        }
    }
}
