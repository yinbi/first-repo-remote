using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ThreadTest : System.Web.UI.Page
    {
        protected work w;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["work"] == null)
            {
                w = new work();
                Session["work"] = w;
            }
            else
            {
                w = (work)Session["work"];
            }
            switch (w.State)
            {
                case 0:
                    {
                        this.lab_state.Text = "还没有开始任务";
                        break;
                    }
                case 1:
                    {
                        this.lab_state.Text = "任务进行了" + ((TimeSpan)(DateTime.Now - w.StartTime)).TotalSeconds + "秒";
                        this.btn_startwork.Enabled = false;
                        Page.RegisterStartupScript("", "<script>window.setTimeout(’locationlocation.href=location.href’,1000);</script>");
                        //不断的刷新本页面，随时更新任务的状态   
                        break;
                    }
                case 2:
                    {
                        this.lab_state.Text = "任务结束,并且成功执行所有操作,用时" + ((TimeSpan)(w.FinishTime - w.StartTime)).TotalSeconds + "秒";
                        this.btn_startwork.Enabled = true;
                        break;
                    }
                case 3:
                    {
                        this.lab_state.Text = "任务结束,在" + ((TimeSpan)(w.ErrorTime - w.StartTime)).TotalSeconds + "秒的时候发生错误导致任务失败";
                        this.btn_startwork.Enabled = true;
                        break;
                    }
            }
        }

        protected void btn_startwork_Click(object sender, EventArgs e)
        {
            if (w.State != 1)
            {
                this.btn_startwork.Enabled = false;
                w.runwork();
                Page.RegisterStartupScript("", "<script>locationlocation.href=location.href;</script>");
                //立即刷新页面   
                //while (w.State != 2)
                //{
                //    if(w.State==2)
                //    {
                //        Page.RegisterStartupScript("", "<script>locationlocation.href=location.href;</script>");
                //    }
                //}
            } 
        }

    }

    public class work
    {
        public int State = 0;//0-没有开始,1-正在运行,2-成功结束,3-失败结束   
        public int i = 50000;
        public DateTime StartTime;
        public DateTime FinishTime;
        public DateTime ErrorTime;
        public void runwork()
        {
            //lock (this)//确保临界区被一个Thread所占用   
            //{
                if (State != 1)
                {
                    State = 1;
                    StartTime = DateTime.Now;
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(dowork));
                    thread.Name = "thread1";

                    System.Threading.Thread thread2 = new System.Threading.Thread(new System.Threading.ThreadStart(dowork));
                    thread2.Name = "thread2";

                    System.Threading.Thread thread3 = new System.Threading.Thread(new System.Threading.ThreadStart(dowork));
                    thread3.Name = "thread3";

                    thread.Start();
                    thread2.Start();
                    thread3.Start();
                }
           // }
           
        }

        private void dowork()
        {
            try
            {
                //SqlConnection conn=new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["conn"]);   
                //SqlCommand cmd=new SqlCommand("Insert Into test (test)values(’test’)",conn);   
                //conn.Open();   
                //for(int i=0;i<5000;i++)cmd.ExecuteNonQuery();   
                //conn.Close();   
                ////以上代码执行一个比较消耗时间的数据库操作   
                //for (int i = 0; i < 5000; i++)
                //{
                //    int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                //    string str = string.Format("当前线程ID{0},i={1}", threadId, i);
                //    Log.Write("log", str);
                //}
                while (i > 0)
                {
                    //int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
                    //string threadName=System.Threading.Thread.CurrentThread.Name;
                    //string str = string.Format("当前线程名:{0},ID{1},i={2}", threadName, threadId, i);
                    //Log.Write("log", str);
                    i--;
                }
                State = 2;
            }
            catch
            {
                ErrorTime = DateTime.Now;
                State = 3;
            }
            finally
            {
                FinishTime = DateTime.Now;   
            }
        }
    }
}
