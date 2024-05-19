using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuRechargeCashOrder: RechargeCashOrder
    {
        /// <summary>
        /// 会员等级
        /// </summary>
        public string MyLevel { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
    }
}
