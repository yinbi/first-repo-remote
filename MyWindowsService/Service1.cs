using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;

namespace MyWindowsService
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public Service1()
        {
            InitializeComponent();
            timer.Interval = 10000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimerEvent);
        }

        protected override void OnStart(string[] args)
        {
            FileStream fs = new FileStream(@"f:\MyWindowsService.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("WindowsService: Service Started!" + DateTime.Now.ToString() + "\n");
            timer.Enabled = true;
            timer.Start();
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        protected override void OnStop()
        {
            FileStream fs = new FileStream(@"f:\MyWindowsService.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("WindowsService: Service Stopped!" + DateTime.Now.ToString() + "\n");
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        void OnTimerEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            FileStream fs = new FileStream(@"f:\MyWindowsService.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine("WindowsService: api call!" + DateTime.Now.ToString() + "\n");
            sw.Flush();
            sw.Close();
            fs.Close();
            
            //string strResult;
            int timeout = 120000;
            string strUrl = "http://192.168.1.223/fjk3/UpdateLotteryResult";
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                //strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                //strResult = "err";
            }
            //sw.WriteLine("WindowsService: api call end!" + DateTime.Now.ToString() + "\n");
           
        }


    
    }
}
