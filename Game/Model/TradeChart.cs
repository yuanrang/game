using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Model
{
    public class TradeChart
    {
        public int x { get; set; }

        /// <summary>
        /// 损益/新增会员
        /// </summary>
        public decimal y1 { get; set; }
        /// <summary>
        /// 存款/新增代理
        /// </summary>
        public decimal y2 { get; set; }
        /// <summary>
        /// 取款/累计会员
        /// </summary>
        public decimal y3 { get; set; }
        /// <summary>
        /// 优惠红利/累计代理
        /// </summary>
        public decimal y4 { get; set; }
        /// <summary>
        /// 流水分佣/会员游戏
        /// </summary>
        public decimal y5 { get; set; }
        /// <summary>
        /// 流水手续费/代理游戏
        /// </summary>
        public decimal y6 { get; set; }
        /// <summary>
        /// 无效投注/会员活跃数量
        /// </summary>
        public decimal y7 { get; set; }
        /// <summary>
        /// 投注笔数/代理活跃数量
        /// </summary>
        public decimal y8 { get; set; }
        public decimal y9 { get; set; }
        public int y10 { get; set; }
    }
}
