using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
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

namespace Service
{
    public partial class Server : Form
    {
        private static object oProduct = new object();
        private static object oDistribution = new object();
        private Socket socket = null;
        private Thread thread = null;
        /// <summary>
        /// 产品期数
        /// </summary>
        private int pissue = 0;
        private static ConcurrentQueue<int> concurqueueProduct { get; set; }
        public Server()
        {
            InitializeComponent();
            //StartListening();
            concurqueueProduct = new ConcurrentQueue<int>();
        }
        /// 
        /// 开始监听客户端
        /// 
        private void StartListening()
        {
            try
            {
                string ipPoint = txtPoint.Text.Trim();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ipaddress = IPAddress.Parse("127.0.0.1");
                //IPEndPoint endPoint = new IPEndPoint(ipaddress, int.Parse("3000"));
                IPEndPoint endPoint = new IPEndPoint(ipaddress, int.Parse(ipPoint));

                socket.Bind(endPoint);
                socket.Listen(20);

                thread = new Thread(new ThreadStart(WatchConnection));
                thread.IsBackground = true;
                thread.Start();

                //this.listBox1.Text = "开始监听客户端传来的消息" + "\r\n";
                this.textBox1.Text = "开始监听客户端传来的消息";
            }
            catch (System.Exception ex)
            {
                //this.listBox1.Text += "SocketException" + ex;
                this.textBox1.Text += "SocketException" + ex;
            }
        }

        Socket[] socConnection = new Socket[12];
        private static int clientNum = 0;

        /// <summary>
        /// 监听客户端发来的请求
        /// </summary>
        private void WatchConnection()
        {
            while (true)
            {
                socConnection[clientNum] = socket.Accept();
                this.Invoke((MethodInvoker)delegate
                {
                    //this.listBox1.Text += "客户端连接成功" + "\r\n";
                    this.textBox1.Text += "客户端连接成功" + "\r\n";
                });

                Thread thread = new Thread(new ParameterizedThreadStart(ServerRecMsg));
                thread.IsBackground = true;
                thread.Start(socConnection[clientNum]);
                clientNum++;
            }
        }

        /// <summary>
        /// 接受客户端消息并发送消息
        /// </summary>
        /// <param name="socketClientPara"></param>
        private void ServerRecMsg(object socketClientPara)
        {
            Socket socketServer = socketClientPara as Socket;
            try
            {
                while (true)
                {
                    byte[] arrServerRecMsg = new byte[1024 * 1024];
                    int length = socketServer.Receive(arrServerRecMsg);

                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    this.Invoke((MethodInvoker)delegate
                    {
                        //this.listBox1.Text += "接收到：" + strSRecMsg + "\r\n";
                        this.textBox1.Text += "接收到：" + strSRecMsg + "\r\n";
                        //JObject jo = (JObject)JsonConvert.DeserializeObject(strSRecMsg);
                        //int userid = 
                       
                        //获取分配的号码
                        //Users user = new Users { UserId = 396961, PIssue = 1, Count = 10, IsSuccess = 0 };
                        Users user = DistributionNums(new Users { UserId = 396961, PIssue = 1, Count = 10, IsSuccess = 0 });
                        //byte[] arrSendMsg = Encoding.UTF8.GetBytes("收到服务器发来的消息数字:" + strSRecMsg);
                        byte[] arrSendMsg = Encoding.UTF8.GetBytes("收到服务器发来的消息数字:" + user.Nums);
                        //发送消息到客户端
                        socketServer.Send(arrSendMsg);
                        if(concurqueueProduct.Count==0)
                        {
                            LoadProduct();
                        }
                    });

                    //byte[] arrSendMsg = Encoding.UTF8.GetBytes("收到服务器发来的消息数字" + strSRecMsg);
                    ////发送消息到客户端
                    //socketServer.Send(arrSendMsg);
                }
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 分配夺宝号码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private Users DistributionNums(Users user)
        {
            lock (oDistribution)
            {
                if (user.PIssue == pissue)
                {
                    if(concurqueueProduct.Count>=user.Count)
                    {
                        while (user.Count>0)
                        {
                            int localValue;
                            if(concurqueueProduct.TryDequeue(out localValue))
                            {
                                user.Nums += localValue.ToString() + ",";
                                user.Count--;
                            }
                            
                        }
                        user.IsSuccess = 1;
                        lblLeftOver.Text = concurqueueProduct.Count.ToString();
                    }
                }
                else
                {
                    user.Err = "该期号码已经分配完";
                }
            }
            return user;
        }
        
        
        /// <summary>
        /// 启动服务按纽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartService_Click(object sender, EventArgs e)
        {
            bool flag = ValidateTxtbox();
            if (flag)
            {
                //加载产品
                LoadProduct();
                //开始期数
                pissue = Convert.ToInt32(txtPIssue.Text.Trim());
                
                //剩余夺宝数量
                lblLeftOver.Text = concurqueueProduct.Count.ToString();
                lblPissue.Text = pissue.ToString();
                //开始监听
                StartListening();

                this.btnStartService.Enabled = false;
                this.txtPcount.Enabled = false;
                this.txtPIssue.Enabled = false;
                this.txtPname.Enabled = false;
                this.txtPoint.Enabled = false;
                this.Text = this.txtPname.Text + " 服务器端";
            }
        }
        /// <summary>
        /// 装载产品
        /// </summary>
        private void LoadProduct()
        {
            lock (oProduct)
            {
                if (concurqueueProduct.Count == 0)
                {
                    int count = Convert.ToInt32(txtPcount.Text.Trim());
                    List<int> liasc = new List<int>();
                    List<int> lirandom = new List<int>();
                    for (int i = 1; i <= count; i++)
                    {
                        liasc.Add(10000000 + i);
                    }
                    Random rd = new Random(DateTime.Now.Millisecond);
                    while (liasc.Count > 0)
                    {
                        int rdIndex = rd.Next(0, liasc.Count - 1);
                        int remove = liasc[rdIndex];
                        liasc.Remove(remove);
                        concurqueueProduct.Enqueue(remove);
                    }
                    pissue++;
                }
            }
        }
        /// <summary>
        /// 验证文本框
        /// </summary>
        /// <returns></returns>
        private bool ValidateTxtbox()
        {
            if(txtPcount.Text.Trim()=="")
            {
                MessageBox.Show("参与人次不能为空");
                return false;
            }
            else if(txtPoint.Text.Trim()=="")
            {
                MessageBox.Show("端口号不能为空");
                return false;
            }
            else if (txtPIssue.Text.Trim() == "")
            {
                MessageBox.Show("夺宝期数不能为空");
                return false;
            }
            return true;
        }
    }
}
