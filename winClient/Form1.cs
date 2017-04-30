using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace winClient
{
    public partial class winClient : Form
    {
        private IPEndPoint ServerInfo;
        private Socket ClientSocket;
        private object obj;

        //信息接收缓存
        private Byte[] MsgBuffer;
        //信息发送存储
        private Byte[] MsgSend;
        public winClient()
        {
            InitializeComponent();
            ConnectServer();
            this.button1.Click += new EventHandler(button1_Click);
            this.button1.Click += button1_Click;
        }
        /// <summary>
        /// 打开客户端，即连接服务器
        /// </summary>
        private void ConnectServer()
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                MsgBuffer = new byte[65535];
                MsgSend = new byte[65535];
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                ServerInfo = new IPEndPoint(ip, Int32.Parse("3000"));
                ClientSocket.Connect(ServerInfo);
                //发送信息至服务器
                ClientSocket.Send(Encoding.Unicode.GetBytes("用户： 进入系统！" + "\r\n"));
                ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, SocketFlags.None,
                    new AsyncCallback(ReceiveCallback), null);
                this.textBox1.Text += "登录服务器成功" + "\r\n";
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 回调时调用
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallback(IAsyncResult ar)
        {
            int rEnd = ClientSocket.EndReceive(ar);
            this.Invoke((MethodInvoker)delegate
                 {
                     lock (this.textBox1)
                     {
                         this.textBox1.Text += Encoding.Unicode.GetString(MsgBuffer, 0, rEnd) + "\r\n";
                     }
                 });
            ClientSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallback), null);
        }
        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MsgSend = Encoding.Unicode.GetBytes("说：\n" + this.textBox2.Text + "\n\r");
            if (ClientSocket.Connected)
            {
                ClientSocket.Send(MsgSend);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
