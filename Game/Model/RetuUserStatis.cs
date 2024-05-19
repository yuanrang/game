using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class RetuUserStatis
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        public int NewUserCount { get; set; }
        /// <summary>
        /// 新增用户同比
        /// </summary>
        public string NewUserCountTB { get; set; } = "0%";
        /// <summary>
        /// 新增代理
        /// </summary>
        public int NewAgentCount { get; set; }
        /// <summary>
        /// 新增代理同比
        /// </summary>
        public string NewAgentCountTB { get; set; } = "0%";
        /// <summary>
        /// 累计用户
        /// </summary>
        public int AllUserCount { get; set; }
        /// <summary>
        /// 累计用户同比
        /// </summary>
        public string AllUserCountTB { get; set; } = "0%";
        /// <summary>
        /// 累计代理
        /// </summary>
        public int AllAgentCount { get; set; }
        /// <summary>
        /// 累计代理同比
        /// </summary>
        public string AllAgentCountTB { get; set; } = "0%";
        /// <summary>
        /// 游戏用户
        /// </summary>
        public int AllGameUserCount { get; set; }
        /// <summary>
        /// 游戏用户同比
        /// </summary>
        public string AllGameUserCountTB { get; set; } = "0%";
        /// <summary>
        /// 游戏代理
        /// </summary>
        public int AllGameAgentCount { get; set; }
        /// <summary>
        /// 游戏代理同比
        /// </summary>
        public string AllGameAgentCountTB { get; set; } = "0%";

        /// <summary>
        /// 会员活跃数量
        /// </summary>
        public int MemberActiveCount { get; set; }
        /// <summary>
        /// 会员活跃数量
        /// </summary>
        public string MemberActiveCountTB { get; set; } = "0%";
        /// <summary>
        /// 代理活跃数量同比
        /// </summary>
        public int AgentActiveCount { get; set; }
        /// <summary>
        /// 代理活跃数量同比
        /// </summary>
        public string AgentActiveCountTB { get; set; } = "0%";

        public List<TradeChart> tradeCharts { get; set; }
    }
}
