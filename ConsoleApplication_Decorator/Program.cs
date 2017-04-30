using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication_Decorator
{
    
    class Program
    {
        const int MAX_LOOP_TIME = 100;
        Queue m_smplQueue;

        public Program()
        {
            m_smplQueue = new Queue();
        }
        public void FirstThread()
        {
            int counter = 0;
            lock (m_smplQueue)
            {
                while (counter < MAX_LOOP_TIME)
                {
                    //Wait, if the queue is busy.
                    //将当前拥有锁的线程流放到等待队列，直到再次调用才继续否则一直阻塞
                    Monitor.Wait(m_smplQueue);
                    //Push one element.
                    //向队列添加元素
                    m_smplQueue.Enqueue(counter);
                    //Release the waiting thread.
                    //给等待队列中的线程一次进入就绪队列的机会（由于这个案例中只有三个线程：主线程两个工作线程）
                    Monitor.Pulse(m_smplQueue);

                    counter++;
                }
                //int i = 0;
            }
        }
        public void SecondThread()
        {
            lock (m_smplQueue)
            {
                //Release the waiting thread.
                //将一个等待队列中的线程进入就绪队列（一旦当前线程Exit不在拥有锁则就绪队列中的线程可以拥有同步锁）
                Monitor.Pulse(m_smplQueue);
                //Wait in the loop, while the queue is busy.
                //Exit on the time-out when the first thread stops.
                //在一个循环中等待，直到Wait再次获得线程的拥有权，或者超时（返回true）,否则一直阻塞返回false
                while (Monitor.Wait(m_smplQueue, 50000))
                {
                    //Pop the first element.
                    //弹出第一个元素
                    int counter = (int)m_smplQueue.Dequeue();
                    //Print the first element.
                    //打印第一个元素
                    Console.WriteLine(counter.ToString());
                    //Release the waiting thread.
                    //打印完之后，让另外一个等待队列的线程进入就绪队列
                    Monitor.Pulse(m_smplQueue);
                }
            }
        }
        //Return the number of queue elements.
        public int GetQueueCount()
        {
            return m_smplQueue.Count;
        }
        static void Main(string[] args)
        {
             //Create the MonitorSample object.
            Program test = new Program();
            //Create the first thread.
            Thread tFirst = new Thread(new ThreadStart(test.FirstThread));
            //Create the second thread.
            Thread tSecond = new Thread(new ThreadStart(test.SecondThread));
            //Start threads.
            tFirst.Start();
            tSecond.Start();
            //wait to the end of the two threads
            //使用此方法确保线程已终止。如果线程不终止，则调用方将无限期阻塞，如果调用Join时该线程已终止，此方法将立即返回。
            //使用Join方便得到Queue的最终元素个数
            tFirst.Join();
            tSecond.Join();
            //Print the number of queue elements.
            Console.WriteLine("Queue Count = " + test.GetQueueCount().ToString());
            //MyThread myt = new MyThread();
            //while (true)
            //{
            //    Console.WriteLine("输入 stop后台线程挂起 start 开始执行！");
            //    string str = Console.ReadLine();
            //    if (str.ToLower().Trim() == "stop")
            //    {
            //        myt.Stop();
            //    }
            //    if (str.ToLower().Trim() == "start")
            //    {
            //        myt.Start();
            //    }
            //}
            //Timer _pingTimer = new Timer(PingTimer_Elapsed, null, Timeout.Infinite, Timeout.Infinite);
            //_pingTimer.Change(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
            Console.ReadKey();
        }
        
        public static void PingTimer_Elapsed(object state)
        {
            Console.WriteLine(DateTime.Now.ToString());
        }
    }
    class MyThread
    {
        Thread t = null;
        ManualResetEvent manualEvent = new ManualResetEvent(true);//为trur,一开始就可以执行
        private void Run()
        {
            while (true)
            {
                this.manualEvent.WaitOne();
                Console.WriteLine("这里是  {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
            }
        }
        public void Start()
        {
            this.manualEvent.Set();
        }
        public void Stop()
        {
            this.manualEvent.Reset();
        }
        public MyThread()
        {
            t = new Thread(this.Run);
            t.Start();
        }

    }


    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// 声明一个Component的抽象基类
    /// </summary>
    abstract class Component
    {
        public abstract void Operation();
    }

    /// <summary>
    ///声明一个具体的Component，继承Component
    /// </summary>
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    /// <summary>
    /// 声明一个抽象的装饰类'Decorator'
    /// 并继承Component
    /// </summary>
    abstract class Decorator : Component
    {
        protected Component component;

        //装饰方法
        public void SetComponent(Component component)
        {
            this.component = component;
        }

        //重写 Operation 方法
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    /// <summary>
    /// 声明一个具体装饰类A，继承Decorator
    /// </summary>
    class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            //一些功能扩展
            Console.WriteLine("ConcreteDecoratorA.Operation()");
            base.Operation();
        }
    }

    /// <summary>
    /// 声明一个具体装饰类B，继承Decorator
    /// </summary>
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            //一些功能扩展
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
            base.Operation();
        }

        //装饰类B自有方法
        void AddedBehavior()
        {
        }
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        ConcreteComponent c = new ConcreteComponent();
    //        ConcreteDecoratorA d1 = new ConcreteDecoratorA();
    //        ConcreteDecoratorB d2 = new ConcreteDecoratorB();

    //        d1.SetComponent(c);
    //        d2.SetComponent(d1);
    //        d2.Operation();

    //        Console.ReadKey();
    //    }
    //}
}
