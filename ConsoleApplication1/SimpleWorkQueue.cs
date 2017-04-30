using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public delegate void WorkItem();
    public class SimpleWorkQueue
    {
        private bool isWork = false;
        private Thread workThread;
        private ConcurrentQueue<WorkItem> queue;

        public SimpleWorkQueue()
        {
            queue = new ConcurrentQueue<WorkItem>();
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="workItem"></param>
        public void Enqueue(WorkItem workItem)
        {
            queue.Enqueue(workItem);
            //通知线程开始处理工作,这里做了并发处理
            if (!isWork)
            {
                Monitor.Enter(this);
                if (!isWork)
                {
                    isWork = true;
                    Resume();
                }
                Monitor.Exit(this);
            }
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <returns></returns>
        public WorkItem Dequeue()
        {
            WorkItem result = null;
            if (!queue.TryDequeue(out result))
                Kill();
            return result;
        }

        /// <summary>
        /// 开始工作
        /// </summary>
        private void DoWork()
        {
            if (!isWork || queue.Count <= 0)
                Kill();
            else
            {
                WorkItem workItem;
                //循环执行队列中的工作
                while ((workItem = Dequeue()) != null)
                {
                    workItem();
                }
                isWork = false;
            }
        }

        /// <summary>
        /// 杀死work线程
        /// </summary>
        private void Kill()
        {
            if (workThread.IsAlive)
            {
                try
                {
                    workThread.Abort();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    isWork = false;
                }
            }
        }

        /// <summary>
        /// 重新启动工作线程
        /// </summary>
        private void Resume()
        {
            if (workThread == null || !workThread.IsAlive)
            {
                workThread = new Thread(DoWork);
                workThread.Start();
            }
        }
    }
}
