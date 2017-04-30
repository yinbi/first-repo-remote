using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public  class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int SellPrice { get; set; }
    }
    public class ConcurrentQueueTset
    {
        private static object o = new object();
        /*定义 Queue*/
        private static Queue<Product> _Products { get; set; }
        private static ConcurrentQueue<Product> _ConcurrenProducts { get; set; }
        /*  coder:释迦苦僧  
         *  代码中 创建三个并发线程 来操作_Products 和 _ConcurrenProducts 集合，每次添加 10000 条数据 查看 一般队列Queue 和 多线程安全下的队列ConcurrentQueue 执行情况
         */
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
    }
}
