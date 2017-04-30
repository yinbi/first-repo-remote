using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Users
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 夺宝期数
        /// </summary>
        public int PIssue { get; set; }
        /// <summary>
        /// 夺宝数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 获得的号码
        /// </summary>
        public string Nums { get; set; }
        /// <summary>
        /// 是否分配成功
        /// </summary>
        public int IsSuccess { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Err { get; set; }
    }
}
