﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace DatabaseBak
{
    /// <summary> 
    /// Command 的摘要说明。 
    /// </summary> 
    public class Command
    {
        private Process proc = null;
        /// <summary> 
        /// 构造方法 
        /// </summary> 
        public Command()
        {
            proc = new Process();
        }
        /// <summary> 
        /// 执行CMD语句 
        /// </summary> 
        /// <param name="cmd">要执行的CMD命令</param> 
        public string RunCmd(string cmd)
        {
            Console.WriteLine("正在上传中...");
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.StandardInput.WriteLine(cmd);
            proc.StandardInput.WriteLine("exit");
            StreamReader reader = proc.StandardOutput;
            StringBuilder sb = new StringBuilder();
            string line = reader.ReadLine();
            string str = "";
            while (!reader.EndOfStream)
            {
                //str += line + ("\r");
                str += line;
                line = reader.ReadLine();
                //Console.WriteLine(line);
            }
            proc.WaitForExit();
            proc.Close();
            reader.Close();
            return str;
           
        }
        /// <summary> 
        /// 执行CMD语句 
        /// </summary> 
        /// <param name="cmd">要执行的CMD命令</param> 
        //public void RunCmd(string cmd)
        //{
        //    proc.StartInfo.CreateNoWindow = true;
        //    proc.StartInfo.FileName = "cmd.exe";
        //    proc.StartInfo.UseShellExecute = false;
        //    proc.StartInfo.RedirectStandardError = true;
        //    proc.StartInfo.RedirectStandardInput = true;
        //    proc.StartInfo.RedirectStandardOutput = true;
        //    proc.Start();
        //    proc.StandardInput.WriteLine(cmd);
        //    proc.Close();
        //}
        /// <summary> 
        /// 打开软件并执行命令 
        /// </summary> 
        /// <param name="programName">软件路径加名称（.exe文件）</param> 
        /// <param name="cmd">要执行的命令</param> 
        public void RunProgram(string programName, string cmd)
        {
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = programName;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            if (cmd.Length != 0)
            {
                proc.StandardInput.WriteLine(cmd);
            }
            proc.Close();
        }
        /// <summary> 
        /// 打开软件 
        /// </summary> 
        /// <param name="programName">软件路径加名称（.exe文件）</param> 
        public void RunProgram(string programName)
        {
            this.RunProgram(programName, "");
        }
    }
}
