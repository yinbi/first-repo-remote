using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   
    class Program
    {
        //private static int index = 200;

        private static object o = new object();
        /*定义 Queue*/
        private static Queue<Product> _Products { get; set; }
        private static ConcurrentQueue<Product> _ConcurrenProducts { get; set; }

        private static ConcurrentQueue<int> concurqueue { get; set; }
        /*  coder:释迦苦僧  
         *  代码中 创建三个并发线程 来操作_Products 和 _ConcurrenProducts 集合，每次添加 10000 条数据 查看 一般队列Queue 和 多线程安全下的队列ConcurrentQueue 执行情况
         */
        static void Main(string[] args)
        {
            string datetimeStart = "2017-04-01";
            string datetimeEnd = "2017-04-06";
            DateTime dStart = Convert.ToDateTime(datetimeStart);
            DateTime dEnd = Convert.ToDateTime(datetimeEnd);
            int days = (dEnd - dStart).Days;
            #region
            ////SimpleWorkQueue queue = new SimpleWorkQueue();
            ////Action action1 = () => { queue.Enqueue(AddWork); };
            ////Action action2 = () => { queue.Enqueue(DoWork); };
            ////Action action3 = () => { queue.Enqueue(AddWork); };
            ////Action action4 = () => { queue.Enqueue(DoWork); };
            ////Parallel.Invoke(action1, action2, action3, action4);


            //// Construct a ConcurrentQueue.
            //ConcurrentQueue<int> cq = new ConcurrentQueue<int>();

            //// Populate the queue.
            //for (int i = 0; i < 10000; i++) cq.Enqueue(i);

            //// Peek at the first element.
            //int result;
            //if (!cq.TryPeek(out result))
            //{
            //    Console.WriteLine("CQ: TryPeek failed when it should have succeeded");
            //}
            //else if (result != 0)
            //{
            //    Console.WriteLine("CQ: Expected TryPeek result of 0, got {0}", result);
            //}

            //int outerSum = 0;
            //// An action to consume the ConcurrentQueue.
            //Action action = () =>
            //{
            //    int localSum = 0;
            //    int localValue;
            //    while (cq.TryDequeue(out localValue))
            //    {
            //        localSum += localValue;
            //    }
            //    Interlocked.Add(ref outerSum, localSum);
            //};


            ////Parallel.Invoke(action);
            ////Parallel.Invoke(action, action);
            //// Start 4 concurrent consuming actions.
            ////Parallel.Invoke(action, action, action, action);


            //Console.WriteLine("outerSum = {0}, should be 49995000", outerSum);
            //Console.ReadKey();
            //return;
            #endregion


            Thread.Sleep(1000);
            _Products = new Queue<Product>();
            Stopwatch swTask = new Stopwatch();
            swTask.Start();

            /*创建任务 t1  t1 执行 数据集合添加操作*/
            Task t1 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });
            /*创建任务 t2  t2 执行 数据集合添加操作*/
            Task t2 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });
            /*创建任务 t3  t3 执行 数据集合添加操作*/
            Task t3 = Task.Factory.StartNew(() =>
            {
                AddProducts();
            });

            Task.WaitAll(t1, t2, t3);
            swTask.Stop();
            Console.WriteLine("List<Product> 当前数据量为：" + _Products.Count);
            Console.WriteLine("List<Product> 执行时间为：" + swTask.ElapsedMilliseconds);

            Thread.Sleep(1000);
            concurqueue = new ConcurrentQueue<int>();
            for (int i = 0; i < 30; i++)
            {
                concurqueue.Enqueue(i);
            }
            Stopwatch swTask1 = new Stopwatch();
            swTask1.Start();

            UserInfo user1 = new UserInfo { UserName = "tk1", DuobaoNum = 10 };
            UserInfo user2 = new UserInfo { UserName = "tk2", DuobaoNum = 9 };
            UserInfo user3 = new UserInfo { UserName = "tk3", DuobaoNum = 11 };

            /*创建任务 tk1  tk1 执行 数据集合添加操作*/
            Task tk1 = Task.Factory.StartNew(() =>
            {
                //AddConcurrenProducts();
               
                //SubConcurrenProducts(user1);
                GetDuoBaoNums(user1);
            });
            /*创建任务 tk2  tk2 执行 数据集合添加操作*/
            Task tk2 = Task.Factory.StartNew(() =>
            {
                //AddConcurrenProducts();
                
                //SubConcurrenProducts(user2);
                GetDuoBaoNums(user2);
            });
            /*创建任务 tk3  tk3 执行 数据集合添加操作*/
            Task tk3 = Task.Factory.StartNew(() =>
            {
                //AddConcurrenProducts();
               
                //SubConcurrenProducts(user3);
                GetDuoBaoNums(user3);
            });

            Task.WaitAll(tk1, tk2, tk3);
            swTask1.Stop();
            //Console.WriteLine("ConcurrentQueue<Product> 当前数据量为：" + _ConcurrenProducts.Count);
           // Console.WriteLine("ConcurrentQueue<Product> 执行时间为：" + swTask1.ElapsedMilliseconds);
            Console.WriteLine("输出:");
            Console.WriteLine(string.Format("username:{0};count:{1},nums:{2}", user1.UserName, user1.Count, user1.Nums));
            Console.WriteLine(string.Format("username:{0},count:{1},nums:{2}", user2.UserName, user2.Count, user2.Nums));
            Console.WriteLine(string.Format("username:{0},count:{1},nums:{2}", user3.UserName, user3.Count, user3.Nums));
            Console.WriteLine(string.Format("concurqueue.count={0}", concurqueue.Count));
            Console.ReadLine();
        }
        

        /*执行集合数据添加操作*/
        static void AddProducts()
        {
            Parallel.For(0, 30000, (i) =>
            {
                Product product = new Product();
                product.Name = "name" + i;
                product.Category = "Category" + i;
                product.SellPrice = i;
                lock (o)
                {
                    _Products.Enqueue(product);
                }
            });

        }
        /*执行集合数据添加操作*/
        static void AddConcurrenProducts()
        {
            Parallel.For(0, 30000, (i) =>
            {
                Product product = new Product();
                product.Name = "name" + i;
                product.Category = "Category" + i;
                product.SellPrice = i;
                _ConcurrenProducts.Enqueue(product);
            });

        }
        static void GetDuoBaoNums(UserInfo user)
        {
            int localValue;
            for (int i = 0; i < user.DuobaoNum; i++)
            {
                Console.WriteLine(string.Format("{0},{1}", user.UserName, i));
                //localValue = i;
                if (user.Count < user.DuobaoNum)
                {
                    if (concurqueue.TryDequeue(out localValue))
                    {
                        if (user.Count < user.DuobaoNum)
                        {
                            user.Nums += localValue.ToString() + ",";
                            user.Count++;
                            Console.WriteLine(string.Format("username:{0};count:{1};nums:{2};localValue:{3};", user.UserName, user.Count, user.Nums, localValue));
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("已经移除 username:{0};count:{1};nums:{2};localValue:{3};", user.UserName, user.Count, user.Nums, localValue));
                    }
                }
            }
        }
        static void SubConcurrenProducts(UserInfo user)
        {
            int localValue;
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(string.Format("{0},{1}", user.UserName, i));
                //localValue = i;
                if (user.Count < 10)
                {
                    if (concurqueue.TryDequeue(out localValue))
                    {
                        if (user.Count < 10)
                        {
                            user.Nums += localValue.ToString() + ",";
                            user.Count++;
                            Console.WriteLine(string.Format("username:{0};count:{1};nums:{2};localValue:{3};", user.UserName, user.Count, user.Nums, localValue));
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("已经移除 username:{0};count:{1};nums:{2};localValue:{3};", user.UserName, user.Count, user.Nums, localValue));
                    }
                }
            }

            //int i = 0;
            //int localValue = i;
            //while (concurqueue.TryDequeue(out localValue))
            //{
            //    Console.WriteLine(string.Format("{0},{1}", user.UserName, i));
            //    if (user.Count < 10)
            //    {
            //        user.Nums += localValue.ToString() + ",";
            //        user.Count++;
            //        i++;
            //        Console.WriteLine(string.Format("username:{0};count:{1};nums:{2};localValue:{3};", user.UserName, user.Count, user.Nums, localValue));
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}
        }
        class UserInfo
        {
            List<int> liNum;
            string nums;
            int duobaoNum;

            public UserInfo()
            {
                liNum = new List<int>();
            }
            public string UserName { get; set; }
            public int Count { get; set; }
            public List<int> LiNum
            {
                get { return liNum; }
                set { liNum = value; }
            }
            public string Nums
            {
                get { return nums; }
                set { nums = value; }
            }
            public int DuobaoNum
            {
                get { return duobaoNum; }
                set { duobaoNum = value; }
            }

        }

        class Product
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public int SellPrice { get; set; }
        }

        //private static void DoWork()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        index = index - 1;
        //        Console.WriteLine(index);
        //    }
        //}

        //private static void AddWork()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        index = index + 1;
        //        Console.WriteLine(index);
        //    }
        //}
    }
}
