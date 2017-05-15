using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    //public delegate void MyTransHandler<TParam1>(TParam1 param1);
    /// <summary>
    /// 发布事件类
    /// </summary>
    public class Person
    {
        /// <summary>
        /// (发布)事件参数类
        /// </summary>
        public class TransEventAgrs : EventArgs
        {
            public string word;
            public TransEventAgrs(string str)
            {
                word = str;
            }
        }
        //定义delegate
        public delegate void TranslateEventHandler(object send, TransEventAgrs e);

        //事件对象
        public event TranslateEventHandler TransEvent;

        //事件触发方法
        public virtual void OnTransEvent(TransEventAgrs e)
        {
            if (TransEvent != null)
            {
                TransEvent(this, e);
            }
        }
        //引发事件
        public void Speak(string str)
        {
            TransEventAgrs e = new TransEventAgrs(str);
            OnTransEvent(e);
        }


    }
    //(订阅)监听事件类 (重复器)
    public class TransEventListener
    {
        //定义本地处理事件的方法 他与声明的事件delegate有相同的参数和返回值类型
        public void ProduceSound(object sender, Person.TransEventAgrs e)
        {
            Console.WriteLine(string.Format("事件触发者:{0},说:{1}", sender, e.word));
        }
        //订阅事件
        public void Subscribe(Person person)
        {
            person.TransEvent += new Person.TranslateEventHandler(ProduceSound);
        }
        //取消订阅事件
        public void UnSubscribe(Person person)
        {
            person.TransEvent -= new Person.TranslateEventHandler(ProduceSound);
        }

    }
    //class Program
    //{
    //    #region
    //    //static void Main(string[] args)
    //    //{
    //    //    MyTransHandler<string> mydele = new MyTransHandler<string>(TransToCN);
    //    //    //MyTransHandler<string> mydele = TransToCN;
    //    //    mydele("speak");
    //    //    Console.ReadKey();
    //    //}
    //    //static void Translate(string str, MyTransHandler<string> transDele)
    //    //{
    //    //    transDele(str);
    //    //}
    //    //static void TransToCN(string str)
    //    //{
    //    //    Console.Write(string.Format("translage zh-cn:{0}", str));
    //    //}
    //    //static void TransToEC(string str)
    //    //{
    //    //    Console.Write(string.Format("translage en-us:{0}", str));
    //    //}
    //    #endregion
    //    static void Main(string[] args)
    //    {
    //        //创建事件源对象
    //        Person person = new Person();
    //        //创建监听对象
    //        TransEventListener changer = new TransEventListener();

    //        //订阅事件
    //        Console.WriteLine("订阅事件");
    //        changer.Subscribe(person);

    //        //引发事件
    //        Console.WriteLine("引发事件");
    //        person.Speak("我说了一句话，你们去翻译吧");
    //        person.Speak("我又说了一句话，你们去翻译吧");

    //        //取消订阅事件
    //        Console.WriteLine("取消订阅事件");
    //        changer.UnSubscribe(person);

    //        //引发事件
    //        Console.WriteLine("引发事件");
    //        person.Speak("我再次说了一句话，你们去翻译吧");
    //        Console.ReadKey();
    //    }
    //}

    /// <summary>
    /// 端口转发，另外端口替换3389
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener tl = new TcpListener(IPAddress.Parse("192.168.1.57"), 30012);//这里开对方可以被你连接并且未被占用的端口
            tl.Start();
            while (true)//这里必须用循环，可以接收不止一个客户，因为我发现终端服务有时一个端口不行就换一个端口重连
            {
                //下面的意思就是一旦程序收到你发送的数据包后立刻开2个线程做中转
                try
                {
                    TcpClient tc1 = tl.AcceptTcpClient();//这里是等待数据再执行下边，不会100%占用cpu
                    TcpClient tc2 = new TcpClient("127.0.0.1", 3389);
                    tc1.SendTimeout = 300000;//设定超时，否则端口将一直被占用，即使失去连接
                    tc1.ReceiveTimeout = 300000;
                    tc2.SendTimeout = 300000;
                    tc2.ReceiveTimeout = 300000;
                    object obj1 = (object)(new TcpClient[] { tc1, tc2 });
                    object obj2 = (object)(new TcpClient[] { tc2, tc1 });
                    ThreadPool.QueueUserWorkItem(new WaitCallback(transfer), obj1);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(transfer), obj2);
                }
                catch { }
            }
        }
        public static void transfer(object obj)
        {
            TcpClient tc1 = ((TcpClient[])obj)[0];
            TcpClient tc2 = ((TcpClient[])obj)[1];
            NetworkStream ns1 = tc1.GetStream();
            NetworkStream ns2 = tc2.GetStream();
            while (true)
            {
                try
                {
                    //这里必须try catch，否则连接一旦中断程序就崩溃了，要是弹出错误提示让机主看见那就囧了
                    byte[] bt = new byte[10240];
                    int count = ns1.Read(bt, 0, bt.Length);
                    ns2.Write(bt, 0, count);
                }
                catch
                {
                    ns1.Dispose();
                    ns2.Dispose();
                    tc1.Close();
                    tc2.Close();
                    break;
                }
            }
        }
    }
}
