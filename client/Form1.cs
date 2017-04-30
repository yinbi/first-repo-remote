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
using System.Windows.Forms;

namespace client
{
    public partial class client : Form
    {
        private Socket socketClient = null;
        private Thread threadClient = null;
        public client()
        {
            InitializeComponent();
            ConnectionServer();
            this.button1.Click += new EventHandler(button1_Click);
        }
        /// <summary>
        /// 连接服务器
        /// </summary>
        private void ConnectionServer()
        {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ipaddress, int.Parse("3000"));
            try
            {
                socketClient.Connect(endPoint);
                threadClient = new Thread(RecMsg);
                threadClient.IsBackground = true;
                threadClient.Start();
            }
            catch (System.Exception ex)
            {

            }

        }

        /// <summary>
        /// 接收服务器消息
        /// </summary>
        private void RecMsg()
        {
            while (true)
            {
                //内存缓冲区1M,用于临时存储接收到服务器端的消息
                //byte[] arrRecMsg = new byte[1024 * 1024];
                byte[] arrRecMsg = new byte[1024];
                //将接收到的数据放入内存缓冲区，获取其长度
                int length = socketClient.Receive(arrRecMsg);
                //将套接字获取到的字节数组转换为我们可以理解的字符串
                string strRecMsg = Encoding.UTF8.GetString(arrRecMsg, 0, length);
                this.Invoke((MethodInvoker)delegate
                {
                    lock (this.textBox1)
                    {
                        this.textBox1.Text += "服务器：" + strRecMsg + "\r\n";
                    }
                });
            }
        }
        /// <summary>
        /// 向服务器发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ClientSendMsg(this.textBox2.Text.Trim());
        }
        /// <summary>
        /// 发送信息到服务器
        /// </summary>
        /// <param name="sendMsg"></param>
        private void ClientSendMsg(string sendMsg)
        {
            //将输入的字符串转化为机器可以识别的字节数组
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
            //发送数据
            socketClient.Send(arrClientSendMsg);
            this.textBox1.Text += "客户端：" + sendMsg + "\r\n";
        }
    }
}
