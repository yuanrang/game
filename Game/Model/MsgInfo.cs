using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    /// <summary>
    /// 返回结果集
    /// </summary>
    public class MsgInfo<T>
    {
        private int _code = 200;
        /// <summary>
        /// 状态码(200成功，400错误，500异常)
        /// </summary>
        public int code { get { return _code; } set { _code = value; } }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据集
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 数据集数量
        /// </summary>
        public object data_count { get; set; }
    }


    public class Power
    {
        public string RoleId { get; set; }
        public string PageId { get; set; }
        
    }
}
