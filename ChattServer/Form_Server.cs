using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChattServer
{
    public partial class Form_Server : Form
    {
        public Form_Server()
        {
            InitializeComponent();
        }

        Thread threadServer = null;
        Thread threadRead = null;
        TcpListener listener = null;
        TcpClient tcp = null;
        string TmpString = "";  // AddText함수에서 string을 object[]로 바로 받아주지 않고 타이머 이용하는 것 처럼 외부 변수 이용



        //delegate void callbackAddText();
        delegate void callbackAddText(string s);
        //void AddText(string str)  // callback함수가 invoke할 실제 함수

        void AddText(string str) // void AddText()
        {
            if (tbReceive.InvokeRequired)
            {
                callbackAddText cbat = new callbackAddText(AddText);
                Invoke(cbat, new object[] { str });
                //Invoke(cbat);
            }
            //else tbReceive.AppendText(TmpString);
            else  tbReceive.Text += str ;   // tbReveive.AppendText(str) 과 동일
        }


            private void btnServerStart_Click(object sender, EventArgs e)
        {
            // 1. listener 선언
            // 2. listener 실행
            if(listener == null)
            {
                listener = new TcpListener(int.Parse(tbServerPort.Text));  // path -> tbServerPort.Text
                listener.Start();
                sbLabel1.Text = "Server Started";
            }
            if(threadServer == null)
            {
                threadServer = new Thread(ServerProcess);
                threadServer.Start();
                threadRead = new Thread(ReadProcess);
                // readthread start할 필요 X
            }
            
        }

        void ServerProcess()  //  외부로부터 접속요청 처리 thread
        {
            while(true)  // 무한루프
            {
                if (listener.Pending() == true)  // Pending(Non-Blocking Method) : 접속 요청이 있는 경우.... / while루프 안하면 접속요청 1회성
                {
                    tcp = listener.AcceptTcpClient();  // 블로킹 모드 : 다른 업무 수행 불가 / tcpclient 소켓 생성
                    AddText($"Remote EndPoint {tcp.Client.RemoteEndPoint.ToString()}로부터 접속되었습니다.\r\n");  // 어디에서 접속되었는지 출력
                    threadRead.Start(); // threadRead 추가 생성 / listener 접속이 성공적으로 실행될 경우
                }
                Thread.Sleep(100); // 1/10초마다 sleep. 안전장치
            }
        }

        void ReadProcess()  // thread read / 열려있는 tcp networkstream 만들고 들어오는 데이터를 계속 읽고 출력
        {
            if(tcp != null)
            {
                NetworkStream ns = tcp.GetStream();  // stream 생성
                byte[] bArr = new byte[200];
                while (true)
                {
                    while (ns.DataAvailable)  // dataavailable : bool
                    {
                        // 데이터 송수신은 byte[]로 이루어 짐
                        int n = ns.Read(bArr, 0, 200); // bArr의 0부터 어레이 길이만큼  / long과 int는 똑같이 4 byte
                        //tbReceive.Text += Encoding.Default.GetString(bArr);  // tbRecieve 화면 내용 갱신
                        //TmpString = Encoding.Default.GetString(bArr);
                        //AddText();
                        AddText(Encoding.Default.GetString(bArr, 0, n)+"\r\n");
                    }

                    /*
                    while (ns.DataAvailable)
                    {
                        ns.Read(bArr, 0, (int)ns.Length); // bArr의 0부터 어레이 길이만큼  / long과 int는 똑같이 4 byte
                                                          //tbReceive.Text += Encoding.Default.GetString(bArr);  // tbRecieve 화면 내용 갱신
                        TmpString = Encoding.Default.GetString(bArr);
                        //AddText(Encoding.Default.GetString(bArr));
                        AddText();
                    }
                    */
                }
            } 
        }




        iniFile ini = new iniFile(".\\ChattServer.ini"); // MyLibrary 사용
        private void Form_Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.SetString("Server", "IP", tbServerPort.Text);

            ini.SetString("Form", "LocationX", $"{Location.X}");
            ini.SetString("Form", "LocationY", $"{Location.Y}");

            ini.SetString("Form", "SizeX", $"{Size.Width}");
            ini.SetString("Form", "SizeY", $"{Size.Height}");

            if (threadServer != null)
            {
                threadServer.Abort();
            }
            if(threadRead != null)
            {
                threadRead.Abort();
            }
        }

        private void Form_Server_Load(object sender, EventArgs e)
        {
            // Form 로드시 초기값
            int x1, x2, y1, y2;
            tbServerPort.Text = ini.GetString("Server", "Port", "9001");

            x1 = int.Parse(ini.GetString("Form", "LocationX", "0"));
            y1 = int.Parse(ini.GetString("Form", "LocationY", "0"));
            this.Location = new Point(x1, y1); // LOCATION 변경

            x2 = int.Parse(ini.GetString("Form", "SizeX", "500"));
            y2 = int.Parse(ini.GetString("Form", "SizeY", "500"));
            this.Size = new Size(x2, y2);  // Size 변경
        }

        // Send 함수 생성
        private void strSend(string str)
        {
            if (tcp != null)
            {
                NetworkStream ns = tcp.GetStream();  // stream 생성 / Read & Write 모두 가능

                byte[] bArr = Encoding.Default.GetBytes(str); //new byte[200];
                ns.Write(bArr, 0, bArr.Length); // bArr 크기만큼 

            }
        }



        private void btnSend_Click(object sender, EventArgs e)
        {
            strSend(tbSend.Text);
            /*
            if (tcp != null)
            {
                NetworkStream ns = tcp.GetStream();  // stream 생성 / Read & Write 모두 가능

                byte[] bArr = Encoding.Default.GetBytes(tbSend.Text+"\r\n"); //new byte[200];
                ns.Write(bArr, 0, bArr.Length); // bArr 크기만큼 
            }
            */
        }

        private void tbSend_KeyUp(object sender, KeyEventArgs e)  // 엔터 눌렸을 때 Send
        {

            if (e.KeyCode == Keys.Enter)
            {
                // 현재 줄 위치 파악
                int pos = tbSend.SelectionStart;  // SelectionStart : 현재 caret(커서)의 위치 가져옴
                int lineNo = tbSend.GetLineFromCharIndex(pos); // GetLineFromCharIndex : 지정된 문자열의 줄 번호 가져옴
                // 우리가 전송할 마지막 line No. 는 lineNo - 1 (엔터친 마지막줄 윗줄)


                string[] sArr = tbSend.Text.Split('\n');  // sArr : 줄단위로 구분하여 각각의 배열요소로 
                string str = sArr[lineNo - 1] + "\n";  // 모든 줄의 수 / 첫줄 index : 0, 엔터쳐서 다음 줄의 null값을 포함
                strSend(str);

                // strSend(tbSend.Text.Split('\n')[tbSend.GetLineFromCharIndex(tbSend.SelectionStart)-1] + "\n");
            }
        }

        private void mnuSend_Click(object sender, EventArgs e)  // Select된 문자열 Send
        {
            string str = tbSend.SelectedText;
            strSend(str);
        }
    }
}
