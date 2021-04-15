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

namespace ChattManager
{
    public partial class Form_Client : Form
    {
        public Form_Client()
        {
            InitializeComponent();
        }

        delegate void callbackAddText(string s);  // AddText에 대한 call back함수
        void AddText(string str)
        {
            if(tbRecieve.InvokeRequired)
            {
                callbackAddText cbat = new callbackAddText(AddText);
                object[] oArr = { str };  // oArr 어레이에 직접 str을 입력하기 때문에 new 할 필요 X
                Invoke(cbat, oArr);  // invoke에 의해 재호출
                // => Invoke(cbat, new object[] { str }); 와 동일
            }
            else
            {
                tbRecieve.AppendText(str);
            }
            
        }


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            int size1 = splitContainer1.Size.Width; // splitcontainer1 전체 사이즈
            int size2 = splitContainer1.SplitterDistance; // panel1의 사이즈
            int size3 = size1 - size2; // panel2의 사이즈

            splitContainer1.SplitterDistance = size1 - 250;  // panel2 사이즈 고정
        }

        Thread threadClient = null;
        Socket sock = null;
        

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (sock == null)
                {
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
                else  // socket이 기존에 있었다면 기존 connection clear -> 새로 소켓 생성
                {
                    if(threadClient != null)  // socket과 thread는 같이 
                    {
                        threadClient.Abort();
                        threadClient = null;
                    }
                    sock.Close();
                    //sock = null;
                    sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }

                sock.Connect(tbIP.Text, int.Parse(tbPort.Text));  // connection -> 블로킹모드 (TimeOut 발생 전까지. 2~3초 정도)
                /*
                Thread threadConnection = new Thread(ConnectProcess);
                threadConnection.Start();

                while(true)  // connection이 된다면, thread 종료
                {
                    if (threadConnection.IsAlive) break;
                }
                */

                sb_IP.Text = ((IPEndPoint)(sock.RemoteEndPoint)).Address.ToString();  // tbIP, tbPort에 Server측의 IP, Port 정보를 가져옴 / 127.0.0.1:9001
                sb_Port.Text = ((IPEndPoint)(sock.RemoteEndPoint)).Port.ToString();  // IPEndPoint로 캐스팅

                if (threadClient == null)
                {
                    threadClient = new Thread(ClientProcess);
                    threadClient.Start();
                }
            }
            catch(Exception e1)
            {
                tbRecieve.AppendText(e1.Message+"\r\n");  // Server가 연결되어있지 않은 경우 connect를 시도하게 되면 e1에러메세지 그대로 출력, 줄바꿈 
            }

        }

        void ClientProcess()  // Thread 등록 프로세스
        {
            while(true)
            {
                int n = sock.Available;
                if (n > 0 && sock.Connected)
                {
                    byte[] bArr = new byte[n];  // c#에서 통신은 byte array로 주고받음 / c,c++에서는 char
                    sock.Receive(bArr);  // 소켓에서 정보 받음
                                         //tbRecieve.AppendText(Encoding.Default.GetString(bArr));  // byte[]의 Size만큼 변환 (Null포함) / delegate 필요
                    AddText(Encoding.Default.GetString(bArr));
                }
            }
        }

        void ConnectProcess()  // Blocking Mode를 막기 위하여 소켓 연결을 위한 thread
        {
            sock.Connect(tbIP.Text, int.Parse(tbPort.Text));
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            try  // 갑자기 Server가 끊어진 경우, socket connection이 clear 됐다는 것을 인지하지 못한 상태에서 send를 하게 되면 발생하는 오류를 방지하기 위함
            {
                if (sock.Connected)  // connected 자체가 bool값을 갖으므로 ==true 할 필요 X
                {
                    string str = tbSend.Text.Trim();  // multi line 각각 모든 줄에는 \r\n(CRLF)이 존재
                    string[] sArr = str.Split('\r');  // 줄 구분자로 나누어진 구분된 형태로 어레이 담아줌
                                                      //string sLast = sArr[sArr.Length-1];  // 가장 마지막 줄 / sArr 갯수의 가장 마지막번째의 sArr
                    string sLast = sArr.Last(); // sArr 어레이의 마지막
                    byte[] bArr = Encoding.Default.GetBytes(sLast);
                    sock.Send(bArr);
                }
                else
                {
                    AddText("서버와의 통신이 원활하지 않습니다.\r\n 연결을 점검하고 다시 시도하세요.\r\n");
                }
            }
            catch(Exception e1)
            {
                AddText(e1.Message);  // 에러메세지 출력
            }
            
        }

        iniFile ini = new iniFile(".\\ChattClient.ini"); // MyLibrary 사용
        private void Form_Client_Load(object sender, EventArgs e)
        {
            // Form 로드시 초기값
            int x1, x2, y1, y2;
            tbIP.Text = ini.GetString("Server", "IP", "127.0.0.1");  
            tbPort.Text = ini.GetString("Server", "Port", "9001");

            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1); // LOCATION 변경

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);  // Size 변경

        }

        private void Form_Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Server", "IP", tbIP.Text);  // Form Closing시 값 저장 
            ini.SetString("Server", "Port", tbPort.Text);

            ini.SetString("Form", "LocationX", $"{Location.X}");
            ini.SetString("Form", "LocationY", $"{Location.Y}");

            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");
        }
    }
}
