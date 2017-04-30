using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using System.Linq;
using System.Data;
using System.IO;
using IISMonitor;

namespace IISMonitor_Web
{
    /// <summary>  
    ///     IIS应用程序池辅助类  
    /// </summary>  
    public class AppPoolService
    {
        protected static string Host = "localhost";

        /// <summary>  
        ///     取得所有应用程序池  
        /// </summary>  
        /// <returns></returns>  
        public static List<string> GetAppPools()
        {
            DirectoryEntry appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
            System.Collections.IEnumerator enumerator = appPools.Children.GetEnumerator();
            DirectoryEntry subItem;
            while (enumerator.MoveNext())
            {
                subItem = (DirectoryEntry)enumerator.Current;
                Console.WriteLine();
                Console.WriteLine(string.Format("名称:{0}", subItem.Name));
                Console.WriteLine(string.Format("SchemaClassName={0}", subItem.SchemaClassName));
                Console.WriteLine(string.Format("状态:{0}", subItem.Properties["AppPoolState"].Value.ToString()));

                int intServerState = Convert.ToInt32(subItem.Properties["AppPoolState"].Value);
                if (intServerState != 2)
                {
                    try
                    {
                        subItem.Invoke("Start", null);
                        Console.WriteLine(string.Format("打开后状态:{0}", subItem.Properties["AppPoolState"].Value.ToString()));
                    }
                    catch (Exception e)
                    {
                    }
                }  
            }
            List<string> appPoollist = (from DirectoryEntry entry in appPools.Children select entry.Name).ToList();
            Console.WriteLine(string.Format("应用程序池数量:{0}",appPoollist.Count()));
            return appPoollist;
        }
        /// <summary>
        /// 检查所有应用程序池
        /// </summary>
        public static void CheckAllAppPools()
        {
            DirectoryEntry appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
            System.Collections.IEnumerator enumerator = appPools.Children.GetEnumerator();
            DirectoryEntry subItem;
            while (enumerator.MoveNext())
            {
                subItem = (DirectoryEntry)enumerator.Current;

                int intServerState = Convert.ToInt32(subItem.Properties["AppPoolState"].Value);
                if (intServerState != 2)
                {
                    //Console.WriteLine();
                    //Console.WriteLine(string.Format("SchemaClassName={0}", subItem.SchemaClassName));
                    //Console.WriteLine(string.Format("应用程序池名称:{0}", subItem.Name));
                    //Console.WriteLine(string.Format("应用程序池状态:{0}", subItem.Properties["AppPoolState"].Value.ToString()));

                    try
                    {
                        subItem.Invoke("Start", null);
                    }
                    catch (Exception e)
                    {
                    }
                    StringBuilder sb = new StringBuilder();
                    sb.Append(string.Format("应用程序池名称：{0},", subItem.Name));
                    sb.Append(string.Format("应用程序池状态：{0},", subItem.Properties["AppPoolState"].Value.ToString()));
                    WriteLog.Write("log", sb.ToString());
                }
            }
            #region #注释#
            //if (subItem.SchemaClassName == "IIsWebServer")
            //{
            //    //int intServerState = Convert.ToInt32(subItem.Properties["ServerState"].Value);
            //    //Console.WriteLine(string.Format("名称:{0}", subItem.Name));
            //    //Console.WriteLine(string.Format("状态:{0}", intServerState));
            //    //switch (intServerState)
            //    //{
            //    //    case 1:	//Starting
            //    //    case 2:	//Started
            //    //    case 3:	//Stopping
            //    //    case 4:	//Stopped
            //    //    case 5:	//Pausing
            //    //    case 6:	//Paused
            //    //    case 7:	//Continuing
            //    //    default://Unknown
            //    //}
            //}
            #endregion
        }
        /// <summary>
        /// 检查所有站点
        /// </summary>
        public static void CheckAllSites()
        {
            DataSet ds = new DataSet();
            string xmlPath = System.AppDomain.CurrentDomain.BaseDirectory + @"SiteId.xml";
            if (!File.Exists(xmlPath)) return;
            ds.ReadXmlSchema(xmlPath);
            ds.ReadXml(xmlPath, XmlReadMode.IgnoreSchema);
            if (ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0) return;

            DirectoryEntry webServers = new DirectoryEntry(string.Format("IIS://{0}/W3SVC", Host));
            System.Collections.IEnumerator enumerator = webServers.Children.GetEnumerator();

            DirectoryEntry subItem;
            while (enumerator.MoveNext())
            {
                subItem = (DirectoryEntry)enumerator.Current;
                if (subItem.SchemaClassName == "IIsWebServer")
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (subItem.Name == row["Name"].ToString())
                        {
                            int intServerState = Convert.ToInt32(subItem.Properties["ServerState"].Value);
                            if (intServerState != 2)
                            {
                                //Console.WriteLine();
                                //Console.WriteLine(string.Format("SchemaClassName={0}", subItem.SchemaClassName));
                                //Console.WriteLine(string.Format("网站标识符:{0}", subItem.Name));
                                //Console.WriteLine(string.Format("网站描述:{0}", row["Description"].ToString()));
                                //Console.WriteLine(string.Format("网站状态:{0}", subItem.Properties["ServerState"].Value.ToString()));
                                try
                                {
                                    subItem.Invoke("Start", null);
                                }
                                catch (Exception e)
                                {
                                }
                                StringBuilder sb = new StringBuilder();
                                sb.Append(string.Format("网站标识符：{0},", subItem.Name));
                                sb.Append(string.Format("网站描述：{0},", row["Description"].ToString()));
                                sb.Append(string.Format("网站状态：{0},", subItem.Properties["ServerState"].Value.ToString()));
                                WriteLog.Write("log", sb.ToString());
                            }
                        }
                    }
                }

            }
            ds.Dispose();
        }

        /// <summary>  
        /// 取得单个应用程序池  
        /// </summary>  
        /// <returns></returns>  
        public static ApplicationPool GetAppPool(string appPoolName)
        {
            ApplicationPool app = null;
            var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
            foreach (DirectoryEntry entry in appPools.Children)
            {
                if (entry.Name == appPoolName)
                {
                    var manager = new ServerManager();
                    app = manager.ApplicationPools[appPoolName];
                }
            }
            return app;
        }

        /// <summary>  
        ///     判断程序池是否存在  
        /// </summary>  
        /// <param name="appPoolName">程序池名称</param>  
        /// <returns>true存在 false不存在</returns>  
        public static bool IsAppPoolExsit(string appPoolName)
        {
            bool result = false;
            var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
            foreach (DirectoryEntry entry in appPools.Children)
            {
                if (entry.Name.Equals(appPoolName))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        /// <summary>  
        ///     删除指定程序池  
        /// </summary>  
        /// <param name="appPoolName">程序池名称</param>  
        /// <returns>true删除成功 false删除失败</returns>  
        public static bool DeleteAppPool(string appPoolName)
        {
            bool result = false;
            var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
            foreach (DirectoryEntry entry in appPools.Children)
            {
                if (entry.Name.Equals(appPoolName))
                {
                    try
                    {
                        entry.DeleteTree();
                       
                        result = true;
                        break;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        /// <summary>  
        ///     创建应用程序池  
        /// </summary>  
        /// <param name="appPool"></param>  
        /// <returns></returns>  
        public static bool CreateAppPool(string appPool)
        {
            try
            {
                if (!IsAppPoolExsit(appPool))
                {
                    var appPools = new DirectoryEntry(string.Format("IIS://{0}/W3SVC/AppPools", Host));
                    DirectoryEntry entry = appPools.Children.Add(appPool, "IIsApplicationPool");
                    entry.CommitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>  
        ///     编辑应用程序池  
        /// </summary>  
        /// <param name="application"></param>  
        /// <returns></returns>  
        public static bool EditAppPool(ApplicationPool application)
        {
            try
            {
                if (IsAppPoolExsit(application.Name))
                {
                    var manager = new ServerManager();
                    manager.ApplicationPools[application.Name].ManagedRuntimeVersion = application.ManagedRuntimeVersion;
                    manager.ApplicationPools[application.Name].ManagedPipelineMode = application.ManagedPipelineMode;
                    //托管模式Integrated为集成 Classic为经典  
                    manager.CommitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
