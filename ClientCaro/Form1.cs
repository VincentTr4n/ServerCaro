using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace ClientCaro
{
    public partial class Form1 : Form
    {
        // Network component
        private SocketClientHelper client;
        private byte[] buffer;

        // Chess component
        private ChessHelper chessHelper;
        private Graphics graphics;

        private bool CanMakeCell = true;
        private string Player2;
        private bool connected = false;
        private int currentRun = 0;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            buffer = new byte[1 << 12];

            graphics = pnBoard.CreateGraphics();

            chessHelper = new ChessHelper();
            chessHelper.graphics = graphics;
        }

        private void pnBoard_Paint(object sender, PaintEventArgs e)
        {
            chessHelper.PaintCell();
            chessHelper.PaintBoard();
        }

        private void pnBoard_MouseClick(object sender, MouseEventArgs e)
        {
            
            if(chessHelper.GameMode == 2)
            {
                if(!chessHelper.isReady) return;
                chessHelper.MakeCell(e.X, e.Y);

                chessHelper.MakeCellCOm();
                if (chessHelper.GameChecker())
                {
                    if (chessHelper.EndGame() == 1)
                    {
                        if (MessageBox.Show("You lose, Play agin ???", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            graphics.Clear(pnBoard.BackColor);
                            chessHelper.PlayerVsCom();
                        }
                    }
                    else if (MessageBox.Show("You win, Play agin ???", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        graphics.Clear(pnBoard.BackColor);
                        chessHelper.PlayerVsCom();
                    }
                }
            }
            else
            {
                if (CanMakeCell)
                {
                    if (!chessHelper.isReady) return;

                    if (chessHelper.MakeCell(e.X, e.Y))
                    {
                        string data = "play:" + e.X + ":" + e.Y + ":" + Player2;
                        client.SendData(data);
                        CanMakeCell = false;
                        //currentRun = 1;
                    }


                    //if (chessHelper.GameChecker()) chessHelper.EndGame();
                    if (chessHelper.GameChecker())
                    {
                        if (currentRun == chessHelper.EndGame())
                        {
                            //MessageBox.Show(txUserName.Text + " is winner");
                            client.SendData("winner:" + txUserName.Text + ":" + Player2);
                        }
                        else
                        {
                            //MessageBox.Show(Player2 + " is winner");
                            client.SendData("winner:" + Player2 + ":" + txUserName.Text);
                        }
                    }
                }
            }
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txUserName.Text))
            {
                MessageBox.Show("Enter your user name pls!!");
                return;
            }
            try
            {
                client = new SocketClientHelper(txUserName.Text, int.Parse(txPort.Text));
                client.Connect();
                client.socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client.socket);
                btConnect.Text = (btConnect.Text == "Connect") ? "Disconnect" : "Connect";
                this.Text = txUserName.Text;
                connected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int recevied = socket.EndReceive(ar);
                string data = Encoding.ASCII.GetString(buffer, 0, recevied);

                var tmp = data.Split(':');
                if (tmp[0] == "list")
                {
                    var mlist = tmp[1].Split('\n');
                    lstUser.Items.Clear();
                    foreach (var item in mlist)
                    {
                        lstUser.Items.Add(item.Trim());
                    }
                }
                else if (tmp[0] == "error")
                {
                    MessageBox.Show(tmp[1]);
                    chessHelper.isReady = false;
                    this.Text = txUserName.Text;
                }
                else if (tmp[0] == "result")
                {
                    lbRes.Text = tmp[1];
                    //if (!tmp[1].Equals(txUserName.Text)) MessageBox.Show("You lose");
                    //else MessageBox.Show("You win");
                    chessHelper.isReady = false;
                }
                else if (tmp[0] == "request")
                {

                    Player2 = tmp[1].Trim();
                    graphics.Clear(pnBoard.BackColor);
                    this.Text = txUserName.Text + " vs " + Player2;

                    currentRun = 2;
                    chessHelper.PlayerVsPlayer(1);
                    CanMakeCell = false;
                    //firstTime = false;
                    //client.SendData("accept:"+ Player2);

                }
                else if (tmp[0] == "accept")
                {
                    Player2 = tmp[1].Trim();
                    // MessageBox.Show("accept : "+Player2);

                }
                else if (tmp[0] == "play")
                {
                    if (!CanMakeCell)
                    {
                        int X = int.Parse(tmp[1]);
                        int Y = int.Parse(tmp[2]);

                        if (chessHelper.MakeCell(X, Y))
                        {
                            //string content = "play:" + X + ":" + Y+":"+Player2;

                            //client.SendData(content);
                            CanMakeCell = true;
                        }
                    }
                }

                //buffer = new byte[1 << 12];
                client.socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), client.socket);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btPvP_Click(object sender, EventArgs e)
        {
            try
            {
                string name = lstUser.SelectedItem.ToString().Split('|')[0].Trim();
                if (!connected)
                {
                    MessageBox.Show("Please connect to server and chose a rival");
                    return;
                }
                if (name.Equals(txUserName.Text))
                {
                    MessageBox.Show("Please chose a rival");
                    return;
                }

                string request = "make_pair:" + name;
                Player2 = name + "";
                client.SendData(request);

                graphics.Clear(pnBoard.BackColor);

                chessHelper.PlayerVsPlayer(1);
                currentRun = 1;
                CanMakeCell = true;

                this.Text = txUserName.Text + " vs " + Player2;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btPvsCom_Click(object sender, EventArgs e)
        {
            graphics.Clear(pnBoard.BackColor);
            chessHelper.PlayerVsCom();
        }
    }
}
