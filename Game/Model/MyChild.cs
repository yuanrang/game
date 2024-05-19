using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class MyChild
    {
        public string username { get; set; }
        public Int64 ParentPassportId { get; set; }
        public Int32 MyLevel { get; set; }
        public Int64 PassportId { get; set; }
        /// <summary>
        /// 代理类型ID
        /// </summary>
        public int AgentTypeId { get; set; }
        /// <summary>
        /// 商户PassportId
        /// </summary>
        public int ManageUserPassportId { get; set; }
    }
}
