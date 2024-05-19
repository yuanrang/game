using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telegram_Bot.Model
{
    /// <summary>
    /// 返回结果集
    /// </summary>
    public class MsgInfo
    {
        /// <summary>
        /// 状态码(200成功，400错误，500异常)
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据集
        /// </summary>
        public object data { get; set; }
        /// <summary>
        /// 数据集数量
        /// </summary>
        public object data_count { get; set; }
    }
}
