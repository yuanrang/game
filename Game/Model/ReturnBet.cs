using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class ReturnBet:Bet
    {
        /// <summary>
        /// 哈希
        /// </summary>
        public string block_hash { get; set; }

        /// <summary>
        /// 游戏类型名称
        /// </summary>
        public string GameTypeName { get; set; }

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
