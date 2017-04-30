﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DatabaseBak
{
    public class WriteLog
    {
        public static int Write(string logname, string p_strLogMessage)
        {
            // 组合地址
            string p_strPath = AppDomain.CurrentDomain.BaseDirectory + "\\Log\\" + logname + "\\";
            string strPath = p_strPath + "\\Log" + Convert.ToString(System.DateTime.Now.ToString("yyyyMM"));
            string strFileName = "Log_";

            Directory.CreateDirectory(strPath);
            string strDate = System.DateTime.Now.ToString("yyyyMMdd");
            strPath = strPath + "\\" + strFileName + strDate + ".Log";

            // 组合信息
            string strLogMessage = "";
            strLogMessage += System.DateTime.Now.ToString() + "     ";
            strLogMessage += p_strLogMessage;
            // 写到文件
            lock (typeof(WriteLog))
            {
                StreamWriter swFromFile = new StreamWriter(strPath, true);
                swFromFile.WriteLine(strLogMessage);
                swFromFile.Flush();
                swFromFile.Close();
            }
            return 1;
        }
    }
}
