using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClearOldDatabaseBak
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullBak = "fullfile";
            DataTable dtfull = GetUploadInfo(fullBak);
            try
            {
                ChooseFileDel(dtfull, "*.bak");
            }
            catch (Exception e)
            {
                WriteLog.Write("log", "e=" + e.ToString());
            }
            Console.WriteLine("执行完毕");
        }

        private static void ChooseFileDel(DataTable dt, string postfixName)
        {

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string databaseName = row["databasename"].ToString();
                    string remoteLocalPath = row["remoteLocalPath"].ToString();// +"full\\";
                    string remotePath = row["remotePath"].ToString();
                    DirectoryInfo _fullFolder = new DirectoryInfo(remoteLocalPath + "full\\" + databaseName);
                    if (_fullFolder.Exists)
                    {
                        //FileInfo newestFile = folder.GetFiles().OrderBy(n => n.LastWriteTime).First();
                        FileInfo newestFile = _fullFolder.GetFiles().OrderBy(n => GetNumber(n.Name)).LastOrDefault();
                        if (newestFile != null && newestFile.Exists)
                        {
                            Console.WriteLine("最新文件:" + newestFile.Name + "数字为:" + GetNumber(newestFile.Name).ToString());
                            foreach (FileInfo file in _fullFolder.GetFiles(postfixName))
                            {
                                if (file.Exists)
                                {
                                    if (file.Name != newestFile.Name)
                                    {
                                        Console.WriteLine("删除完整备份老数据:" + file.Name + " ...");
                                        file.Delete();
                                    }
                                }
                            }
                            DirectoryInfo _diffFolder = new DirectoryInfo(remoteLocalPath + "diff\\" + databaseName);
                            if (_diffFolder.Exists)
                            {
                                foreach (FileInfo diffFill in _diffFolder.GetFiles(postfixName))
                                {
                                    if (diffFill.Exists)
                                    {
                                        if (GetNumber(diffFill.Name) < GetNumber(newestFile.Name))
                                        {
                                            Console.WriteLine("删除差异备份老数据:" + diffFill.Name + " ...");
                                            diffFill.Delete();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }

        private static DataTable GetUploadInfo(string tableName)
        {
            //string xmlPath = @"..\..\config\uploadFile.xml";
            string xmlPath = "uploadFile.xml";
            DataSet ds = new DataSet();
            if (!File.Exists(xmlPath))
            {
                return null;
            }
            ds.ReadXml(xmlPath);
            return ds.Tables[tableName];
        }
        /// <summary>
        /// 获取字符串中的数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>数字</returns>
        private static long GetNumber(string str)
        {
            long result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d]", "");
                // 如果是数字，则转换为decimal类型
                if (Regex.IsMatch(str, @"^[0-9]*$"))
                {
                    result = long.Parse(str);
                }
            }
            return result;
        }
    }
}
