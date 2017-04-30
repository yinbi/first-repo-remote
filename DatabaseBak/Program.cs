using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace DatabaseBak
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullBak = "fullfile";
            DataTable dtfull = GetUploadInfo(fullBak);

            string diffBak = "difffile";
            DataTable dtdiff = GetUploadInfo(diffBak);

            try
            {
                ChooseFileUpLoad(dtfull, "*.bak");
                Console.WriteLine("所有完整备份传输完毕");
                ChooseFileUpLoad(dtdiff, "*.bak");
                Console.WriteLine("所有差异备份传输完毕");
            }
            catch (Exception e)
            {
                WriteLog.Write("log", "e=" + e.ToString());
            }
            
           
            string filePath = "1.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            //Console.ReadKey();

        }
        private static void ChooseFileUpLoad(DataTable dt,string postfixName)
        {
            //account_qd_backup_201601160401
            string curDay = DateTime.Now.ToString("yyyyMMdd");
            curDay = "_backup_" + curDay;
            //curDay = "_2015_05_29_";
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string databaseName = row["databasename"].ToString();
                    string localPath = row["localPath"].ToString() + databaseName;
                    //\autoftp\diff\TLCar
                    string remotePath = row["remotePath"].ToString() + databaseName;

                    DirectoryInfo folder = new DirectoryInfo(localPath);
                    if (folder.Exists)
                    {
                        foreach (FileInfo file in folder.GetFiles(postfixName))
                        {
                            string curFileName = file.Name;
                            if (curFileName.IndexOf(curDay) >= 0)
                            {
                                try
                                {
                                    UpLoad(localPath, remotePath, curFileName);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }

                            }
                        }
                    }

                }

            }
        }
        private static void UpLoad(string localPath, string remotePath, string localFileName)
        {
            Command com = new Command();
            //string s = @"ftp.exe -s:D:\autoftp\ftp.txt";//正常运行
            string filePath = "1.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(string.Format("lcd {0}", localPath));
            //sw.WriteLine("open 192.168.1.57");
            //sw.WriteLine("aotoftp");
            //sw.WriteLine("123456");
            //sw.WriteLine("binary");
            sw.WriteLine("open 192.168.0.2");
            sw.WriteLine("autoftp");
            sw.WriteLine("autoftp15167144319");
            sw.WriteLine("binary");
            string[] remoteDirs = remotePath.Split('\\');
            foreach (string item in remoteDirs)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    sw.WriteLine(string.Format("cd {0}", item));
                }
            }
            //sw.WriteLine(string.Format("cd {0}", remotePath));
            sw.WriteLine("prompt");
            sw.WriteLine(string.Format("put {0}", localFileName));
            sw.WriteLine("bye");

            //sw.WriteLine(@"lcd F:\databases\diff\TLCar");
            //sw.WriteLine("open 192.168.1.57");
            //sw.WriteLine("aotoftp");
            //sw.WriteLine("123456");
            //sw.WriteLine("binary");
            //sw.WriteLine(@"cd \autoftp");
            //sw.WriteLine("prompt");
            //sw.WriteLine("mput *.bak");
            //sw.WriteLine("bye");

            sw.Flush();
            sw.Close();
            Console.WriteLine(localPath + "\\" + localFileName + " ：准备开始上传...");
            string s = "ftp.exe -s:" + filePath;
            string str = com.RunCmd(s);
            //Console.WriteLine(str);
            //Console.ReadKey();
            Console.WriteLine(localPath + "\\" + localFileName + " ：上传完毕.");
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
        private static void showinfo()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("dir");
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            StringBuilder sb = new StringBuilder();
            string line = reader.ReadLine();
            string str = "";
            while (!reader.EndOfStream)
            {
                //str += line + ("\r");
                str += line;
                line = reader.ReadLine();
                Console.WriteLine(line);
            }
            p.WaitForExit();
            //lbShow.Visible = false;
            p.Close();
            reader.Close();
            //Console.WriteLine(str);
            Console.ReadKey();
        }
        
    }
}
