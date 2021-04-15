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

namespace ChattSocket
{
    public partial class Form_Socket : Form
    {
        public Form_Socket()
        {
            InitializeComponent();
        }
        // Socket을 이용한 서버 프로그램 (Listener 미사용)
        Socket sockServer = null;  // listen하는 서버 소켓
        Socket sockClient = null;   // Client 소켓 / 외부와 연결하는 소켓
        Thread threadServer = null;
        Thread threadRead = null;
        //byte[] sAddress = { 0, 0, 0, 0 };  // byte[] 4자리 정수로 표현해야 함 / 서버에서 Bind하기 위한 외부포트 어드레스 (127.0.0.1이 아님)
        string sAddress = "0.0.0.0"; // IP주소 stringd으로 저장
        string sPort = "9001";

        string cAddress = "";
        string cPort = "";

        private void mnuStart_Click(object sender, EventArgs e)  // 
        {
            if(sockServer == null)
            {
                sockServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            else
            {
                if(threadServer != null)
                {
                    threadServer.Abort();
                }
                if(threadRead != null)
                {
                    threadRead.Abort();
                }
                sockServer.Close();
                sockServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            if(threadServer == null)
            {
                threadServer = new Thread(ServerProcess);
                threadServer.Start();
                AddText("Server Started.\r\n");
            }
            if(threadRead == null)
            {
                threadRead = new Thread(ReadProcess);
                // Start 안함 / threadServer가 null인데 threadRead가 실행되면 안되므로

            }
        }

        bool Pending = false; // 외부로부터의 접속 요청 수신중
        IAsyncResult ar;
        private void OnAccept(IAsyncResult iar)  // callback함수 / 외부로부터 접속이 있으면 pending변수를 true로 만들어라 / 외부로부터 수신을 비동기적으로 감시하기위한 외부 thread 함수
        {
            Pending = true;
            ar = iar; // iar 뒤에서 사용하기 위하여 전역변수로 보관
        }

        private Socket acceptSocket()  // socket 가져오는 함수
        {
            Socket sock1 = sockServer.EndAccept(ar);   // EndAccept : 실제로 소켓을 가져오는 동작
            // Start listening for next clients requirement
            sockServer.BeginAccept(new AsyncCallback(OnAccept), null);  // 한번 읽은 후 또 요청이 있을 경우, 다시 Begin Accept
            Pending = false;
            return sock1;
        }

        void DoRead()   // thread 재설정
        {
            if (threadRead != null)
            {
                threadRead.Abort(); threadRead = null;  // Abort : thread 종료
            }
            threadRead = new Thread(ReadProcess);
            threadRead.Start();  // thread 시작
        }

        byte[] GetIPBytes(string str)  // str "127.0.0.1" ==> byte[] bArr {127, 0, 0, 1}로 변경
        {
            string[] sa = str.Split('.');
            byte[] ba = new byte[4];
            if (sa.Length != 4) return null; // IP주소가 4자리가 아니면 오류 리턴
            for (int i = 0; i < 4; i++)
            {
                ba[i] = int.Parse(sa[i]);
            }
        }

        //TcpListener listener;
        void ServerProcess()
        {
            // 1. listener.Start(); -> Raw Level 소켓으로 적용시     
            IPAddress IP = new IPAddress(sAddress);
            IPEndPoint EP = new IPEndPoint(IP, int.Parse(sPort));  // Socket Bind작업을 위해 Endpoint 선언
            sockServer.Bind(EP);  // Bind 작업 -> argument : EndPoint / 해당포트를 소켓에 연결
            sockServer.Listen(50000);

            sockServer.BeginAccept(new AsyncCallback(OnAccept), null); // Non Blocking Method Strat
            while(true)  
            {
                if(Pending)  // Pending이 true라면
                {
                    sockClient = acceptSocket();  // endaccept를 통해 socket을 가져옴
                    DoRead();
                    AddText($"End Point : [{sockClient.RemoteEndPoint.ToString()}]로부터 접속되었습니다.\r\n");
                }
                

                // 2. listener.AcceptTcpClient(); 부분
                //sockClient = sockServer.Accept();   // Accept : Blocking Mode
                // BeginAccept : 외부 쓰레드처럼 시작, switch 작동 / swithc에 붙어서 callback함수 작동 -> 감시
                // Main Process에서는 callback함수의 pending이 true인지만 감시

                Thread.Sleep(100);
            }

        }





delegate void callbackAddText(string str);

        void AddText(string str)
        {
            if(tbRecieve.InvokeRequired)
            {
                callbackAddText cbat = new callbackAddText(AddText);
                Invoke(cbat, new object[] { str });
            }
            else tbRecieve.AppendText(str);

        }

        // TcpClient tcp;
        void ReadProcess()  // Read thread
        {
            while(true)
            {
                //NetworkStream ns = tcp.GetStream();
                if (sockClient != null && sockClient.Available > 0)  // 읽을 데이터가 있다면
                {
                    byte[] bArr = new byte[sockClient.Available];  // 필요한 만큼 배열 선언 
                    sockClient.Receive(bArr);  // Receive된 byte수 반환 / 소켓에서 필요한만큼 데이터 읽음

                    SendtoAll("입장하였습니다.");
                    AddText("상대 : " + Encoding.Default.GetString(bArr));
                }
            }
            
        }

        public void SendtoAll(string str)
        {
            byte[] bArr = null;
                if (sockClient.Connected == false)
                {
                AddText("대화방을 나갔습니다.");
                    //bArr = Encoding.Default.GetBytes("대화방을 나갔습니다.");
                }
                //else bArr = Encoding.Default.GetBytes(str);
        }



        void SendText(string str)  // socket을 이용해서 send
        {
            sockClient.Send(Encoding.Default.GetBytes(str));  // byte[]로 바꿔준 후 전송
            AddText($"=======> {tbSend.Text}\r\n");
        }

        private void mnuSend_Click(object sender, EventArgs e)  // 팝업메뉴의 Send
        {
            SendText(tbSend.SelectedText);  // 선택 문자열 Send
        }

        private void tbSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (sockClient.Connected)
                    {
                        string str = tbSend.Text.Trim();
                        string[] sArr = str.Split('\r');

                        string sLast = sArr.Last();
                        byte[] bArr = Encoding.Default.GetBytes("상대 : " + sLast + "\r\n");
                        sockClient.Send(bArr);
                        AddText($"=======> {sLast}\r\n");
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
            
        }

        private void Form_Socket_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(threadServer != null)
            {
                threadServer.Abort();
            }
            if(threadRead != null)
            {
                threadRead.Abort();
            }
        }


        private void mnuServerPort_Click(object sender, EventArgs e)
        {
            string str = MyLibrary.GetInput("Server Port");  // 입력 포기시 ""
            if (str != "")  // DialogResult.OK 의미
            {
                try
                {
                    int n = int.Parse(str);  // port 입력시 문자열을 입력할 경우를 대비
                    sPort = str;
                }
                catch (Exception e1)
                {
                    MessageBox.Show("포트 입력값에 문제가 있습니다.");
                }
            }
        }

        private void mnuServerIP_Click(object sender, EventArgs e)
        {
            string str = MyLibrary.GetInput("Server IP Address");
            if (str != "")
            {
                sAddress = str;
            }
        }

        private void mnuClientIP_Click(object sender, EventArgs e)
        {
            string str = MyLibrary.GetInput("Client IP Address");
            if (str != "")
            {
                cAddress = str;
            }
        }

        private void mnuClientPort_Click(object sender, EventArgs e)
        {
            string str = MyLibrary.GetInput("Client Port");  // 입력 포기시 ""
            if (str != "")  // DialogResult.OK 의미
            {
                try
                {
                    int n = int.Parse(str);  // port 입력시 문자열을 입력할 경우를 대비
                    cPort = str;
                }
                catch (Exception e1)
                {
                    MessageBox.Show("포트 입력값에 문제가 있습니다.");
                }
            }
        }

        private void mnuSendEX_Click(object sender, EventArgs e)
        {
            if (tbSend.SelectionLength > 0)
            {
                SendText(tbSend.SelectedText);
            }
            else SendText(tbSend.Text);
        }
    }
}
