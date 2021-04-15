using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting
{
    public partial class Form_Chatting : Form
    {
        public Form_Chatting()
        {
            InitializeComponent();
        }

        TcpClient tcp = null;
        Thread threadClient = null;
        Socket sock = null;
        iniFile ini = new iniFile(".\\Chatting.ini");
        Thread threadConnect = null;
        private void Form_Chatting_Load(object sender, EventArgs e)
        {

            tbIP.Text = ini.GetString("Server", "IP", "211.43.12.96");
            tbPort.Text = ini.GetString("Server", "Port", "9500");

            try
            {
                if (sock == null)
                {
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
                else  
                {
                    if (threadClient != null)  
                    {
                        threadClient.Abort();
                        threadClient = null;
                    }
                    sock.Close();
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }


                sock.Connect(tbIP.Text, int.Parse(tbPort.Text));
                /*
                if (threadConnect == null)
                {
                    threadConnect = new Thread(SocketConnect);
                    threadConnect.Start();
                }
                */
                
                sb_IP.Text = ((IPEndPoint)(sock.RemoteEndPoint)).Address.ToString();
                sb_Port1.Text = ((IPEndPoint)(sock.RemoteEndPoint)).Port.ToString();
                tbRecieve.AppendText("서버에 연결되었습니다.\r\n메세지를 입력하세요.\r\n");
                

                if (threadClient == null)
                {
                    threadClient = new Thread(ClientProcess);
                    threadClient.Start();
                }
            }
            catch (Exception e1)
            {
                tbRecieve.AppendText(e1.Message + "\r\n");  
            }
        }

        void SocketConnect()
        {
            while (true)
            {
                if (sock.Connected == false)
                {
                    sock.Connect(tbIP.Text, int.Parse(tbPort.Text));
                }
                else
                {
                    sock.Close();
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    sock.Connect(tbIP.Text, int.Parse(tbPort.Text));
                }
            }
        }


        void ClientProcess() 
        {
            while (true)
            {
                int n = sock.Available;
                if (n > 0 && sock.Connected)
                {
                    byte[] bArr = new byte[n];  
                    sock.Receive(bArr); 
                                        
                    AddText(Encoding.Default.GetString(bArr));
                }
            }
        }

        delegate void callbackAddText(string s);  
        void AddText(string str)
        {
            if (tbRecieve.InvokeRequired)
            {
                callbackAddText cbat = new callbackAddText(AddText);
                object[] oArr = { str };  
                Invoke(cbat, oArr);
            }
            else
            {
                tbRecieve.AppendText(str + "\r\n");
            }
        }




        private void btSend_Click(object sender, EventArgs e)
        {
            try  
            {
                if (sock.Connected)  
                {
                    string str = tbSend.Text.Trim();  
                    string[] sArr = str.Split('\r');  
                                                      
                    string sLast = sArr.Last();
                    byte[] bArr = Encoding.Default.GetBytes(sLast + "\r\n");
                    sock.Send(bArr);
                    AddText("나 : " + sLast + "\r\n");
                }
                else
                {
                    AddText("서버와의 통신이 원활하지 않습니다.\r\n");
                }
            }
            catch (Exception e1)
            {
                AddText(e1.Message + "\r\n"); 
            }
        }

        
        
        private void strSend(string str)
        {
            if (tcp != null)
            {
                NetworkStream ns = tcp.GetStream();  
                byte[] bArr = Encoding.Default.GetBytes(str); 
                ns.Write(bArr, 0, bArr.Length); 
            }
        }

        private void tbSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btSend_Click(this, e);
                tbSend.Clear();
            }
        }


        private void Form_Chatting_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Server", "IP", tbIP.Text);
            ini.SetString("Server", "Port", tbPort.Text);
            if(threadClient != null)
            {
                threadClient.Abort();
            }
        }

    }
}
