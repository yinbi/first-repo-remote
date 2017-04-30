using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using Microsoft.Web.Administration;
using IISMonitor_Web;

namespace IISMonitor
{

    public  class MonitorHelper
    {

        /// <summary>
        /// IIS6.0检测当前线程池是否正常开启
        /// </summary>
        public static void MonitoringISS6AppPool()
        {

            //DirectoryEntry getEntity = new DirectoryEntry("IIS://localhost/W3SVC/INFO");
            //string Version = getEntity.Properties["MajorIISVersionNumber"].Value.ToString();
            //Console.WriteLine("IIS版本为:" + Version);
            AppPoolService.CheckAllAppPools();
            AppPoolService.CheckAllSites();

        }
        /// <summary>
        /// IIS7.0检测当前线程池是否正常开启  
        /// </summary>
        public static void MonitoringISS7AppPool()
        {
            ServerManager sm = new ServerManager();

            foreach (var s in sm.ApplicationPools)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("应用程序池名：{0},", s.Name);
                System.Console.WriteLine("运行状态：{0},", s.State.ToString());
                //if (s.Name == "updata" || s.Name == "download")
                //{
                //    System.Console.WriteLine();
                //    System.Console.WriteLine("应用程序池名：{0},", s.Name);
                //    System.Console.WriteLine("运行状态：{0},", s.State.ToString());

                //    if (s.State.ToString().ToLower() != "started")
                //    {
                //        StringBuilder sb = new StringBuilder();
                //        sb.Append(string.Format("应用程序池名：{0},", s.Name));
                //        sb.Append(string.Format("运行状态：{0},", s.State.ToString()));
                //        try
                //        {
                //            s.Start();
                //        }
                //        catch (Exception e)
                //        {
                //        }
                //        sb.Append(string.Format("启动后运行状态：{0}", s.State.ToString()));
                //        WriteLog.Write("log", sb.ToString());

                //        System.Console.WriteLine("操作后运行状态：{0},", s.State.ToString());
                //    }
                //}
            }
            foreach (var s in sm.Sites)//遍历网站
            {
                System.Console.WriteLine();
                System.Console.WriteLine("网站名称：{0}", s.Name);
                System.Console.WriteLine("运行状态：{0}", s.State.ToString());
                //if (s.Name == "updata" || s.Name == "download")
                //{
                //    System.Console.WriteLine();
                //    System.Console.WriteLine("网站名称：{0}", s.Name);
                //    System.Console.WriteLine("运行状态：{0}", s.State.ToString());
                    
                //    if (s.State.ToString().ToLower() != "started")
                //    {
                //        StringBuilder sb = new StringBuilder();
                //        sb.Append(string.Format("网站名称：{0},", s.Name));
                //        sb.Append(string.Format("编号：{0},", s.Id));
                //        sb.Append(string.Format("运行状态：{0},", s.State.ToString()));
                //        try
                //        {
                //            s.Start();
                //        }
                //        catch (Exception e)
                //        {
                //        }
                //        sb.Append(string.Format("\t启动后运行状态：{0}", s.State.ToString()));
                //        WriteLog.Write("log", sb.ToString());

                //        System.Console.WriteLine("操作后运行状态：{0}", s.State.ToString());
                //    }
                //}
                
            }
            
        }
    }
}
